using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Avro;

namespace AvroSourceGenerator;

public static class AvroUtils
{
    private static readonly SchemaNames SchemaNames = new();
    
    public static string GenerateSourceCode(string schemaText)
    {
        var schema = Schema.Parse(schemaText, SchemaNames);
        var codeCompileUnit = new CodeGen
        {
            Schemas =
            {
                schema
            }
        }.GenerateCode();

        var stringWriter = new StringWriter(new StringBuilder());
        var provider = CodeDomProvider.CreateProvider("csharp");
        provider.GenerateCodeFromCompileUnit(codeCompileUnit, stringWriter, new CodeGeneratorOptions());
        return stringWriter.ToString();
    }
}