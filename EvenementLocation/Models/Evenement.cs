using Ludotheque.EvenementLocation.Models;

namespace Ludotheque.EvenementLocation.Models{
    public class Evenement{

        public required string idEvenement{get; set;}
        public required string idUser{get; set;}
        public required string idJeu{get; set;}
        public TypeEvenement type { get; set; }
        public DateTime date{get; set;}    
            
    }   
}