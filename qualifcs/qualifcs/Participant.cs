using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace qualifcs
{
    public class Participant
    {
        public string Name { get; set; }
        public List<Competition> Preference { get; set; }
        public List<Competition> Assigne { get; set; }

        public int NbCompeAssigner {
            get { return Assigne.Count; }
        }

        public Participant(string name, List<Competition> preference)
        {
            Name = name;
            Preference = preference;
            Assigne = new List<Competition>();
        }

        public override string ToString()
        {
            return NbCompeAssigner + " | " + Name;
        }
    }
}
