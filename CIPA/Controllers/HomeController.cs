using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CIPA.Models;

namespace CIPA.Controllers;

public class HomeController : Controller
{
    // Logger para registrar informações, avisos e erros (opcional)
    private readonly ILogger<HomeController> _logger;

    // Construtor que recebe o logger por injeção de dependência
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // GET: Home/Index
    // Action para exibir a página inicial (View: Index.cshtml)
    public IActionResult Index()
    {
        return View();
    }

    // GET: Home/Privacy
    // Action para exibir a página de privacidade (View: Privacy.cshtml)
    public IActionResult Privacy()
    {
        return View();
    }

    // GET: Home/Error
    // Action para exibir a página de erro (View: Error.cshtml)
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Cria um modelo de erro com o ID da requisição atual
        var errorViewModel = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        // Passa o modelo de erro para a View
        return View(errorViewModel);
    }
}