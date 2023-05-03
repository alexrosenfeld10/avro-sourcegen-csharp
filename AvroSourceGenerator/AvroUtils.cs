using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Avro;

namespace AvroSourceGenerator;

public static class AvroUtils
{
    public static string GenerateSourceCode(string schemaText)
    {
        var codeCompileUnit = new CodeGen
        {
            Schemas =
            {
                Schema.Parse(schemaText)
            }
        }.GenerateCode();

        var stringWriter = new StringWriter(new StringBuilder());
        var provider = CodeDomProvider.CreateProvider("csharp");
        provider.GenerateCodeFromCompileUnit(codeCompileUnit, stringWriter, new CodeGeneratorOptions());
        return stringWriter.ToString();
    }
}