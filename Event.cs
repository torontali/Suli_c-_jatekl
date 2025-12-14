using System;
using System.Threading.Channels;

namespace Sulis_console_jatek
{
    class Event
    {
        Random rnd = new Random();


        public void Random_event(Character player_character)
        {

            int random_number = rnd.Next(1, 171);


            if (random_number > 0 && random_number < 100)
            {
                this.Might_run(player_character);
            }
            else if (random_number >= 100 && random_number < 150)
            {
                this.Bolt_event(player_character);
            }
            else
            {
                this.Randomm_Treasure(player_character);
            }

        }

        private void Might_run(Character player_character)
        {
            Console.Clear();
            Enemy enemy = new Enemy(player_character.lvl);
            Console.WriteLine($"Egy {enemy.monsterName} áll veled szemben");
            Console.WriteLine($"Hp: {enemy.health}");
            Console.WriteLine($"Damage: {enemy.enemy_left_hand()}");
            Console.WriteLine($"Protection: {enemy.enemy_right_hand()}");
            Console.WriteLine("");
            Console.WriteLine("elfutsz vagy harcolsz ? (harc/futas)");
            string input = Console.ReadLine();

            switch (input)
            {

                case "futas":
                    int senity = rnd.Next(1, 3);
                    if (senity == 1)
                    {
                        player_character.health -= 10;
                        Console.WriteLine("Amiért ilyen gyáva vagy -10hp");
                    }
                    else
                    {
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
            Controller controller = new Controller();

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

            bool win = true;

            while (enemy.health > 0 && player_character.health > 0)
            {
                Console.WriteLine("__________________________________________");
                Console.WriteLine("Megtámadtad a szörnyet");
                does_the_attack_hit(1, enemy, player_character);
                if (enemy.health <= 0)
                {
                    Console.WriteLine("Legyőzted a szörnyet");
                    Console.WriteLine($"Megkatad a nála lévő goldot: {enemy.gold}");
                    Console.WriteLine("kaptál 20xp");
                    Console.WriteLine("kaptál +15hp");
                    break;
                }

                Console.WriteLine("__________________________________________");
                Console.WriteLine("A szörny megtámadott");
                does_the_attack_hit(0, enemy, player_character);
                if (player_character.health <= 0)
                {
                    win = false;
                    break;
                }

            }

            if (win)
            {

                int random_drop = who_starts_first();

                if (random_drop == 1)
                {
                    Console.WriteLine($"A szörny dobott neked egy tárgyat: {enemy.enemy_left_hand()}");
                    Console.WriteLine("Elviszed magaddal vagy ott hagyod ? (elviszem/ hagyom)");
                    string input = Console.ReadLine();

                    if (input == "elviszem")
                    {
                        foreach (var item in enemy.item_in_right_hand)
                        {
                            player_character.inventory.Add(item.Key, item.Value);
                        }
                    }

                    Console.WriteLine($"{player_character.inventory}");

                }
                else if (random_drop == 2 && enemy.enemy_right_hand() != "")
                {
                    Console.WriteLine($"A szörny dobott neked egy tárgyat: {enemy.enemy_right_hand()}");
                    Console.WriteLine("Elviszed magaddal vagy ott hagyod ? (elviszem/ hagyom)");
                    string input = Console.ReadLine();

                    if (input == "elviszem")
                    {
                        foreach (var item in enemy.item_in_left_hand)
                        {
                            player_character.inventory.Add(item.Key, item.Value);
                        }
                    }

                    Console.WriteLine($"{player_character.get_invetory()}");

                }
                else
                {
                    Console.WriteLine("A szörny nem dobott semmit");
                }


                this.player_revawrd_and_lvl_up(enemy, player_character);


            }
            else
            {
                controller.get_still_alive_check();
            }

        }


        private void player_revawrd_and_lvl_up(Enemy enemy, Character player_character)
        {

            player_character.gold += enemy.gold;
            player_character.xp += 20;
            player_character.health += 15;

            if (player_character.xp >= 40)
            {
                player_character.lvl += 1;
                player_character.xp = 0;
                player_character.health += 20;

                Console.Clear();
                Console.WriteLine("__________________________________________");
                Console.WriteLine("Gratulálok szintet léptél");
                Console.WriteLine("");
                Console.WriteLine("Jelenlegi statok:");
                Console.WriteLine("");


                Console.WriteLine($"+20 hp: {player_character.health}");
                Console.WriteLine($" jelenlegi pénzed: {player_character.gold}");
                Console.WriteLine($"Mostantól a szinted: {player_character.lvl}");
                Console.WriteLine($"inventory {player_character.get_invetory()}");

                Console.WriteLine("__________________________________________");
            }


        }


        private void does_the_attack_hit(int monster_or_player, Enemy enemy, Character player_character)
        {
            Console.Clear();
            int chance = rnd.Next(1, 1000);

            if (chance > 500)
            {
                
                switch (monster_or_player)
                {

                    case 0:
                        Console.Clear();
                        Console.WriteLine("__________________________________________");
                        Console.WriteLine("");
                        Console.WriteLine("A szörny eltalált ");
                        Console.WriteLine("");
                        Console.WriteLine("__________________________________________");

                        //valamiért csak így vesz el a hp-ból
                        // calculate attack and defense
                        int enemyAttack = enemy.item_in_left_hand.Values.Sum();
                        int playerDefense = player_character.item_in_left_hand.Values.Sum();

                        // damage cannot be negative (no healing when defense > attack)
                        int damage = Math.Max(0, enemyAttack - playerDefense);

                        // apply damage
                        player_character.health -= damage;

                        if (player_character.health <= 0)
                        {

                            return;
                        }
                        else
                        {
                           
                            Console.WriteLine($"Enyi hp-d maradt: {player_character.health}");
                            Console.WriteLine("__________________________________________");
                        }


                        Thread.Sleep(2000);
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("__________________________________________");
                        Console.WriteLine("");
                        Console.WriteLine("A szörnyet eltaláltad");
                        Console.WriteLine("");
                        Console.WriteLine("__________________________________________");

                        int playerAttack = player_character.item_in_right_hand.Values.Sum();
                        int enemyDefense = enemy.item_in_left_hand.Values.Sum();

                        int damageToEnemy = Math.Max(0, playerAttack - enemyDefense);

                        enemy.health -= damageToEnemy;

                        if (enemy.health <= 0)
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Enyi hp-ja maradt a szörnynek: {enemy.health}");
                            Console.WriteLine("__________________________________________");
                        }
                        Thread.Sleep(2000);
                        break;

                }


            }
            else
            {

                if (monster_or_player == 0)
                {
                    Console.Clear();
                    Console.WriteLine("__________________________________________");
                    Console.WriteLine("");
                    Console.WriteLine("A szörny nem talált el");
                    Console.WriteLine("");
                    Console.WriteLine("__________________________________________");
                    Thread.Sleep(2000);
                    return;
                } else if (monster_or_player == 1) { 
                    Console.Clear();
                    Console.WriteLine("__________________________________________");
                    Console.WriteLine("");
                    Console.WriteLine("Találatod Mellément");
                    Console.WriteLine("");
                    Console.WriteLine("__________________________________________");
                    Thread.Sleep(2000);
                }
            }



        }


        private int who_starts_first()
        {
            int first = rnd.Next(1, 5);
            return first;
        }



        private void item_change_in_hand(Enemy enemy, Character player_character)
        {

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


        private void Bolt_event(Character player_character)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Találtál egy boltot: ");
            Bolt bolt = new Bolt(2);
            Dictionary<string, int> bolt_items = bolt.get_bolt_random_items();

            foreach (var item in bolt_items.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - Védelem: {item.Value}");
            }
            bolt.use_bolt_transaction(bolt_items, player_character);


        }

        private void Randomm_Treasure(Character player_character)
        {
            Console.Clear();
            Bolt bolt = new Bolt(2);
            rnd = new Random();


            Dictionary<string, int> bolt_items = bolt.get_bolt_random_items();

            var random_wepon = bolt_items.ElementAt(rnd.Next(bolt_items.Count));
            Console.WriteLine($"Találtál egy tárgyat a földön: {random_wepon.Key} - Védelem/Sebzés: {random_wepon.Value}");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("elviszed magaddal? (igen/ nem)");
            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input) || (input != "igen" && input != "nem"))
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("hibás válasz. Próbáld ujra");
                input = Console.ReadLine();
            }


            if (input == "igen")
            {
                Console.WriteLine("Sikeresen elvitted a tárgyat");
                player_character.inventory.Add(random_wepon.Key, random_wepon.Value);
            }
            else
            {
                Console.WriteLine("Nem vittél el semmit");
            }
        }
    }
}
