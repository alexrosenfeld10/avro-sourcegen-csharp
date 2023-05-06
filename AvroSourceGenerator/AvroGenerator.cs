using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace AvroSourceGenerator;

[Generator]
public class AvroGenerator : IIncrementalGenerator
{
    /// <summary>
    /// Commenting these lines back in will cause source generation to fail
    /// because Avro fails to resolve namespace references between files in the same directory.
    /// https://github.com/alfhv/avro is a fork that attempts to fix this problem,
    /// this code should be tested against that fork.
    /// </summary>
    private readonly IEnumerable<string> _avroSchemasToGenerate = new HashSet<string>
    {
        "planet-enum",

        // commented out for simplicity's sake. Just generate two for now, to keep things simple while debugging the avro fork.
        "solar-system-model",

        // This is commented out to make the generator succeed so that the unit tests can be run.
        // To test the source generation, comment this line back in.
        "space-ship-model"
    };

    public void Initialize(IncrementalGeneratorInitializationContext initContext)
    {
        var schemaFiles = initContext
            .AdditionalTextsProvider
            .Where(file => _avroSchemasToGenerate.Contains(Path.GetFileNameWithoutExtension(file.Path)));

        var schemaFileNameAndContents = schemaFiles.Select(
                static (file, cancellationToken) =>
                    (name: Path.GetFileNameWithoutExtension(file.Path),
                        content: file.GetText(cancellationToken)!.ToString()))
            .Collect();

        initContext.RegisterSourceOutput(schemaFileNameAndContents,
            static (spc, namesAndContents) =>
            {
                var generatedSources = AvroUtils.GenerateSourceCode(namesAndContents);
                foreach (var (name, code) in generatedSources)
                {
                    spc.AddSource($"AvroGenerated_{name}", code);
                }
            });
    }
}