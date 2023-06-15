// using Space.Bodies;
// using Space.Models;
// using Space.Travel;
//
// namespace GeneratedModelsTests;
//
// public class ModelsTest
// {
//     [Fact]
//     public void PlanetEnumExists()
//     {
//         // this test won't run unless the source generation worked
//         const PlanetEnum foo = PlanetEnum.Earth;
//         Assert.Equal(PlanetEnum.Earth, foo);
//     }
//
//     [Fact]
//     public void SpaceShipModelExists()
//     {
//         // this test won't run unless the source generation worked
//         var rocketMcRocketFace = new SpaceShip
//         {
//             Name = "Rocket McRocketFace",
//             HomePlanet = PlanetEnum.Earth
//         };
//         Assert.Equal(PlanetEnum.Earth, rocketMcRocketFace.HomePlanet);
//     }
//
//     [Fact]
//     public void SolarSystemModelExists()
//     {
//         // this test won't run unless the source generation worked
//         var ourSolarSystem = new SolarSystem
//         {
//             Name = "Our Solar System",
//             Planets = new List<PlanetEnum>
//             {
//                 PlanetEnum.Earth,
//                 PlanetEnum.Jupiter,
//                 PlanetEnum.Mars,
//                 PlanetEnum.Neptune,
//                 PlanetEnum.Saturn,
//                 PlanetEnum.Uranus
//             }
//         };
//         Assert.Equal("Our Solar System", ourSolarSystem.Name);
//     }
// }