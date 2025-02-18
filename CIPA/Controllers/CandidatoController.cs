using Microsoft.AspNetCore.Mvc;
using CIPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIPA.Controllers
{
    public class CandidatoController : Controller
    {
        // Lista estática para armazenar os candidatos (substitua por um banco de dados em um cenário real)
        private static List<Candidato> candidatos = new List<Candidato>();

        // GET: Candidato
        // Action para exibir a lista de candidatos (View: Index.cshtml)
        public IActionResult Index()
        {
            // Passa a lista de candidatos para a View
            return View(candidatos);
        }

        // GET: Candidato/Create
        // Action para exibir o formulário de cadastro de candidatos (View: Create.cshtml)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        // Action para processar o formulário de cadastro de candidatos (POST)
        [HttpPost]
        public IActionResult Create(Candidato candidato)
        {
            // Validação do número do partido (Model)
            if (candidato.NumeroPartido.ToString().Length != 4)
            {
                ModelState.AddModelError("NumeroPartido", "O número do partido deve ter exatamente 4 dígitos.");
            }

            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                // Gera um ID para o candidato
                candidato.Id = candidatos.Count + 1;
                // Adiciona o candidato à lista (Model)
                candidatos.Add(candidato);
                // Redireciona para a lista de candidatos (View: Index.cshtml)
                return RedirectToAction("Index");
            }

            // Se houver erros de validação, retorna para a view de criação (View: Create.cshtml)
            return View(candidato);
        }

        // GET: Candidato/Edit/5
        // Action para exibir o formulário de edição de candidatos (View: Edit.cshtml)
        public IActionResult Edit(int id)
        {
            // Busca o candidato pelo ID na lista (Model)
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound(); // Retorna um erro 404 se o candidato não for encontrado
            }
            // Passa o candidato para a View
            return View(candidato);
        }

        // POST: Candidato/Edit/5
        // Action para processar o formulário de edição de candidatos (POST)
        [HttpPost]
        public IActionResult Edit(Candidato candidato)
        {
            // Validação do número do partido (Model)
            if (candidato.NumeroPartido.ToString().Length != 4)
            {
                ModelState.AddModelError("NumeroPartido", "O número do partido deve ter exatamente 4 dígitos.");
            }

            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                // Busca o candidato existente pelo ID na lista (Model)
                var existingCandidato = candidatos.FirstOrDefault(c => c.Id == candidato.Id);
                if (existingCandidato != null)
                {
                    // Atualiza os dados do candidato (Model)
                    existingCandidato.Nome = candidato.Nome;
                    existingCandidato.NumeroPartido = candidato.NumeroPartido;
                }
                // Redireciona para a lista de candidatos (View: Index.cshtml)
                return RedirectToAction("Index");
            }

            // Se houver erros de validação, retorna para a view de edição (View: Edit.cshtml)
            return View(candidato);
        }

        // GET: Candidato/Details/5
        // Action para exibir os detalhes de um candidato (View: Details.cshtml)
        public IActionResult Details(int id)
        {
            // Busca o candidato pelo ID na lista (Model)
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound(); // Retorna um erro 404 se o candidato não for encontrado
            }
            // Passa o candidato para a View
            return View(candidato);
        }

        // GET: Candidato/Delete/5
        // Action para exibir a confirmação de exclusão de um candidato (View: Delete.cshtml)
        public IActionResult Delete(int id)
        {
            // Busca o candidato pelo ID na lista (Model)
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound(); // Retorna um erro 404 se o candidato não for encontrado
            }
            // Passa o candidato para a View
            return View(candidato);
        }

        // POST: Candidato/Delete/5
        // Action para confirmar a exclusão de um candidato (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Busca o candidato pelo ID na lista (Model)
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato != null)
            {
                // Remove o candidato da lista (Model)
                candidatos.Remove(candidato);
            }
            // Redireciona para a lista de candidatos (View: Index.cshtml)
            return RedirectToAction("Index");
        }

        // GET: Candidato/Pesquisar
        // Action para exibir o formulário de pesquisa de candidatos (View: Pesquisar.cshtml)
        public IActionResult Pesquisar()
        {
            return View();
        }

        // POST: Candidato/Pesquisar
        // Action para processar a pesquisa de candidatos (POST)
        [HttpPost]
        public IActionResult Pesquisar(string termoPesquisa)
        {
            // Verifica se o termo de pesquisa foi fornecido
            if (string.IsNullOrEmpty(termoPesquisa))
            {
                ViewBag.Mensagem = "Por favor, insira um termo de pesquisa.";
                return View(new List<Candidato>());
            }

            // Realiza a pesquisa no nome e no número do partido (Model)
            var resultados = candidatos
                .Where(c => c.Nome.Contains(termoPesquisa, StringComparison.OrdinalIgnoreCase) ||
                            c.NumeroPartido.ToString().Contains(termoPesquisa))
                .ToList();

            // Exibe os resultados na view (View: Pesquisar.cshtml)
            return View(resultados);
        }
    }
}