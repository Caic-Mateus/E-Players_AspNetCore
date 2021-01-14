using System;
using System.IO;
using E_Players_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNetCore_main.Controllers
{
    // http//localhost/Jogador
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        // Criamos uma instância jogadorModel com a estrutura Jogador
        Jogador jogadorModel = new Jogador();

        //httplocalhost/Listar
        [Route("ListarJogadores")]
        public IActionResult Index()

        
        {
            // Listando todas as equipes e enviando para a View, através da ViewBag

            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }

        //httplocalhost/CadastrarJogadores

        public IActionResult Cadastrar(IFormCollection form)
        {
            // Criamos uma nova instância de Equipe
            // e armazenamos os dados enviados pelo usuario
            // através do formulário
            // e salvamos no objeto novaEquipe

            Jogador novoJogador     = new Jogador();
            novoJogador.IdJogador   = Int32.Parse (form["IdJogador"]);
            novoJogador.Nome        = form ["Nome"];
            novoJogador.IdEquipe    = Int32.Parse (form["IdEquipe"]);

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();

            return LocalRedirect("~/Jogador/ListarJogadores");

                
            }
        }
    }
