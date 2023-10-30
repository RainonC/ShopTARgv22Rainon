using Microsoft.EntityFrameworkCore;
using ShopCore.Dto;
using ShopCore.ServiceInterface;
using Shop.data;
using ShopCore.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class KindergartenServices : IKindergartenServices
    {
        private readonly ShopContext _context;
        private readonly IFileServices _fileServices;

        public KindergartenServices
            (
                ShopContext context,
                IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {

            Kindergarten kindergarten = new Kindergarten();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;

            // if (dto.Files != null)
            {
                //    _fileServices.UploadFilesToDatabase(dto, realEstate);
            }

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }


        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            var domain = new Kindergarten()
            {
                Id = dto.Id,
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                Teacher = dto.Teacher,               
                CreatedAt = dto.CreatedAt,
                UpdatedAt = DateTime.Now,
            };

            //if (dto.Files != null)
            //{
            //    _fileServices.UploadFilesToDatabase(dto, domain);
            //}

            _context.Kindergartens.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            var kinderGartenId = await _context.Kindergartens
                    .FirstOrDefaultAsync(x => x.Id == id);

            _context.Kindergartens.Remove(kinderGartenId);
            await _context.SaveChangesAsync();

            return kinderGartenId;
        }


        public async Task<Kindergarten> GetAsync(Guid id)
        {
            var result = await _context.Kindergartens
            .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}


