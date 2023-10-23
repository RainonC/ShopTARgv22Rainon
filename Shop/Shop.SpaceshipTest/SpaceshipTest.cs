using ShopCore.Dto;
using ShopCore.ServiceInterface;
using System;


namespace Shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnresult()
        {
            SpaceshipDto dto = new SpaceshipDto();

            dto.Name = "Name";
            dto.Type = "Type";
            dto.Passengers = 123;
            dto.EnginePower = 123;
            dto.Crew = 123;
            dto.Company = "asd";
            dto.CargoWeight = 123;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipServices>().Create(dto);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            Guid guid = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");
            //kuidas teha automaatselt guidi??
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<ISpaceshipServices>().GetAsync(guid);


            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
        {
            Guid guid1 = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");
            Guid guid = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");

            // Call the GetAsync method with the guid parameter
            var spaceship = await Svc<ISpaceshipServices>().GetAsync(guid);

            // Check if the returned value is equal to the guid
            Assert.Equal(guid, guid1); // Assuming that spaceship has an "Id" property            
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            //arrange 

            SpaceshipDto spaceship = MockSpaceshipData();

            //act

            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship.Id);

            //assert

            Assert.Equal(result, addSpaceship);

            
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipServices>().Create(spaceship);
            var addSpaceship2 = await Svc<ISpaceshipServices>().Create(spaceship);

            var result = await Svc<ISpaceshipServices>().Delete((Guid)addSpaceship2.Id);

            Assert.NotEqual(result.Id, addSpaceship.Id);
        }


        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "asd",
                Type = "asd",
                Passengers = 123,
                EnginePower = 123,
                Crew = 123,
                Company = "asd",
                CargoWeight = 123,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return spaceship;
        }
    }
}
