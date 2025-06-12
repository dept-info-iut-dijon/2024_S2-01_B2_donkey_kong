using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donkey_Kong_Metier
{
    public class Parameters
    {
        public Langues Langue { get; set; } = Langues.Français;
        public double Volume { get; set; } = 0.5;
        public bool EstMuet { get; set; } = false;
    }
}
