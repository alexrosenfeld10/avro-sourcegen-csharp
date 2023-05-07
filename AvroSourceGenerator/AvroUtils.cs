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

    public static IDictionary<string, string> GenerateSourceCode(
        ImmutableArray<(string schemaName, string schemaContents)> schemaNamesAndContents)
    {
        var codeGen = new CodeGen();
        foreach (var (_, schemaContents) in schemaNamesAndContents)
        {
            var schema = Schema.Parse(schemaContents, SchemaNames);
            codeGen.AddSchema(schema);
        }

        codeGen.GenerateCode();
        return codeGen.GetTypes();
    }
}