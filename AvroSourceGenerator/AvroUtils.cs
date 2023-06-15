using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Avro;

namespace AvroSourceGenerator;

public static class AvroUtils
{
    public static IDictionary<string, string> GenerateSourceCode(
        ImmutableArray<(string schemaName, string schemaContents)> schemaNamesAndContents)
    {
        var codeGen = new CodeGen();
        var parsedSchemas = Schema.ParseAll(
            schemaNamesAndContents.Select(t => t.schemaContents));
        foreach (var schema in parsedSchemas)
        {
            codeGen.AddSchema(schema.Value);
        }

        codeGen.GenerateCode();
        return codeGen.GetTypes();
    }
}