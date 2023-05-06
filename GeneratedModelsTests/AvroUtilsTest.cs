using AvroSourceGenerator;

namespace GeneratedModelsTests;

public class AvroUtilsTest
{
    [Fact]
    public void TestAvroUtilGenerateSourceCode()
    {
        var planetEnumSchema = File.ReadAllText("./planet-enum.json");
        var planetEnumSourceCode = AvroUtils.GenerateSourceCode(planetEnumSchema);

        var solarSystemSchema = File.ReadAllText("./solar-system-model.json");
        var solarSystemSourceCode = AvroUtils.GenerateSourceCode(solarSystemSchema);

        // we should define the planet enum in one file
        Assert.Contains("public enum PlanetEnum", planetEnumSourceCode);
        
        // we should *reference*, but not define, the planet enum in the other file
        Assert.DoesNotContain("public enum PlanetEnum", solarSystemSourceCode);
    }
}