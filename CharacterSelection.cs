
namespace Sulis_console_jatek
{
    class Character
    {
        public string name;
        public string character;
        public int health;
        public List<string> inventory = new List<string>();
        public string item_in_right_hand;
        public string item_in_left_hand;

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
                    this.inventory.Add("Kard");
                    this.inventory.Add("Pajzs");
                    this.item_in_left_hand = "Pajzs";
                    this.item_in_right_hand = "Kard";
                    break;
                case "Varázsló":
                    this.character = "Varázsló";
                    this.health = 70;
                    this.inventory.Add("Varázspálca");
                    this.inventory.Add("Könyv");
                    this.item_in_left_hand = "Könyv";
                    this.item_in_right_hand = "Varázspálca";
                    break;
                case "Béka":
                    this.character = "Béka";
                    this.health = 50;
                    this.inventory.Add("Nyelv");
                    this.inventory.Add("Béka_páncél");
                    this.item_in_right_hand = "Nyelv";
                    break;
                default:
                    Console.WriteLine("Érvénytelen karakter típus.");
                    break;
            }
        }
    }
}