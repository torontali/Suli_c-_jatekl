using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulis_console_jatek
{
    class Enemy
    {
        public Enemy(int palyer_lvl)
        {
            set_monster(palyer_lvl);
        }

        public string monsterName;
        public int health;
        public List<string> inventory = new List<string>();
        public Dictionary<string, int> item_in_right_hand = new Dictionary<string, int>();
        public Dictionary<string, int> item_in_left_hand = new Dictionary<string, int>();
        public int gold = 20;


        public void set_monster(int player_lvl)
        {
            int Monster_type;
            if (player_lvl < 3){

                Monster_type = new Random().Next(1, 11);
                this.monster_creator(Monster_type);
            }
            else if (player_lvl >= 3 && player_lvl < 6){

                Monster_type = new Random().Next(11, 16);
                this.monster_creator(Monster_type);

            }
            else if (player_lvl >= 6 && player_lvl < 9){

                Monster_type = new Random().Next(16, 20);
                this.monster_creator(Monster_type);
            }
            else{
                Monster_type = new Random().Next(20, 26);
                this.monster_creator(Monster_type);
            }
        }

        public string enemy_right_hand()
        {
            string inventory_items = "";
            foreach (var item in item_in_right_hand)
            {
                inventory_items += item.Key + " (" + item.Value + ") ";
            }
            return inventory_items;
        }

        public string enemy_left_hand()
        {
            var invetory_items = "";
            foreach (var item in item_in_left_hand)
            {
                invetory_items += item.Key + " (" + item.Value + ") ";
            }
            return invetory_items;
        }



        private void monster_creator(int Monster_type)
        {
            switch (Monster_type)
            {
                // ===== KEZDŐ SZINTEK =====
                case 1:
                    this.monsterName = "Troll";
                    this.health = 120;
                    this.inventory.Add("Kövesszörny");
                    this.inventory.Add("Fogak");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Fogak", 25 } };
                    break;

                case 2:
                    this.monsterName = "Medúza";
                    this.health = 70;
                    this.inventory.Add("Tekintet");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Tekintet", 25 } };
                    break;

                case 3:
                    this.monsterName = "Vadász Lélek";
                    this.health = 80;
                    this.inventory.Add("Árnyék kard");
                    this.inventory.Add("Kísértet páncél");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Kísértet páncél", 20 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Árnyék kard", 50 } };
                    break;

                case 4:
                    this.monsterName = "Zombi";
                    this.health = 60;
                    this.inventory.Add("Rohadó kéz");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Rohadó kéz", 15 } };
                    break;

                case 5:
                    this.monsterName = "Vámpír";
                    this.health = 90;
                    this.inventory.Add("Álcsípés");
                    this.inventory.Add("Karmok");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Vámpír Karmok", 20 } };
                    break;

                case 6:
                    this.monsterName = "Gólem";
                    this.health = 150;
                    this.inventory.Add("Kőkéz");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Kőkéz", 30 } };
                    break;

                case 7:
                    this.monsterName = "Sziklaóriás";
                    this.health = 180;
                    this.inventory.Add("Szikla");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Szikla", 40 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Szikla", 40 } };
                    break;

                case 8:
                    this.monsterName = "Démon";
                    this.health = 130;
                    this.inventory.Add("Tűzkard");
                    this.inventory.Add("Lángszarv");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Lángszarv", 35 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Tűzkard", 50 } };
                    break;

                case 9:
                    this.monsterName = "Sárkány";
                    this.health = 200;
                    this.inventory.Add("Tűzlehelet");
                    this.inventory.Add("Karmok");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Karmok", 40 } };
                    break;

                case 10:
                    this.monsterName = "Őrző szellem";
                    this.health = 100;
                    this.inventory.Add("Szellemcsapás");
                    this.inventory.Add("Árnyék pajzs");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Árnyék pajzs", 20 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Szellemcsapás", 40 } };
                    break;

                // ===== ERŐS SZINTEK =====
                case 11:
                    this.monsterName = "Démon";
                    this.health = 130;
                    this.inventory.Add("Tűzkard");
                    this.item_in_right_hand = new Dictionary<string, int> { { "Tűzkard", 50 } };
                    break;

                case 12:
                    this.monsterName = "Árnylovag";
                    this.health = 140;
                    this.inventory.Add("Sötétkard");
                    this.item_in_right_hand = new Dictionary<string, int> { { "Sötétkard", 55 } };
                    break;

                case 13:
                    this.monsterName = "Gólem";
                    this.health = 150;
                    this.inventory.Add("Kőkéz");
                    this.item_in_right_hand = new Dictionary<string, int> { { "Kőkéz", 30 } };
                    break;

                case 14:
                    this.monsterName = "Tűz Elementál";
                    this.health = 160;
                    this.inventory.Add("Lángcsapás");
                    this.item_in_right_hand = new Dictionary<string, int> { { "Lángcsapás", 60 } };
                    break;

                case 15:
                    this.monsterName = "Jég Elementál";
                    this.health = 165;
                    this.inventory.Add("Fagycsapás");
                    this.item_in_right_hand = new Dictionary<string, int> { { "Fagycsapás", 62 } };
                    break;


                // ===== ELIT SZINTEK =====
                case 16:
                    this.monsterName = "Sziklaóriás";
                    this.health = 180;
                    this.inventory.Add("Szikla");
                    this.inventory.Add("Kőpajzs");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Kőpajzs", 30 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Szikla", 40 } };
                    break;

                case 17:
                    this.monsterName = "Sárkányivadék";
                    this.health = 190;
                    this.inventory.Add("Tűzlehelet");
                    this.inventory.Add("Karmok");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Karmok", 35 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Tűzlehelet", 65 } };
                    break;

                case 18:
                    this.monsterName = "Halálmágus";
                    this.health = 200;
                    this.inventory.Add("Halálkönyv");
                    this.inventory.Add("Sötétbot");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Halálkönyv", 40 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Sötétbot", 70 } };
                    break;

                case 19:
                    this.monsterName = "Ősi Démon";
                    this.health = 220;
                    this.inventory.Add("Pokolkarom");
                    this.inventory.Add("Démonpajzs");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Démonpajzs", 45 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Pokolkarom", 75 } };
                    break;

                // ===== BOSS SZINTEK =====
                case 20:
                    this.monsterName = "Sárkány";
                    this.health = 250;
                    this.inventory.Add("Karmok");
                    this.inventory.Add("Sárkánypikkely");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Sárkánypikkely", 50 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Karmok", 80 } };
                    break;

                case 21:
                    this.monsterName = "Káosz Lovag";
                    this.health = 270;
                    this.inventory.Add("Káoszpenge");
                    this.inventory.Add("Káoszpajzs");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Káoszpajzs", 55 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Káoszpenge", 85 } };
                    break;

                case 22:
                    this.monsterName = "Ősi Titán";
                    this.health = 300;
                    this.inventory.Add("Titánököl");
                    this.inventory.Add("Ősi Pajzs");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Ősi Pajzs", 60 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Titánököl", 90 } };
                    break;

                case 23:
                    this.monsterName = "Világfaló";
                    this.health = 350;
                    this.inventory.Add("Semmítés");
                    this.inventory.Add("Ürességpajzs");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Ürességpajzs", 70 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Semmítés", 100 } };
                    break;

                case 24:
                    this.monsterName = "Sötét Isten";
                    this.health = 400;
                    this.inventory.Add("Isteni Harag");
                    this.inventory.Add("Sötét Aura");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Sötét Aura", 80 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Isteni Harag", 120 } };
                    break;

                case 25:
                    this.monsterName = "Végzet Megtestesítője";
                    this.health = 500;
                    this.inventory.Add("Végső Védelem");
                    this.inventory.Add("Végső Csapás");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Végső Védelem", 100 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Végső Csapás", 150 } };
                    break;


                default:
                    Console.WriteLine("Érvénytelen szörny típus.");
                    break;
            }


        }
    }
}
