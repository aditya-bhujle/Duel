using System;

namespace Game_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to my game!");

            Player user = new Player();
            Comp comp = new Comp();

            while (user.health > 0 && comp.health > 0)
            {
                Console.WriteLine("Would you like to shoot, shield, or reload?");
                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "st":
                    case "shoot":
                        if (!user.shoot()){
                            Console.WriteLine("You have 0 bullets. You can't shoot.");
                            continue;
                        }
                        break;

                    case "sd":
                    case "shield":
                        user.shield();
                        break;

                    case "r":
                    case "reload":
                        user.reload();
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        continue;
                }

                comp.calculate(user);

                if (user.curMove == Move.shoot)
                    comp.getShot(user);

                if (comp.curMove == Move.shoot)
                    user.getShot(comp);
            }

            Console.WriteLine($"{(user.health <= 0 ? comp.name : user.name)} has won the game!");
        }
    }
}
