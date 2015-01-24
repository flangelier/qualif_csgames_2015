using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace qualifcs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }


        List<Participant> lstParticipant = new List<Participant>();
        List<Competition> lstCompetition = new List<Competition>();

        public void loadLestiDeFichier(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject myObj = (JObject) JsonConvert.DeserializeObject(json);

                
                foreach (var comp in myObj["competitions"])
                {
                    lstCompetition.Add(new Competition(
                        comp["name"].ToString(),
                        ParseEnum<EnumDate>(comp["date"].ToString()),
                        ParseEnum<EnumTime>(comp["time"].ToString())
                        ));
                }

                List<Competition> lstPreference;
                foreach (var part in myObj["participants"])
                {
                    lstPreference = new List<Competition>();

                    string preference = part["preferences"].ToString();

                    string[] tmp = preference.Substring(1, preference.Length - 2).Split(',');
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        lstPreference.Add(lstCompetition[int.Parse(tmp[i])]);
                    }

                    lstParticipant.Add(new Participant(part["name"].ToString(), lstPreference));
                }
            }
        }


        private void btnload_Click(object sender, EventArgs e)
        {
            loadLestiDeFichier(txtpath.Text);
            RefreshListBox();
        }

        public void RefreshListBox()
        {
            var cSelect = lstboxCompe.SelectedItem;
            var pSelect = lstBoxPart.SelectedItem;

            lstboxCompe.Items.Clear();
            lstBoxPart.Items.Clear(); 
            foreach (var participant in lstParticipant)
            {
                lstBoxPart.Items.Add(participant);
            }
            foreach (var participant in lstCompetition)
            {
                lstboxCompe.Items.Add(participant);
            }

            lstboxCompe.SelectedItem = cSelect;
            lstBoxPart.SelectedItem = pSelect;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            Participant p = (Participant)lstBoxPart.SelectedItem;
            Competition c = (Competition)lstboxCompe.SelectedItem;

            if (p != null && c != null && c.AssignationDisponible > 0 && !p.Assigne.Contains(c) && !c.Assignation.Contains(p))
            {
                if (CompesDansListe(c, p.Assigne))
                    MessageBox.Show("T SAOUL! LE DUDE FAIT DEJA UNE COMPE A CE MOMENT LA! MAIS JE LAJOUTE PAREILLE!!!");
                if (p.NbCompeAssigner > 4)
                    MessageBox.Show("T SAOUL! LE DUDE A DEJA 4 COMPE! MAIS JE LAJOUTE PAREILLE!!!");
                if (!CompesDansListe(c, p.Preference))
                    MessageBox.Show("T SAOUL! CEST PAS UNE PREFERANCE DU DUDE! MAIS JE LAJOUTE PAREILLE!!!");
                
                c.Assignation.Add(p);
                p.Assigne.Add(c);
                RefreshListBox();
            }
            else
            {
                MessageBox.Show("T SAOUL TU PEUX PAS FAIRE CA CRISS!");
            }
        }

        private void lstBoxPart_DoubleClick(object sender, EventArgs e)
        {
            Participant p = (Participant)(((ListBox)sender).SelectedItem);

            StringBuilder toPrint = new StringBuilder(p.Name + Environment.NewLine + Environment.NewLine);
            toPrint.Append("Preference :" + Environment.NewLine);
            int i = 1;
            foreach (var compe in p.Preference)
            {
                toPrint.Append(i + ") " + compe.Name + Environment.NewLine);
                i++;
            }

            toPrint.Append(Environment.NewLine + "Assigne :" + Environment.NewLine);

            foreach (var compe in p.Assigne)
            {
                toPrint.Append((p.Preference.Contains(compe) ? "+" : "-") + compe.Name + Environment.NewLine);
            }

            MessageBox.Show(toPrint.ToString());
        }

        private void lstboxCompe_DoubleClick(object sender, EventArgs e)
        {
            Competition c = (Competition)(((ListBox)sender).SelectedItem);

            StringBuilder toPrint = new StringBuilder(c.Name + Environment.NewLine + Environment.NewLine);
            toPrint.Append("When :" + c.Date + " " + c.Time + Environment.NewLine);
            toPrint.Append("Assigne :" + Environment.NewLine);
            foreach (var assignation in c.Assignation)
            {
                toPrint.Append(assignation.Name + Environment.NewLine);
            }

            toPrint.Append("Preferance ordered :" + Environment.NewLine);
            Dictionary<Participant, int> dic = new Dictionary<Participant, int>();
            foreach (var pa in lstParticipant)
            {
                int index = pa.Preference.IndexOf(c);
                if (index != -1)
                {
                    dic.Add(pa, index);
                }
            }
            foreach (var kv in dic.OrderBy(d => d.Value))
            {
                toPrint.Append((kv.Value+1) + ") " + kv.Key.Name + Environment.NewLine);
            }

            MessageBox.Show(toPrint.ToString());
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            Participant p = (Participant)lstBoxPart.SelectedItem;
            Competition c = (Competition)lstboxCompe.SelectedItem;

            if (p != null && c != null && c.AssignationDisponible < 3 && p.NbCompeAssigner > 0)
            {
                if (c.Assignation.Contains(p) && p.Assigne.Contains(c))
                {
                    c.Assignation.Remove(p);
                    p.Assigne.Remove(c);
                    RefreshListBox();
                }
                else
                {
                    MessageBox.Show("T SAOUL TU PEUX PAS FAIRE CA CRISS!");
                }
            }
            else
            {
                MessageBox.Show("T SAOUL TU PEUX PAS FAIRE CA CRISS!");
            }
        }

        private void btnHoraire_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (EnumDate d in Enum.GetValues(typeof(EnumDate)))
            {
                foreach (EnumTime t in Enum.GetValues(typeof (EnumTime)))
                {
                    List<Competition> tmp = compeAtPlage(lstCompetition, d, t);
                    sb.Append(d + " " + t + ": " + Environment.NewLine);
                    foreach (var competition in tmp)
                    {
                        sb.Append("-- " + competition.Name + Environment.NewLine);
                        foreach (var p in competition.Assignation)
                        {
                            sb.Append("---- " + p.Name + Environment.NewLine);
                        }
                    }
                }
            }

            MessageBox.Show(sb.ToString());
        }

        public List<Competition> compeAtPlage(List<Competition> c, EnumDate d, EnumTime t)
        {
            List<Competition> ret = new List<Competition>();
            foreach (var competition in c)
            {
                if (competition.Date == d && competition.Time == t)
                {
                    ret.Add(competition);
                }
            }
            return ret;
        }

        public bool CompesDansListe(Competition c1, List<Competition> lstc)
        {
            foreach (var c in lstc)
            {
                if (c1.Date == c.Date && c1.Time == c.Time)
                    return true;
            }
            return false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in lstCompetition)
            {
                sb.Append(JsonConvert.SerializeObject(c, Formatting.Indented));
            }

            File.WriteAllText(@"compe.json", sb.ToString());
        }
    }
}
