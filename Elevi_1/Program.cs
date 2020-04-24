using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Elevi_1
{
        public class Elev
        {
            public string nume { get; set; }
            public string prenume { get; set; }
            public float media { get; set; }
            public Elev(string nume, string prenume, float media)
            {
                this.nume = nume;
                this.prenume = prenume;
                this.media = media;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var Catalog = new List<Elev>();
                using (StreamReader sr = new StreamReader(@"C:\Users\DAIANA\Desktop\Facultă\An 1 sem 2\Programare orientata pe obiecte\Elevi_1\Elevi_1\input.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(' ');
                        float medie = 0;

                        for (int i = 0; i < int.Parse(words[2]); i++)
                        {
                            medie = medie + float.Parse(words[3 + i]);
                        }

                        medie = medie / float.Parse(words[2]);
                        var elev = new Elev(words[0], words[1], medie);
                        Catalog.Add(elev);
                    }
                    Catalog.Sort(delegate (Elev x, Elev y)
                    {
                        // Sortare desc dupa media
                        int a = y.media.CompareTo(x.media);
                        // Sortare cresc dupa nume
                        a = x.nume.CompareTo(y.nume);
                        // Sortare cresc dupa prenume
                        a = x.prenume.CompareTo(y.prenume);

                        return a;
                    });

                    using (StreamWriter writer = new StreamWriter(@"C:\Users\DAIANA\Desktop\Facultă\An 1 sem 2\Programare orientata pe obiecte\Elevi_1\Elevi_1\output.txt"))
                    {
                        foreach (var item in Catalog)
                        {
                            writer.WriteLine(item.media + " " + item.nume + " " + item.prenume);
                        }
                    }


                }
            }
        }
}
    

