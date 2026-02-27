/* 
Hunter Clezie 
Spring 2026
RCET2265
ShuffleTheDeck
github url: https://github.com/hunterclezie-pixel/ShuffleTheDeck.git
*/
namespace ShuffleTheDeck
{
    internal class Program
    {
        static bool[,] drawnCards = new bool[4, 13];
        static void Main(string[] args)
        {
            string userInput = "";
            int cardCount = 0;

            // The main game loop
            do
            {
                Console.Clear();

                // Check if there are still cards to draw
                if (cardCount < 52)
                {
                    Console.WriteLine("Welcome to Shuffle the Deck! please hit \"Enter\" to play");
                    Console.WriteLine("Press \"Q\" to quit anytime");
                    Console.WriteLine("Press \"C\" to clear for a new game any time");
                    DrawCard();
                    cardCount++;
                }

                // Tells the user that all the cards have been drawn
                else
                {
                    Console.WriteLine("All of the cards have been drawn!");
                    Console.WriteLine("Press \"Q\" to quit");
                    Console.WriteLine("Press \"C\" to clear for a new game!");
                }

                Console.WriteLine($"Card count: {cardCount}");
                Display();
                userInput = Console.ReadLine(); //fix double draw

                // Clear the drawn cards if the user inputs C or c
                if (userInput == "C" || userInput == "c")
                {
                    ClearDrawnCards();
                    cardCount = 0;
                }

            // Continue until user inputs Q or q
            } while (userInput != "Q" && userInput != "q");

            //exit message
            Console.Clear();
            Console.WriteLine("Thank you for playing cards, Have a great day!");

            //pause
            Console.Read();
        }

        static void Display() //displays the drawn cards in an array with the suits as columns and the number/ranks as rows
        {
            int padding = 8;
            string prettyRank = "";
            string placeHolder = "";
            string columnSeperator = "  |";
            string currentRow = "";

            // heading row for each suit
            string[] heading = { "Spades", "Clubs", "Hearts", "Diamonds" };
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + columnSeperator);
            }
            Console.WriteLine();

            //print the rest of the rows for each card rank
            for (int number = 1; number <= 13; number++)
            {
                //assembles the row
                for (int suits = 0; suits < 4; suits++)
                {
                    if (drawnCards[suits, number - 1])
                    {
                        // Map numeric ranks to face card labels
                        switch (number)
                        {
                            case 1:
                                prettyRank = "A";
                                break;
                            case 11:
                                prettyRank = "J";
                                break;
                            case 12:
                                prettyRank = "Q";
                                break;
                            case 13:
                                prettyRank = "K";
                                break;
                            default:
                                prettyRank = number.ToString();
                                break;
                        }
                        currentRow += prettyRank.ToString().PadLeft(padding) + columnSeperator;
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

        static void DrawCard() // Draws a card by generatinga random number within the range given
        {
            //keep drawing until we get a card that hasn't been drawn yet
            int suit = 0, number = 0;

            do
            {
                suit = RandomNumberZeroTo(3);
                number = RandomNumberZeroTo(12);
            } while (drawnCards[suit, number]);

            drawnCards[suit, number] = true;
        }

        static private int RandomNumberZeroTo(int max) // Generates a random number between 0 and the given max
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range);
        }

        static void ClearDrawnCards() // Clear the drawn cards by creating a new empty array and assigning it to drawnCards
        {
            bool[,] emptyArray = new bool[4, 13];
            drawnCards = emptyArray;
            drawnCards = new bool[4, 13];
        }
    }
}
