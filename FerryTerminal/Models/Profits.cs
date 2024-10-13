using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerryTerminal.Models
{
    internal class Profits
    {
        public int TotalProfits { get; set; }

        public double WorkerProfits { get; set; }

        public Profits() { 
        
            TotalProfits = 0;
            WorkerProfits = 0;
        }

    }
}
