using Space.Models;

namespace GeneratedModelsTests;

public class ModelsTest
{
    [Fact]
    public void PlanetEnumExists()
    {
        // this test won't run unless the source generation worked
        const PlanetEnum foo = PlanetEnum.Earth;
        Assert.Equal(PlanetEnum.Earth, foo);
    }

    // TODO add a similar test here for the various models that depend on the PlanetEnum
}