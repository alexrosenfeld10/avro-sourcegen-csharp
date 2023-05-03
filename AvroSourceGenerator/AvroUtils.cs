using System.IO;
using System.Text;
using Chr.Avro.Codegen;
using Chr.Avro.Representation;

namespace AvroSourceGenerator;

public static class AvroUtils
{
    public static string GenerateSourceCode(string schemaText)
    {
        var generator = new CSharpCodeGenerator();
        var jsonSchemaReader = new JsonSchemaReader();
        var schema = jsonSchemaReader.Read(schemaText);
        var code = generator.GenerateCompilationUnit(schema);

        using var memoryStream = new MemoryStream();
        generator.WriteCompilationUnit(schema, memoryStream);
        var actualCode = Encoding.ASCII.GetString(memoryStream.ToArray());

        return actualCode;
    }
}