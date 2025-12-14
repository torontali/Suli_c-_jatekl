using System;
using System.Threading.Channels;

namespace Sulis_console_jatek
{
    class Event
    {
        Random rnd = new Random();
       

        public void Random_event(Character player_character) {

            int random_number = rnd.Next(1, 4);

            switch (random_number) { 
            
                case 1 :
                    this.Might_run(player_character);
                    break;

                case 2:
                    this.Bolt_event();
                    break;

                case 3:
                    this.Randomm_Treasure();
                    break;
            }

        }

        private void Might_run(Character player_character)
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
                        player_character.health -= 10;
                        Console.WriteLine("Amiért ilyen gyáva vagy -10hp");
                    }
                    else {
                        Console.WriteLine("elfutottál");
                    }
                    break;

                case "harc":
                    this.Fight(enemy, player_character); 
                    break;

            }

        }

        private void Fight(Enemy enemy, Character player_character)
        {
            this.item_change_in_hand(enemy, player_character);

            int enemy_attack = enemy.item_in_right_hand.Values.Sum();
            if (enemy.item_in_left_hand.Values.Sum() > 0)
            {
                int enemy_defense = enemy.item_in_left_hand.Values.Sum();
            }

            int player_attack = player_character.item_in_right_hand.Values.Sum();
            int player_defense = player_character.item_in_left_hand.Values.Sum();



            if (who_starts_first() == 1)
            {
                Console.WriteLine("Megtámadtad a szörnyet");
                does_the_attack_hit(1, enemy, player_character);
            }
            else
            {
                Console.WriteLine("A szörny megtámadott");
                does_the_attack_hit(0, enemy, player_character);
            }


            while (enemy.health > 0 && player_character.health > 0)
            {
                Console.WriteLine("Megtámadtad a szörnyet");
                does_the_attack_hit(1, enemy, player_character);
                if (enemy.health <= 0)
                {
                    Console.WriteLine("Legyőzted a szörnyet");
                    break;
                }

                Console.WriteLine("A szörny megtámadott");
                does_the_attack_hit(0, enemy, player_character);
                if (player_character.health <= 0)
                {
                    Console.WriteLine("Meghaltál");
                    break;
                }

            }
        }


        private void does_the_attack_hit(int monster_or_player , Enemy enemy, Character player_character) {
            int chance = rnd.Next(1, 1000);

            if (chance > 500)
            {
                switch (monster_or_player) { 
                
                    case 0:
                        Console.WriteLine("");
                        Console.WriteLine("A szörny eltalált ");
                        Console.WriteLine("");

                        //valamiért csak így vesz el a hp-ból
                        // calculate attack and defense
                        int enemyAttack = enemy.item_in_right_hand.Values.Sum();
                        int playerDefense = player_character.item_in_left_hand.Values.Sum();

                        // damage cannot be negative (no healing when defense > attack)
                        int damage = Math.Max(0, enemyAttack - playerDefense);

                        // apply damage
                        player_character.health -= damage;

                        if (player_character.health <= 0)
                        {
                            return;
                        }
                        else {
                            Console.WriteLine($"Enyi hp-d maradt: {player_character.health}");
                        }

                            
                       
                        break;

                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("A szörnyet eltaláltad");
                        Console.WriteLine("");

                        int playerAttack = player_character.item_in_right_hand.Values.Sum();
                        int enemyDefense = enemy.item_in_left_hand.Values.Sum();

                        int damageToEnemy = Math.Max(0, playerAttack - enemyDefense);

                        enemy.health -= damageToEnemy;

                        if (enemy.health <= 0)
                        {
                            return;
                        }else {
                            Console.WriteLine($"Enyi hp-ja maradt a szörnynek: {enemy.health}");
                        }

                        break;

                }


            }
            else {
                Console.WriteLine("");
                Console.WriteLine("Miss");
                Console.WriteLine("");
            
            }



        }


        private int who_starts_first() {
            int first = rnd.Next(1, 3);
            return first;
        }



        private void item_change_in_hand(Enemy enemy, Character player_character) {

            Console.WriteLine($"Ezek a fegyverek vannak a kezedbe : {player_character.get_right_hand()} , {player_character.get_left_hand()}");
            Console.WriteLine($"Ezek vannak az inventoridba: {player_character.get_invetory()}");
            Console.WriteLine($"Leszeretnéd cserélni valamelyiket? (igen/nem)");
            string input = Console.ReadLine();

            if (player_character.inventory.Count > 2 && input == "igen")
            {

                if (input == "igen")
                {
                    Console.WriteLine("Melyik kezedből akarod lecserélni? (jobb/bal) ");
                    input = Console.ReadLine();

                    if (input == "jobb")
                    {
                        Console.WriteLine("Ezekre a tárgyakra tudod lecserélni: ");
                        Dictionary<string, int> available_items = new Dictionary<string, int>();
                        foreach (var item in player_character.inventory)
                        {
                            if (!player_character.item_in_right_hand.ContainsKey(item.Key) && !player_character.item_in_left_hand.ContainsKey(item.Key))
                            {
                                Console.WriteLine($"{item.Key} - Sebzés: {item.Value}");
                                available_items.Add(item.Key, item.Value);
                            }
                        }

                        while (true)
                        {
                            Console.WriteLine("Melyik Tárgyra szeretnéd lecserélni?");
                            input = Console.ReadLine();

                            if (available_items.TryGetValue(input, out var value))
                            {
                                player_character.item_in_left_hand.Clear();
                                player_character.item_in_left_hand.Add(input, value);
                                Console.WriteLine($"Sikeresen lecserélted a bal kezedben lévő tárgyat {input}-re");

                                Console.WriteLine("");
                                Console.WriteLine("");


                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen tárgy az inventoridba válassz másikat");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                        }

                    }
                    else if (input == "bal")
                    {

                        Console.WriteLine("Ezekre a tárgyakra tudod lecserélni: ");
                        Dictionary<string, int> available_items2 = new Dictionary<string, int>();
                        foreach (var item in player_character.inventory)
                        {
                            if (!player_character.item_in_right_hand.ContainsKey(item.Key) && !player_character.item_in_left_hand.ContainsKey(item.Key))
                            {
                                Console.WriteLine($"{item.Key} - Sebzés: {item.Value}");
                                available_items2.Add(item.Key, item.Value);
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Melyik Tárgyra szeretnéd lecserélni?");
                            input = Console.ReadLine();

                            if (available_items2.TryGetValue(input, out var value))
                            {
                                player_character.item_in_left_hand.Clear();
                                player_character.item_in_left_hand.Add(input, value);
                                Console.WriteLine($"Sikeresen lecserélted a bal kezedben lévő tárgyat {input}-re");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nincs ilyen tárgy az inventoridba válassz másikat");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                        }

                    }
                }

            }
            else
            {
                Console.WriteLine("Sajnos nicsen másik tárgyad amire letudnád cserélni a mostanit :(");
            }







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
