using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pieRepository.Pies;
            pieListViewModel.CurrentCateogry = "Cheese Cake";
            return View(pieListViewModel);
        }

        public IActionResult Details(int pieId)
        {
            var pie = pieRepository.GetPieById(pieId);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
