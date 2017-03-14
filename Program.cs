using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing the Code
            MainGame game = new MainGame();
            Console.WriteLine("Hello " + game.GetName());
            Console.WriteLine("Your current MaxHP is: " + game.GetMaxHP());
            Console.WriteLine("Congrats you leveled up!");
            game.LevelUp();
            Console.WriteLine("Your current level is now: " + game.GetLevel());
            Console.WriteLine("Your current MaxHP is: " + game.GetMaxHP());
            Console.ReadLine();
            Console.Clear();
            game.DisplayHealth();
            game.StartBattle();
            game.DisplayHealth();

        }
    }

    public class MainGame
    {
        Player player = new Player();
        Random rnd = new Random();
        //This Enemy instance is for testing
        //Don't know how to create an enemy when I encounter one
        Enemy enemy = new Enemy("Bob", 1, 30, 30, 15, 6);
        public MainGame()
        {
            Console.WriteLine("What is your name? ");
            Console.WriteLine();
            player.name = Console.ReadLine();
        }
        public int GetMaxHP()
        {
            return this.player.MaxHP;
        }
        public string GetName()
        {
            return this.player.name;
        }
        public void LevelUp()
        {
           this.player.LevelUp();
        }
        public int GetLevel()
        {
         return   this.player.level;
        }
        public int GetPlayerDmg()
        {
            int playerDmg = rnd.Next(player.minDmg, player.maxDmg);
            return playerDmg;
        }
        public int GetEnemyDmg()
        {
            int enemyDmg = rnd.Next(enemy.minDmg, enemy.maxDmg);
            return enemyDmg;
        }
       /* public void GetEnemy()
        {
            Enemy enemy = new Enemy("Bob",1,30,30,15,6);
        } */
        public void StartBattle()
        {
            int enemyDmg = GetEnemyDmg();
            int playerDmg = GetPlayerDmg();
            Console.WriteLine("{0} does {1}dmg to {2}",player.name,playerDmg,enemy.name);
            Console.WriteLine("{0} does {1}dmg to {2}",enemy.name,enemyDmg,player.name);
            player.CurrentHP -= enemyDmg;
            enemy.CurrentHP -= playerDmg;
        }
        public void DisplayHealth()
        {
            Console.WriteLine(player.name + ": {0}/{1}HP",player.CurrentHP,player.MaxHP);
            Console.WriteLine(enemy.name + " {0}/{1}HP",enemy.CurrentHP,enemy.MaxHP);
        }


    }

   public class Player
    {
        public string name { get; set; }
        public int gold { get; set; }
        public int exp { get; set; }
        public int level { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int maxDmg = 10;
        public int minDmg = 4;
        public Random rnd = new Random();

        
        public Player()
        {
            level = 1;
            gold = 0;
            exp = 0;
            MaxHP = 40;
            CurrentHP = 40;
        }

        public void LevelUp()
        {
            this.MaxHP += rnd.Next(5, 10);
            this.maxDmg += rnd.Next(6, 12);
            this.minDmg += rnd.Next(4, 8);
            CurrentHP = MaxHP;
            level++;

        }

    }

    public class Enemy
    {
        public string name { get; set; }
        public int level { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int maxDmg { get; set; }
        public int minDmg { get; set; }
        
        public Enemy(string name,int level,int maxHP,int currentHP, int maxDmg, int minDmg)
        {
            this.name = name;
            this.level = level;
            this.MaxHP = maxHP;
            this.CurrentHP = currentHP;
            this.maxDmg = maxDmg;
            this.minDmg = minDmg;
        }
        

    }


    class UI
    {
        public void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("==     Welcome to Text RPG     ==");
            Console.WriteLine("=================================");

        }

        public void Controls()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Attack");
            Console.WriteLine("Explore");
            Console.WriteLine("Search");
            Console.WriteLine("================================");

        }
    }

}

