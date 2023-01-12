using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Modele
{
    public class Klient : ModelID
    {

        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }

        public DateTime DataUrodzenia { get; set; }

        public string? Email { get; set; }
        public Karnet? Karnet { get; set; }

        public int LiczbaWejscNaSilownie { get; set; }


        //public Klient(string imie, string nazwisko, DateTime data_urodzenia, string email, int wejscia)
        //{
        //    Imie = imie;
        //    Nazwisko = nazwisko;
        //    DataUrodzenia = data_urodzenia;
        //    Email = email;
        //   // Karnet = karnet;
        //    LiczbaWejscNaSilownie = wejscia;
        //}

        //public Klient()
        //{
        //}
    }
