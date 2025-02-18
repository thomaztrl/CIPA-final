using Microsoft.AspNetCore.Mvc;
using CIPA.Models;

namespace CIPA.Controllers
{
    public class VotacaoController : Controller
    {
        // GET: Votacao/RegistrarVoto
        // Action para exibir a página de registro de votos (View: RegistrarVoto.cshtml)
        public IActionResult RegistrarVoto()
        {
            // Passa a lista de candidatos (DataStore.Candidatos) para a View
            return View(DataStore.Candidatos);
        }

        // POST: Votacao/RegistrarVoto
        // Action para processar o registro de um voto (POST)
        [HttpPost]
        public IActionResult RegistrarVoto(int candidatoId)
        {
            // Busca o candidato pelo ID na lista de candidatos (Model)
            var candidato = DataStore.Candidatos.FirstOrDefault(c => c.Id == candidatoId);

            // Se o candidato for encontrado, incrementa a contagem de votos
            if (candidato != null)
            {
                candidato.Votos++;
            }

            // Redireciona para a página inicial (View: Index.cshtml do HomeController)
            return RedirectToAction("Index", "Home");
        }

        // GET: Votacao/MostrarResultado
        // Action para exibir a página de resultados da votação (View: MostrarResultado.cshtml)
        public IActionResult MostrarResultado()
        {
            // Passa a lista de candidatos (DataStore.Candidatos) para a View
            return View(DataStore.Candidatos);
        }
    }
}