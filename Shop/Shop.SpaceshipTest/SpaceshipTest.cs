using ShopCore.Domain;
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

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("204d3f40-0d9c-4adf-8bd2-602823455f47");
            //arrange
            //old data from db

            Spaceship spaceship = new Spaceship();
            //new data

            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");
            spaceship.Name = "asd";
            spaceship.Type = "asdasd";
            spaceship.Passengers = 123123;
            spaceship.EnginePower = 123123;
            spaceship.Crew = 123;
            spaceship.Company = "Company asd";
            spaceship.CargoWeight = 657;
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt = DateTime.Now.AddYears(1);

            //act
            await Svc<ISpaceshipServices>().Update(dto);

            //assert
            Assert.Equal(spaceship.Id, guid);
            Assert.NotEqual(spaceship.EnginePower, dto.EnginePower);
            Assert.Equal(spaceship.Crew, dto.Crew);
            Assert.DoesNotMatch(spaceship.Passengers.ToString(), dto.Passengers.ToString());

        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipServices>().Create(dto);

            SpaceshipDto update = MockUpdateSpaceshipData();
            var UpdateSpaceship = await Svc<ISpaceshipServices>().Update(update);

            Assert.DoesNotMatch(UpdateSpaceship.Name.ToString(), createSpaceship.Name.ToString());
            Assert.NotEqual(UpdateSpaceship.EnginePower, createSpaceship.EnginePower);
            Assert.Equal(UpdateSpaceship.Crew, createSpaceship.Crew);
            Assert.DoesNotMatch(UpdateSpaceship.Passengers.ToString(), createSpaceship.Passengers.ToString());
        }



        private SpaceshipDto MockUpdateSpaceshipData()
        {
            SpaceshipDto update = new()
            {
                Name = "asd",
                Type = "asd",
                Passengers = 123456,
                EnginePower = 123456,
                Crew = 123456,
                Company = "asdasdasd",
                CargoWeight = 123456,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return update;
        }


        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "asd123",
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
