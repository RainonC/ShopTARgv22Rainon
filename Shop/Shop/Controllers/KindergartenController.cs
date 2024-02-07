using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.ApplicationServices.Services;
using ShopCore.Dto;
using Shop.Core.ServiceInterface;
using Shop.data;
using Shop.Models.Kindergarten;
using ShopCore.Domain;

using ShopCore.ServiceInterface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class KindergartenController : Controller
    {

        private readonly ShopContext _context;
        private readonly IKindergartenServices _kindergartenServices; 
        private readonly IFileServices _fileServices;


        public KindergartenController
           (
               ShopContext context,

               IKindergartenServices kindergartenServices,
               IFileServices fileServices
               )dfghdh
        {
            _context = context;

            _kindergartenServices = kindergartenServices;
            _fileServices = fileServices;
        }


        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new KinderGartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    Teacher = x.Teacher,
                });

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            KinderGartenCreateUpdateViewModel kindergarten = new KinderGartenCreateUpdateViewModel();

            return View("CreateUpdate", kindergarten);
        }


        [HttpPost]
        public async Task<IActionResult> Create(KinderGartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,



                //Files = vm.Files,
                //Image = vm.FileToApiViewModels
                //    .Select(x => new FileToApiDto
                //    {
                //        Id = x.Id,
                //        ExistingFilePath = x.FilePath,
                //        //1.filetoapidto 2.filetoapiviewmodel
                //        RealsetateId = x.RealsetateId,
                //    }).ToArray()

            };

            var result = await _kindergartenServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index), vm);
            //return index

        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);

            if (kindergarten == null)
            {
                return NotFound();

            }

            //var images = await _context.FileToApis
            //    .Where(x => x.SpaceshipId == id)
            //    .Select(y => new FileToApiRealViewModel
            //    {
            //        FilePath = y.ExistingFilePath,
            //        Id = y.Id
            //    }).ToArrayAsync();

            var vm = new KinderGartenDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;

            vm.KindergartenName = kindergarten.KindergartenName;

            vm.Teacher = kindergarten.Teacher;

            //string formattedDate = realestate.BuiltinYear.ToString("yyyy-MM-dd HH:mm:ss");

            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;
            //vm.FileToApiViewModels.AddRange((IEnumerable<Models.Realestate.FileToApiRealViewModel>)images);



            return View(vm);



        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }


            var vm = new KinderGartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;

            vm.KindergartenName = kindergarten.KindergartenName;

            vm.Teacher = kindergarten.Teacher;


            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(KinderGartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,




                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
            };
            var result = await _kindergartenServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index), vm);

            }
            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartenServices.GetAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }
            var vm = new KinderGartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;

            vm.KindergartenName = kindergarten.KindergartenName;

            vm.Teacher = kindergarten.Teacher;


            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergartenId = await _kindergartenServices.Delete(id);

            if (kindergartenId == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }







    }
}
