using System.Collections.Immutable;
using System.Text.RegularExpressions;
using AvroSourceGenerator;

namespace GeneratedModelsTests;

public class AvroUtilsTest
{
    [Fact]
    public void TestAvroUtilGenerateSourceCode()
    {
        var schemaNamesAndContents = new[]
        {
            ("planet-enum", File.ReadAllText("./planet-enum.json")),
            ("solar-system-model", File.ReadAllText("./solar-system-model.json"))
        }.ToImmutableArray();

        var sourceCode = AvroUtils.GenerateSourceCode(schemaNamesAndContents);

        Assert.True(Regex.Matches(sourceCode, "public enum PlanetEnum").Count == 1);
    }
}