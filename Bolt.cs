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
        private int elso_bolt = 1;

        public Bolt(int bolt_tipus)
        {
            this.elso_bolt = bolt_tipus;
        }




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
            { "Istenpáncél", 120 },

            { "Csontkés", 8 },
            { "Obszidián tőr", 28 },
            { "Runás kard", 48 },
            { "Sárkánylándzsa", 68 },
            { "Titánbárd", 85 },
            { "Ősi varázspálca", 58 },
            { "Káosz kasza", 95 },
            { "Pusztító buzogány", 88 },
            { "Végzet dárda", 110 },

            { "Rituális köpeny", 22 },
            { "Runás mellvért", 38 },
            { "Obszidián páncél", 58 },
            { "Titán páncél", 72 },
            { "Káosz páncél", 85 },
            { "Sárkánykirály páncélja", 110 },
            { "Ősi isten vértje", 130 },
            { "Végzet páncél", 150 }
        };

        private void elso_bolt_random_item_generator()
        {
            
            bolt_random_items.Clear();

           
            var eligible = items.Where(kv => kv.Value < 21).ToList();
            var selected = eligible.OrderBy(_ => rnd.Next()).Take(Math.Min(5, eligible.Count));

            foreach (var kv in selected)
            {
                
                bolt_random_items[kv.Key] = kv.Value;
            }
        }

        private void bolt_random_item_generator()
        {
            
            bolt_random_items.Clear();

            var all = items.ToList();
            var selected = all.OrderBy(_ => rnd.Next()).Take(Math.Min(5, all.Count));

            foreach (var kv in selected)
            {
                bolt_random_items[kv.Key] = kv.Value;
            }
        }

        public Dictionary<string, int> get_bolt_random_items()
        {
            
            bolt_random_items.Clear();

            if (elso_bolt == 1)
            {
                this.elso_bolt_random_item_generator();
                
                elso_bolt = 0;
            }
            else
            {
                this.bolt_random_item_generator();
            }

            return this.bolt_random_items;
        }



        public void use_bolt_transaction(Dictionary<string, int> bolt_items , Character player_character)
        {
            bolt_transaction(bolt_items, player_character);
        }
        private void bolt_transaction(Dictionary<string, int> bolt_items, Character player_character)
        {
            Console.WriteLine("(ha nem akarsz semmit anyít írj egyiket sem ) Mit szeretnél venni a boltból? Add meg a tárgy nevét:");
            Console.WriteLine("");
            string input = Console.ReadLine();

            if (input == "nem" || input == "egyiket sem"){
                Console.WriteLine("Nem vettél semmit");
                return;
            }


            if (bolt_items.ContainsKey(input) == true)
            {
                int item_price = 10;
                if (bolt_items[input] > 20 && bolt_items[input] < 50)
                {
                    item_price = 30;
                }
                else if (bolt_items[input] > 50 && bolt_items[input] < 90)
                {
                    item_price = 70;
                }
                else if (bolt_items[input] > 90 && bolt_items[input] < 110)
                {
                    item_price = 160;
                }


                if (player_character.gold >= item_price)
                {
                    player_character.gold -= item_price;

                    foreach (var item in bolt_items)
                    {
                        if (item.Key == input)
                        {
                            player_character.inventory.Add(item.Key, item.Value);
                            break;
                        }
                    }


                    Console.WriteLine(player_character.get_invetory());
                    Console.WriteLine($"Sikeresen megvetted a {input}-t. Maradt pénzed: {player_character.gold}");


                    if (player_character.gold != 0)
                    {
                        Console.WriteLine($"Szeretnél még vásárolni? (igen/nem)");
                        input = Console.ReadLine();

                        if (input == "igen")
                        {
                            bolt_transaction(bolt_items, player_character);
                        }
                        else
                        {
                            Console.WriteLine("Köszönöm a vásárlást!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nincs elég pénzed ehhez a tárgyhoz.");
                    }
                }

            }
            else {
                Console.WriteLine("Ez a tárgy nem elérhető a boltban.");
                bolt_transaction(bolt_items, player_character);
            }
        }






    }
}
