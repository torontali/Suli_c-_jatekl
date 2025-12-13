using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sulis_console_jatek
{
    class Bolt
    {
        Random rnd = new Random();
        private bool elso_bolt = true;


        private Dictionary<string, int> bolt_random_items = new Dictionary<string, int>();

        Dictionary<string, int> items = new Dictionary<string, int>{
            { "Rozsdás tőr", 5 },
            { "Fa bot", 7 },
            { "Kőbalta", 10 },
            { "Vadász íj", 12 },
            { "Vas kard", 15 },
            { "Lándzsa", 17 },
            { "Csatabárd", 20 },
            { "Hosszúkard", 22 },
            { "Harci kalapács", 25 },
            { "Keresztíj", 27 },

            { "Mágikus pálca", 30 },
            { "Tűzgömb tekercs", 32 },
            { "Jégkard", 35 },
            { "Villám dárda", 37 },
            { "Sötét tőr", 40 },
            { "Árnyék kard", 42 },
            { "Mérgezett penge", 45 },
            { "Ősi lándzsa", 47 },
            { "Démon balta", 50 },
            { "Szent buzogány", 52 },

            { "Sárkányfog kard", 55 },
            { "Fagy íj", 57 },
            { "Vihar kalapács", 60 },
            { "Vérivó tőr", 62 },
            { "Káosz kard", 65 },
            { "Halál kasza", 70 },
            { "Legenda lándzsa", 75 },
            { "Időpenge", 80 },
            { "Istenölő kard", 100 },

             { "Kopott ruházat", 2 },
            { "Bőr mellvért", 4 },
            { "Vadász köpeny", 5 },
            { "Bőrpáncél", 7 },
            { "Erősített bőrpáncél", 9 },
            { "Bronz mellvért", 11 },
            { "Láncing", 13 },
            { "Láncing sisakkal", 15 },
            { "Vas mellvért", 18 },
            { "Vas páncél szett", 20 },

            { "Acél mellvért", 23 },
            { "Acél páncél szett", 26 },
            { "Lovagi páncél", 30 },
            { "Őrző páncél", 33 },
            { "Szent páncél", 36 },
            { "Sötét lovag páncélja", 40 },
            { "Mágus köpeny", 18 },
            { "Ősi páncél", 45 },
            { "Sárkánypikkely páncél", 50 },
            { "Démoni páncél", 55 },

            { "Fagyott páncél", 60 },
            { "Tűzálló páncél", 62 },
            { "Villámvédő páncél", 65 },
            { "Időpáncél", 70 },
            { "Árnyék páncél", 75 },
            { "Halhatatlan páncél", 80 },
            { "Legenda páncél", 90 },
            { "Ősi király páncélja", 100 },
            { "Istenpáncél", 120 }
        };

        private void elso_bolt_random_item_generator()
        {

            int i = 0;

            while (this.bolt_random_items.Count < 5 )
            {
                var item = items.ElementAt(rnd.Next(1,items.Count));

                if (item.Value < 21) {
                    foreach (var ne_legyen_2_ugyan__olyan_item in this.bolt_random_items)
                    {
                        if (ne_legyen_2_ugyan__olyan_item.Key == item.Key)
                        {
                            item = items.ElementAt(rnd.Next(1, items.Count));
                        }
                    }

                    this.bolt_random_items.Add(item.Key, item.Value);
                }
                i++;
            }


        }

        private void bolt_random_item_generator()
        {
            int i = 0;

            while (this.bolt_random_items.Count < 5)
            {
                var item = items.ElementAt(rnd.Next(1,items.Count));
                this.bolt_random_items.Add(item.Key, item.Value);
                
                i++;
            }

        }


        public Dictionary<string, int> get_bolt_random_items()
        {
            if (elso_bolt == true) { 
                this.elso_bolt_random_item_generator();
                elso_bolt = false;
            } else
            {
                this.bolt_random_item_generator();
            }

            return this.bolt_random_items;
        }




    }
}
