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

        var planetEnumKeyCount = generatedSources.Count(kvp => kvp.Key == "PlanetEnum");
        Assert.Equal(1, planetEnumKeyCount);
        var planetEnumDefinitionCount =
            generatedSources.Sum(kvp => Regex.Matches(kvp.Value, "public enum PlanetEnum").Count);
        Assert.Equal(1, planetEnumDefinitionCount);
    }
}