using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Modele
{
    
    public class Karnet : ModelID
    {

        public string? NazwaKarnetu { get; set; }
        public double? CenaKarnetu { get; set; }

        public string? CzyKarnetJestAktywny { get; set; }

        public string? CzyKarnetJestOplacony { get; set; }

        public DateTime? DniDoZaplatyKarnetu { get; set; }


    }
}
