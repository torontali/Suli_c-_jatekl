using System.Security.Cryptography;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Sulis_console_jatek
{

    class Controller
    {
        static void Main(string[] args)
        {
            Console.WriteLine("██████╗ ██████╗  █████╗  ██████╗  ██████╗ ███╗   ██╗\r\n██╔══██╗██╔══██╗██╔══██╗██╔════╝ ██╔═══██╗████╗  ██║\r\n██║  ██║██████╔╝███████║██║  ███╗██║   ██║██╔██╗ ██║\r\n██║  ██║██╔══██╗██╔══██║██║   ██║██║   ██║██║╚██╗██║\r\n██████╔╝██║  ██║██║  ██║╚██████╔╝╚██████╔╝██║ ╚████║\r\n╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝\r\n                         SLAYER");
            Console.WriteLine("             __====-_  _-====___\r\n         _--^^^#####//      \\\\#####^^^--_\r\n      _-^##########// (    ) \\\\##########^-_\r\n     -############//  |\\^^/|  \\\\############-\r\n   _/############//   (@::@)   \\\\############\\_\r\n  /#############((     \\\\//     ))#############\\\r\n -###############\\\\    (oo)    //###############-\r\n-#################\\\\  / \"\" \\  //#################-\r\n_#/|##########/\\######(   \"   )######/\\##########|\\#_\r\n |/ |#/\\#/\\#/\\/  \\#/\\##\\  !  /##/\\#/  \\/\\#/\\#/\\#| \\|\r\n '  |/  V  V '   V  \\\\#\\  !  /#/  V   '  V  V  \\|  '\r\n    '   '  '      '   / |  !  | \\   '      '  '   '\r\n                     (  |  !  |  )\r\n                    __\\ |  !  | /__\r\n                   (vvv(VVV)(VVV)vvv)");
            Console.WriteLine("");
            Console.WriteLine("");
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
            bolt.use_bolt_transaction(bolt_items,player_character);
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

        public void get_still_alive_check() {
             Still_alive_check();
        }

        private void Still_alive_check() {

            if (player_character.health <= 0)
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
                    Environment.Exit(0);
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
            else if(input == "nem") {
                Give_player_output("Majd legközelebb tovább jutsz!");
                Environment.Exit(0);
            }
        }
    }
}

