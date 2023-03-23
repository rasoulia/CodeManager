using CodeManager.Models;
using CodeManager.Services.Interfaces;
using CodeManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICodeService _code;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICodeService code, ILogger<HomeController> logger)
        {
            _code = code;
            _logger = logger;
        }
        public IActionResult Index(CodeViewModel codeViewModel)
        {
            CodeViewModel result = _code.GetAllCodes(codeViewModel.Page);
            return View(result);
        }

        [HttpGet("/add-or-update-code/{id:int}")]
        public IActionResult AddOrUpdateCode(int id)
        {
            Code? result = _code.GetCodeById(id).Result;
            return View(result);
        }

        [HttpPost("/add-or-update-code/{id:int}")]
        public IActionResult AddOrUpdateCode(int id, Code code)
        {
            if (!ModelState.IsValid)
            {
                return View(code);
            }

            if (code.Id > 0)
            {
                _ = _code.UpdateCode(code);
            }

            else
            {
                _ = _code.AddCode(code);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/search")]
        public IActionResult SearchCode(string search, int page = 1)
        {
            CodeViewModel result = _code.GetAllCodesBySearch(page, search);

            return View(result);
        }
    }
}