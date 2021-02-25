using System;

namespace Game_Project
{
    public class Comp : Player
    {
        public Comp(string name = "comp") : base(name) { }
        public void calculate(Player enemy)
        {

            System.Random random = new System.Random();
            int decision = random.Next(2);

            if (bullets == 0)
                decision = random.Next(1);
            else if (enemy.bullets == 0)
            {
                decision = random.Next(1);
                if (decision == 1)
                    decision = 2;
            }

            switch (decision)
            {
                case 0:
                    reload();
                    break;
                case 1:
                    shield();
                    break;
                case 2:
                    shoot();
                    break;
                default:
                    Console.WriteLine("ERROR. Random is " + decision);
                    break;
            }
        }
    }
}