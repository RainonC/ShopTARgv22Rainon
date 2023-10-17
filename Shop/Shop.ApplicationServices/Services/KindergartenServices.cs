using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.data;
using ShopCore.Domain;
using ShopCore.Dto;
using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Shop.ApplicationServices.Services
//{
//        public class KindergartenServices : IKindergartenServices
//        {
//            private readonly ShopContext _context;
//            private readonly IFileServices _fileServices;

//            public KindergartenServices
//                (
//                    ShopContext context,
//                    IFileServices fileServices
//                )
//            {
//                _context = context;
//                _fileServices = fileServices;
//            }

//            public async Task<Kindergarten> Create(KindergartenDto dto)
//            {

//                Kindergarten kindergarten = new Kindergarten();

//                kindergarten.Id = Guid.NewGuid();
//                kindergarten.GroupName = dto.GroupName;
//                kindergarten.ChildrenCount = dto.ChildrenCount;
//                kindergarten.KindergartenName = dto.KindergartenName;
//                kindergarten.Teacher = dto.Teacher;
//                kindergarten.CreatedAt = DateTime.Now;
//                kindergarten.UpdatedAt = DateTime.Now;

//               // if (dto.Files != null)
//                {
//                //    _fileServices.UploadFilesToDatabase(dto, realEstate);
//                }

//               // await _context.RealEstates.AddAsync(realEstate);
//                await _context.SaveChangesAsync();

//               // return realEstate;
//            }


//            public async Task<RealEstate> Update(RealEstateDto dto)
//            {
//                var domain = new RealEstate()
//                {
//                    Id = dto.Id,
//                    Address = dto.Address,
//                    SizeSqrM = dto.SizeSqrM,
//                    RoomCount = dto.RoomCount,
//                    Floor = dto.Floor,
//                    BuildingType = dto.BuildingType,
//                    BuiltInYear = dto.BuiltInYear,
//                    CreatedAt = dto.CreatedAt,
//                    UpdatedAt = DateTime.Now,
//                };

//                if (dto.Files != null)
//                {
//                    _fileServices.UploadFilesToDatabase(dto, domain);
//                }

//                _context.RealEstates.Update(domain);
//                await _context.SaveChangesAsync();

//                return domain;
//            }

//            public async Task<RealEstate> Delete(Guid id)
//            {
//                var realEstateId = await _context.RealEstates
//                   // .FirstOrDefaultAsync(x => x.Id == id);

//                _context.RealEstates.Remove(realEstateId);
//                await _context.SaveChangesAsync();

//                return realEstateId;
//            }


//            public async Task<RealEstate> GetAsync(Guid id)
//            {
//                //var result = await _context.RealEstates
//                    //.FirstOrDefaultAsync(x => x.Id == id);

//               // return result;
//            }
//        }
//    }
//}

