using System;

namespace Game_Project
{
    public class Player
    {
        public string name;
        int startingHealth = 5, startingBullets = 0;
        public int health;
        internal int bullets;
        public Move curMove;

        public Player(string name = "you")
        {
            this.name = name;
            this.health = startingHealth;
            this.bullets = startingBullets;
        }

        public void reload()
        {
            curMove = Move.reload;
            bullets++;
            Console.WriteLine($"{name} reloaded! Total bullets: {bullets}");
        }

        public void shield()
        {
            curMove = Move.shield;
        }

        public bool shoot()
        {
            if (bullets == 0)
                return false;

            bullets--;
            Console.WriteLine($"{name} shot! Total bullets: {bullets}");
            curMove = Move.shoot;
            return true;
        }

        public void getShot(Player enemy)
        {
            string enemyName = enemy.name;

            if (curMove == Move.shield)
            {
                Console.WriteLine($"{enemyName} shot {name}, but {name} shielded!");
                return;
            }

            health--;
            Console.WriteLine($"{enemyName} shot {name}, {name} now has {health} hearts.");
        }
    }
}

public enum Move
{
    shoot,
    reload,
    shield
}