using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNetCore_main.Interfaces;

namespace E_Players_AspNetCore.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        
         public int IdJogador { get; set; }
        public string Nome { get; set; }
        
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdEquipe { get; set; }
        private const string PATH = "Database/Jogador.csv";

        public Jogador(){
            CreateFolderAndFile(PATH);
        }

        public string Prepare( Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha};{j.IdEquipe}";
        }

        public void Create(Jogador j)
        {
            string [] linhas = {Prepare(j)};
            File.AppendAllLines(PATH,linhas);
        }
        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            //Removemos a linha que tenha o código a ser alterado

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            //Reescreve o csv com as alterações
            RewriteCSV(PATH,linhas);
        }
        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
              //  Ler todas as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

             //Percorrer as linhas e adicionar na lista de equipes cada objeto e 
             foreach (var item in linhas)
             {
                 // 1;VivoKeyd
                 string [] linha = item.Split(";");

                  // [0] = 1
                // [2] = VivoKeyd

                //Criamos o objeto Jogador
                Jogador jogador = new Jogador();

                //Alimentamos o obj jogador

                jogador.IdJogador = Int32.Parse(linha [0]);
                jogador.Nome = linha [1];
                jogador.Email = linha[2];
                jogador.Senha = linha[3];

                // adicionamos a equipe na lista de equipes

                jogadores.Add(jogador);

               


             }
                 return jogadores;


        }

        public void Update(Jogador j)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);

        //Removemos a linha que tenha o código a ser alterado

            linhas.RemoveAll(y => y.Split(";")[0] == j.IdJogador.ToString());

            //Adiciona a linha alterada no final do arquivo com mesmo código
            
            linhas.Add( Prepare(j));

            //Reescreve o csv com as alterações

            RewriteCSV(PATH, linhas);
        }

       
    }
}