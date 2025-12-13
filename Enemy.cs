using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulis_console_jatek
{
    class Enemy
    {

        public string monsterName;
        public int health;
        public List<string> inventory = new List<string>();
        public Dictionary<string, int> item_in_right_hand = new Dictionary<string, int>();
        public Dictionary<string, int> item_in_left_hand = new Dictionary<string, int>();
        public int gold = 20;


        public void set_monster()
        {
            int Monster_type = new Random().Next(1, 11);
            this.monster_creator(Monster_type);
        }

        private void monster_creator(int Monster_type)
        {
            switch (Monster_type)
            {
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

                case 10 :
                    this.monsterName = "Őrző szellem";
                    this.health = 100;
                    this.inventory.Add("Szellemcsapás");
                    this.inventory.Add("Árnyék pajzs");
                    this.item_in_left_hand = new Dictionary<string, int> { { "Árnyék pajzs", 20 } };
                    this.item_in_right_hand = new Dictionary<string, int> { { "Szellemcsapás", 40 } };
                    break;

                default:
                    Console.WriteLine("Érvénytelen szörny típus.");
                    break;
            }


        }
    }
}
