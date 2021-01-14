using System;
using System.IO;
using E_Players_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNetCore.Controllers
{
    // http://localhost:500/Equipe
    [Route("Equipe")]
    public class EquipeController : Controller
    {

        // Criamos uma instância equipeModel com a estrutura Equipe
        Equipe equipeModel = new Equipe();
        
        //htpplocalhost/listar
        [Route("Listar")]
        public IActionResult Index()
        
        {
            // Listando todas as equipes e enviando para a View, através da ViewBag
           
           
           
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        //httplocalhost/cadastrar
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            // Criamos uma nova instância de Equipe
            // e armazenamos os dados enviados pelo usuario
            // através do formulário
            // e salvamos no objeto novaEquipe
            

            

            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse (form["IdEquipe"] );
            novaEquipe.Nome     = form ["Nome"];
            
            // Upload Imagem Inicio

            //Verificamos se o usuario anexou um arquivo
            if (form.Files.Count>0)

            {
                //Se sim
                //Armazenamos o arquivo na var file
                var file    = form.Files[0];    
                var folder  = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Equipes" );

                //Verificamos se a pasta não existe
                if (!Directory.Exists(folder))
                {
                    //Se não existe, criamos
                    Directory.CreateDirectory(folder);
                }
                                                    //localhost:5001    +                +Equipes + Nome Arquivo (equipe.png)
                var path = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/", folder , file.FileName );

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Salvamos o arquivo no caminho especificado
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.png";
            }
           // Upload Término

            //Chamamos o método Create para salvar 
            //a novaEquipe no CSV

            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

        //httpslocalhost/Equipe/1
        [Route("{id}")]

        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);

            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}