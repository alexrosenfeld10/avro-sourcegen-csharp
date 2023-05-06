using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Avro;

namespace AvroSourceGenerator;

public static class AvroUtils
{
    private static readonly SchemaNames SchemaNames = new();

    public static IEnumerable<(string name, string code)> GenerateSourceCode(
        ImmutableArray<(string schemaName, string schemaContents)> schemaNamesAndContents)
    {
        var codeGen = new CodeGen();
        foreach (var (_, schemaContents) in schemaNamesAndContents)
        {
            var schema = Schema.Parse(schemaContents, SchemaNames);
            codeGen.AddSchema(schema);
        }

        codeGen.GenerateCode();

        var tempDir = Path.Join(Path.GetTempPath(), $"avro_generated_{Guid.NewGuid():N}");
        Directory.CreateDirectory(tempDir);
        codeGen.WriteTypes(tempDir, true);

        var generatedSourceCode = (from file in Directory.GetFiles(tempDir)
                let sourceCode = File.ReadAllText(file)
                select (Path.GetFileNameWithoutExtension(file), sourceCode))
            // TODO Would greatly prefer to have a method for generating sources that doesn't require writing to disk.. open PR to apache/avro for this?
            // Must call ToArray() to force enumeration before deleting the temp directory
            .ToArray();

        Directory.Delete(tempDir, true);
        return generatedSourceCode;
    }
}