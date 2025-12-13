using System.Threading.Channels;

namespace Sulis_console_jatek
{
    class Event
    {
        Random rnd = new Random();
       

        public void Random_event(int hp) {

            int random_number = rnd.Next(1, 4);

            switch (random_number) { 
            
                case 1 :
                    this.Might_run(hp);
                    break;

                case 2:
                    this.Bolt_event();
                    break;

                case 3:
                    this.Randomm_Treasure();
                    break;
            }

        }

        private void Might_run(int hp)
        {

            Enemy enemy = new Enemy();
            enemy.set_monster();
            Console.WriteLine( $" Egy {enemy.monsterName} áll veled szemben");
            Console.WriteLine("elfutsz vagy harcolsz ? (harc/futas)");
            string input = Console.ReadLine();

            switch (input) { 
            
                case "futas":
                    int senity = rnd.Next(1,3);
                    if (senity == 1) {
                        hp -= 10;
                        Console.WriteLine("Amiért ilyen gyáva vagy -10hp");
                    }
                    else {
                        Console.WriteLine("elfutottál");
                    }
                    break;

                case "harc":
                    this.Fight(); 
                    break;

            }

        }

        private void Fight() {

            Console.WriteLine("Elkezd harcolni");
        }

        private void Bolt_event()
        {
            Console.WriteLine("");
            Console.WriteLine("Találtál egy boltot: ");
            Controller controller = new Controller();
            Bolt bolt = new Bolt(2);
            Dictionary<string, int> bolt_items = bolt.get_bolt_random_items();

            foreach (var item in bolt_items.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - Védelem: {item.Value}");
            }
            controller.use_bolt_transaction(bolt_items);


        }

        private void Randomm_Treasure()
        {
            Console.WriteLine("treasure event");
        }
    }
}
