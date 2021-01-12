using System;

namespace E_Players_AspNetCore.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int IdJogador1 { get; set; }
        public int IdJogador2 { get; set; }
        
        public DateTime HorarioDeInicio {get; set ;}
        public DateTime HorarioDeTérmino {get; set ;}
        
        
    }
}