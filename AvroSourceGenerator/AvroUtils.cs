using System;
using System.Collections.Immutable;
using System.IO;
using System.Text;
using Avro;

namespace AvroSourceGenerator;

public static class AvroUtils
{
    private static readonly SchemaNames SchemaNames = new();

    public static string GenerateSourceCode(
        ImmutableArray<(string schemaName, string schemaContents)> schemaNamesAndContents)
    {
        var stringWriter = new StringWriter(new StringBuilder());

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

        foreach (var file in Directory.GetFiles(tempDir))
        {
            var contents = File.ReadAllText(file);
            stringWriter.WriteLine(contents);
        }

        Directory.Delete(tempDir, true);

        return stringWriter.ToString();
    }
}