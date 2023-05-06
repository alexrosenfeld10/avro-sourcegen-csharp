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

        var generatedSources = AvroUtils.GenerateSourceCode(schemaNamesAndContents);

        var planetEnumDefinitionCount =
            generatedSources.Sum(tuple => Regex.Matches(tuple.code, "public enum PlanetEnum").Count);
        Assert.Equal(1, planetEnumDefinitionCount);
    }
}