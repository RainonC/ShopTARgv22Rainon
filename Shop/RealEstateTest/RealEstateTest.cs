using Shop.Core.Dto;
using ShopCore.Domain;
using ShopCore.Dto;
using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.RealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnresult()
        {
            RealEstateDto dto = new RealEstateDto();

            dto.Address = "address";
            dto.SizeSqrM = 123;
            dto.RoomCount = 123;
            dto.Floor = 123;
            dto.BuildingType = "Building Type";
            dto.BuiltInYear = DateTime.Now;
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            var result = await Svc<IRealEstatesServices>().Create(dto);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            Guid guid = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");
            //kuidas teha automaatselt guidi??
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<IRealEstatesServices>().GetAsync(guid);


            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            Guid guid1 = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");
            Guid guid = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");

            // Call the GetAsync method with the guid parameter
            var realestate = await Svc<IRealEstatesServices>().GetAsync(guid);

            // Check if the returned value is equal to the guid
            Assert.Equal(guid, guid1); // Assuming that realestate has an "Id" property            
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //arrange 

            RealEstateDto realestate = MockRealEstateData();

            //act

            var addRealEstate = await Svc<IRealEstatesServices>().Create(realestate);
            var result = await Svc<IRealEstatesServices>().Delete((Guid)addRealEstate.Id);

            //assert

            Assert.Equal(result, addRealEstate);


        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            RealEstateDto realestate = MockRealEstateData();

            var addRealEstate = await Svc<IRealEstatesServices>().Create(realestate);
            var addRealEstate2 = await Svc<IRealEstatesServices>().Create(realestate);

            var result = await Svc<IRealEstatesServices>().Delete((Guid)addRealEstate2.Id);

            Assert.NotEqual(result.Id, addRealEstate.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("204d3f40-0d9c-4adf-8bd2-602823455f47");
            //arrange
            //old data from db

            RealEstate realestate = new RealEstate();
            //new data

            RealEstateDto dto = MockRealEstateData();

            realestate.Id = Guid.Parse("204d3f40-0d9c-4adf-8bd2-602823455f47");
            realestate.Address = "asd";
            realestate.SizeSqrM = 123123;
            realestate.RoomCount = 123123;
            realestate.Floor = 123123;
            realestate.BuildingType = "type asd";
            realestate.BuiltInYear = DateTime.Now.AddYears(1);
            realestate.CreatedAt = DateTime.Now.AddYears(1);
            realestate.UpdatedAt = DateTime.Now.AddYears(1);

            //act
            await Svc<IRealEstatesServices>().Update(dto);

            //assert
            Assert.Equal(realestate.Id, guid);
            Assert.NotEqual(realestate.Floor, dto.Floor);
            Assert.NotEqual(realestate.RoomCount, dto.RoomCount);
            Assert.DoesNotMatch(realestate.SizeSqrM.ToString(), dto.SizeSqrM.ToString());

        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
        {
            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstatesServices>().Create(dto);

            RealEstateDto update = MockUpdateRealEstateData();
            var UpdateRealEstate = await Svc<IRealEstatesServices>().Update(update);

            Assert.DoesNotMatch(UpdateRealEstate.Address.ToString(), createRealEstate.Address.ToString());
            Assert.NotEqual(UpdateRealEstate.SizeSqrM, createRealEstate.SizeSqrM);
            Assert.NotEqual(UpdateRealEstate.RoomCount, createRealEstate.RoomCount);
            Assert.DoesNotMatch(UpdateRealEstate.Floor.ToString(), createRealEstate.Floor.ToString());
        }


        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenNotUpdateData()
        {
            RealEstateDto dto = MockRealEstateData();
            await Svc<IRealEstatesServices>().Create(dto);

            RealEstateDto nullUpdate = MockNullRealEstate();
            await Svc<IRealEstatesServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private RealEstateDto MockNullRealEstate()
        {
            RealEstateDto nullDto = new()
            {
                Address = "address123",
                SizeSqrM = 123,
                RoomCount = 123,
                Floor = 123,
                BuildingType = "Building Type123",
                BuiltInYear = DateTime.Now.AddYears(1),
                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1),
        };
            return nullDto;
        }



        private RealEstateDto MockUpdateRealEstateData()
        {
            RealEstateDto update = new()
            {
                Address = "asdadssad123",
                SizeSqrM = 123123,
                RoomCount = 123123,
                Floor = 123123,
                BuildingType = "asdasd123",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return update;
        }


        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realestate = new()
            {
                Address = "asd",
                SizeSqrM = 123,
                RoomCount = 123,
                Floor = 123,
                BuildingType = "asd",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return realestate;
        }
    }
}
