using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qualifcs;

namespace qualifcs
{
    public class Competition
    {
        public string Name { get; set; }
        public EnumDate Date { get; set; }
        public EnumTime Time { get; set; }
        public List<Participant> Assignation { get; set; }
        public int AssignationDisponible {
            get { return 3 - Assignation.Count; }
        }  

        
        public Competition(string name, EnumDate date, EnumTime time)
        {
            Name = name;
            Date = date;
            Time = time;
            Assignation=new List<Participant>(3);
        }

        public override string ToString()
        {
            return AssignationDisponible + " | " + Name;
        }
    }
}
