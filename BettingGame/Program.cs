using System;

namespace BettingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = .75;
            Guy player = new Guy() { Cash = 100, Name = "The Player" };

            // print a message welcoming the user to the screen
            Console.WriteLine("Welcome to the Casino! The odds are " + odds);

            // the program keeps running while the player has cash
            while (player.Cash > 0)
            {
                // have the Guy object print the amount of cash it 
                player.WriteMyInfo();
                // ask the user how much they want to bet
                Console.Write("How much would you like to bet: ");
                string howMuch = Console.ReadLine();
                // parse the howMuch variable into an int variable named amount
                if (int.TryParse(howMuch, out int amount))  // if the conversion was successful
                {
                    // the player gives the amount to the Pot. It gets multiplied by 2
                    // because it is a double or nothing bet
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        // the program picks a number between 0 and 1
                        // if the number is greater than odds, the player receives the pot
                        if (random.NextDouble() > odds)  // random.NextDouble generates a number from 0 to 1
                        {
                            int winnings = pot;
                            Console.WriteLine("You win: " + winnings);
                            player.ReceiveCash(winnings);
                        }
                        else  // ie. if the number generated is less than the odds then the players loses
                        {
                            Console.WriteLine("Bad Luck! You lose");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Please enter in a valid amount");
                }

            }
            // if the while loop is exited then it means that the player ran out of money
            Console.WriteLine("The house always wins.");
        }

        class Guy
        {
            public string Name;
            public int Cash;

            /// <summary>
            /// Writes my name and the amount of cash I have to the console
            /// </summary>
            public void WriteMyInfo()
            {
                Console.WriteLine(Name + " has " + Cash + " bucks");
            }

            /// <summary>
            /// Gives some of my cash, removing it from my wallet (or printing a message to the console
            /// if I dont have enough cash
            /// </summary>
            /// <param name="amount">Amount of cash to give</param>
            /// <returns>The amount of cash removed from my wallet, or 0 if I dont have 
            /// enough cash (or if the amount is invalid)
            /// </returns>
            public int GiveCash(int amount)
            {
                // if the requested amount is less than 0
                if (amount <= 0)
                {
                    Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
                    return 0;
                }
                // if the requested amount is greater than the cash available
                if (amount > Cash)
                {
                    Console.WriteLine(Name + " says: " + " I don't have enough cash to give you " + amount);
                    return 0;
                }
                // deduct the amount of cash from the available cash
                Cash -= amount;
                return amount;
            }

            /// <summary>
            /// Receive some cash, adding it to my wallet (or printing a message to the console
            /// if the amount is invalid)
            /// </summary>
            /// <param name="amount">Amount of cash to give</param>
            public void ReceiveCash(int amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine(Name + " says: " + "Amount isn't an amount I will accept");
                }
                else
                {
                    Cash += amount;
                }
            }
        }
    }
}
