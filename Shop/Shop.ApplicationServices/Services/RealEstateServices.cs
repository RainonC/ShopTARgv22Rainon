﻿using Microsoft.EntityFrameworkCore;

using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.data;



using ShopCore.Domain;
using ShopCore.Dto;
using ShopCore.ServiceInterface;


namespace Shop.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstatesServices
    {
        private readonly ShopContext _context;
        private readonly IFileServices _fileServices;

        public RealEstatesServices
            (
                ShopContext context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {

            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.SizeSqrM = dto.SizeSqrM;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.Floor = dto.Floor;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.BuiltInYear = dto.BuiltInYear;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realEstate);
            }

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }


        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            var domain = new RealEstate()
            {
                Id = dto.Id,
                Address = dto.Address,
                SizeSqrM = dto.SizeSqrM,
                RoomCount = dto.RoomCount,
                Floor = dto.Floor,
                BuildingType = dto.BuildingType,
                BuiltInYear = dto.BuiltInYear,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = DateTime.Now,
            };

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, domain);
            }

            _context.RealEstates.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realestateId = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _context.FileToDatabases
          .Where(x => x.RealEstateId == id)
          .Select(y => new FileToDatabaseDto
          {
              Id = y.Id,
              ImageTitle = y.ImageTitle,
              RealEstateId = y.RealEstateId
          })
          .ToArrayAsync();

            await _fileServices.RemovePhotosFromDatabase(photos);

            _context.RealEstates.Remove(realestateId);
            await _context.SaveChangesAsync();

            return realestateId;
        }


        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}