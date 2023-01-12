using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Modele
{
    public class Pracownik : ModelID
    {
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }

        public string? Email { get; set; }

        public string? NumerTelefonu { get; set; }

        public double Pensja { get; set; }

        public DateTime DataKoncaUmowy { get; set; }


    }
}
