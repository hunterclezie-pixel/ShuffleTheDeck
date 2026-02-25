/* 
Hunter Clezie 
Spring 2026
RCET2265
ShuffleTheDeck
github url: https://github.com/hunterclezie-pixel/ShuffleTheDeck.git
*/
namespace ShuffleTheDeck
{
    // Todo list:
    // [] Write a program that deals a card from a standard deck of 52 playing cards.
    // [] The card should be a random suit (spades, clubs, hearts, diamonds) and value (2-10, J, Q, K, A).
    // [] Use a multidimensional array to track if the card has already been dealt. If so, draw another random card.
    // [] Shuffle the deck when there are no more cards left or anytime the user chooses.

    internal class Program
    {
        static bool[,] drawnCards = new bool[4, 13];
        static void Main(string[] args)
        {
            string userInput = "";
            int cardCount = 0;

            do
            {
                Console.Clear();

                Console.WriteLine($"Ball count: {cardCount}");
                Display();
                userInput = Console.ReadLine(); //fix double draw

            } while (userInput != "Q" && userInput != "q");

            Console.Clear();
            Console.WriteLine("Thank you for playing cards, Have a great day!");

            //pause
            Console.Read();

        }

        static void Display()
        {
            int padding = 8;
            int prettyNumber = 0;
            string placeHolder = "";
            string columnSeperator = "  |";
            string currentRow = "";
            //print heading row
            string[] heading = { "Spades", "Clubs", "Hearts", "Diamonds"};
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + columnSeperator);
            }
            Console.WriteLine();

            //print the rest of the rows
            for (int number = 1; number <= 13; number++)
            {

                //assemble the row
                for (int suits = 0; suits < 4; suits++)
                {
                    if (drawnCards[suits, number - 1])
                    {
                        prettyNumber = number + (suits * 13);
                        currentRow += prettyNumber.ToString().PadLeft(padding) + columnSeperator;
                    }
                    else
                    {
                        currentRow += placeHolder.PadLeft(padding) + columnSeperator;

                    }
                }
                Console.WriteLine(currentRow);
                currentRow = ""; //Resets the row for the next iteration    
            }

        }

        static void DrawCard()
        {
            int letter = 0, number = 0;

            do
            {
                letter = RandomNumberZeroTo(3);
                number = RandomNumberZeroTo(12);
            } while (drawnCards[letter, number]);

            drawnCards[letter, number] = true;
        }

        static private int RandomNumberZeroTo(int max)
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range);
        }
    }
}
