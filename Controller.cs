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
        Bolt bolt = new Bolt();

        public void game_control()
        {
            this.Name_and_charachter_selection();
            this.Start_game();
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
            string name = input; // Example of using the input as a name

            string[] types = player_character.character_types();
            string choose_character = "";

            foreach (string type in types)
            {
                choose_character += type + ",";
            }

            string msg = $"Add meg milyen charactert szeretnél {choose_character}:";
            Give_player_output(msg);
            input = this.Get_player_input();
            string Charater_type = input;

            player_character.set_charatecter(name, Charater_type);
            // Use the correct method name and return type

        }

        private void Start_game()
        {
            Give_player_output($"Gratulálok: {player_character.name} Ezt a karakterrt választottad: {player_character.character} ");
            Give_player_output($"Tárgyaid : {player_character.inventory}");
            Give_player_output($"A játék eleéj vagy itt mindig egy bolta fogsz kezdeni.");
            Give_player_output($"jelenleg enyi pénezd van amit eltudsz költeni a boltba: {player_character.gold}");
            Give_player_output($" A boltb most ezeket kínálja fel neked: {bolt.get_bolt_random_items()} ");



        }
    }
}

