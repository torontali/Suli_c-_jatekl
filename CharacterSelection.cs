
namespace Sulis_console_jatek
{
    class Character
    {
        public string name;
        public string character;
        public int health;
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public Dictionary<string, int> item_in_right_hand = new Dictionary<string, int>();
        public Dictionary<string, int> item_in_left_hand = new Dictionary<string, int>();
        public int gold = 20;
        public int xp = 0;
        public int lvl = 1;


        public string get_invetory() {

            var invetory_items = "";
            foreach (var item in this.inventory)
            {
                invetory_items += item.Key + " (" + item.Value + ") "; ;
            }
            return invetory_items;
        }

        public string get_right_hand()
        {
            string inventory_items = "";

            foreach (var item in item_in_right_hand)
            {
                inventory_items += item.Key + " (" + item.Value + ") ";
            }

            return inventory_items;
        }


        public string get_left_hand()
        {

            var invetory_items = "";
            foreach (var item in item_in_left_hand)
            {
                invetory_items += item.Key + " (" + item.Value + ") ";
            }
            return invetory_items;
        }


        public string get_right_hand_for_bolt() {
            var invetory_items = "";
            foreach (var item in item_in_right_hand)
            {
                invetory_items += item.Key;
            }
            return invetory_items;
        }

        public string get_left_hand_for_bolt()
        {
            var invetory_items = "";
            foreach (var item in item_in_left_hand)
            {
                invetory_items += item.Key;
            }
            return invetory_items;
        }



        public string[] character_types()
        {
            return new string[] { "Katona", "Varázsló", "Béka" };
        }

        public void set_charatecter(string name, string Charater_type)
        {
            this.name = name;
            this.character_creator(Charater_type);
        }

        private void character_creator(string Charater_type)
        {
            switch (Charater_type)
            {
                case "Katona":
                    this.character = "Katona";
                    this.health = 100;
                    this.inventory.Add("Kard", 30);
                    this.inventory.Add("Pajzs", 20);
                    this.item_in_left_hand.Add("Pajzs", 20);
                    this.item_in_right_hand.Add("Kard", 30) ;
                    break;
                case "Varázsló":
                    this.character = "Varázsló";
                    this.health = 70;
                    this.inventory.Add("Varázspálca" ,40);
                    this.inventory.Add("Könyv", 20);
                    this.item_in_left_hand.Add("Könyv", 20);
                    this.item_in_right_hand.Add("Varázspálca", 40);
                    break;
                case "Béka":
                    this.character = "Béka";
                    this.health = 50;
                    this.inventory.Add("Nyelv", 70);
                    this.inventory.Add("Béka_páncél", 10);
                    this.item_in_right_hand.Add("Nyelv", 70);
                    this.item_in_left_hand.Add("Béka_páncél", 10);
                    break;
                default:
                    Console.WriteLine("Érvénytelen karakter típus.");
                    break;
            }
        }
    }
}