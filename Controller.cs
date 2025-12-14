using System.Security.Cryptography;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Sulis_console_jatek
{

    class Controller
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Give_player_output("A játék elkezdődőtt. Add meg a neved: ");
            controller.game_control();

        }


        private Character player_character = new Character();


        public void game_control()
        {
            this.Name_and_charachter_selection();
            this.Start_game();
            this.Game_progession();
        }

        public void Give_player_output(string msg)
        {
            Console.WriteLine($"{msg}");
        }

        public string Get_player_input()
        {
            return Console.ReadLine();
        }

        private void Name_and_charachter_selection()
        {
            string input = this.Get_player_input();
            string name = input;

            string[] types = player_character.character_types();
            string choose_character = "";

            foreach (string type in types)
            {
                choose_character += type + ",";
            }

            Give_player_output($"Add meg milyen charactert szeretnél {choose_character}:");
            input = this.Get_player_input();
            string Charater_type = input;

            player_character.set_charatecter(name, Charater_type);


        }

        public void use_bolt_transaction(Dictionary<string, int> bolt_items)
        {
            bolt_transaction(bolt_items);
        }
        private void bolt_transaction(Dictionary<string, int> bolt_items)
        {
            Give_player_output("(ha nem akarsz semmit anyít írj egyiket sem ) Mit szeretnél venni a boltból? Add meg a tárgy nevét:");
            string input = this.Get_player_input();

            if (input == "egyiket sem")
            {
                Give_player_output("Nem vásároltál semmit.");
                return;
            }



            if (bolt_items.ContainsKey(input))
            {
                int item_price = 10;
                if (bolt_items[input] > 20)
                {
                    item_price = 30;
                }
                else if (bolt_items[input] > 50)
                {
                    item_price = 70;
                }
                else if (bolt_items[input] > 90)
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



                    Give_player_output(player_character.get_invetory());
                    Give_player_output($"Sikeresen megvetted a {input}-t. Maradt pénzed: {player_character.gold}");

                    if (player_character.gold != 0)
                    {
                        Give_player_output($"Szeretnél még vásárolni? (igen/nem)");
                        input = this.Get_player_input();

                        if (input == "igen")
                        {
                            bolt_transaction(bolt_items);
                        }
                        else
                        {
                            Give_player_output("Köszönöm a vásárlást!");
                        }
                    }
                    else
                    {
                        Give_player_output("Nincs elég pénzed ehhez a tárgyhoz.");
                    }
                }
                else
                {
                    Give_player_output("Ez a tárgy nem elérhető a boltban.");
                }
            }
        }


        private void Start_game()
        {
            Bolt bolt = new Bolt(1);
            Dictionary<string, int> bolt_items = bolt.get_bolt_random_items();

            Give_player_output($"Gratulálok: {player_character.name} Ezt a karakterrt választottad: {player_character.character} ");
            Give_player_output($"Enyi Hp-ja van a karaktenek {player_character.health}");
            Give_player_output($"Tárgyaid : {player_character.get_invetory()}");
            Give_player_output($"A játék eleéj vagy itt mindig egy bolta fogsz kezdeni.");
            Give_player_output($"jelenleg enyi pénezd van amit eltudsz költeni a boltba: {player_character.gold}");
            Give_player_output("");
            Give_player_output("FONTOS: Ha az itemn több péncél vagy sebzés ad mint 20 akkor annak azára 30 gold , ha 50 akkor 70 gold , ha 90 akkor 160 gold ");
            Give_player_output("");
            Give_player_output("A bolt most ezeket kínálja fel neked:");

            foreach (var item in bolt_items.OrderByDescending(x => x.Value))
            {
                Give_player_output($"{item.Key} - Védelem: {item.Value}");
            }
            bolt_transaction(bolt_items);
        }



        private void Game_progession()
        {
            Event game_event = new Event();

            Give_player_output("");
            Give_player_output("");
            Random rnd = new Random();
            int random_number = rnd.Next(1, 7);
            switch (random_number)
            {

                case 1:
                    Give_player_output("Elindultál egy uton");
                    break;
                case 2:
                    Give_player_output("Beléptél az előtted húzódó útra");
                    break;
                case 3:
                    Give_player_output("elfordultál jobbra egy utra");
                    break;
                case 4:
                    Give_player_output("elfordultál balra egy utra");
                    break;
                case 5:
                    Give_player_output("Egyenesen mész tovább");
                    break;
                case 6:
                    Give_player_output("Magad mögé néztél");
                    break;
            }

            game_event.Random_event(player_character);
            Still_alive_check();

        }


            private void Still_alive_check() {

            if (player_character.health == 0)
            {
                Give_player_output("");
                Give_player_output("");
                Give_player_output("Meghaltál játéknak vége.");

                Give_player_output("");
                Give_player_output("");
                Give_player_output("Szeretnéd ujjra kezdeni ? (igen/ nem)");

                string input2 = this.Get_player_input();
            
                if (input2 == "igen"){
                    Controller controller = new Controller();
                    controller.Give_player_output("A játék elkezdődőtt. Add meg a neved: ");
                    controller.game_control();
                }
                else {
                    return;
                }
     
            }

            

            Give_player_output("Folytatod az utad? (igen/nem)");
            string input = this.Get_player_input();

            if (input == "igen")
            {
                Give_player_output("");
                Give_player_output("");
                this.Game_progession();
            }
            else {
                Give_player_output("Majd legközelebb tovább jutsz!");
            }
        }
    }
}

