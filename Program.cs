using System.Diagnostics;

namespace MotorCykelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hvad hedder din motorcykel?");
            string mcNavn = Console.ReadLine();
            Console.WriteLine($"Vil du starte din {mcNavn} (j/n)");
            ConsoleKey svar = Console.ReadKey().Key;
            Console.WriteLine();
            if ((char)svar == 'J')
            {
                MotorCycle motorCycle = new MotorCycle(mcNavn, true);
                Console.WriteLine(motorCycle.ToString());

                int userInput;

                do
                {
                    Console.Write("Tryk på speederen og øg omdrejningerne. Hvor meget trykker du på speederen? Skriv antal rpm: ");
                    // Try to parse the input as an integer
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out userInput))
                    {
                        // Break out of the loop if parsing succeeds
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Det er ikke et gyldigt tal for rpm. Prøv igen.");
                    }

                } while (true);
                Console.WriteLine(motorCycle.ToString());
                for (int i = 0; i < 4; i++) 
                { 
                Console.WriteLine("Du skifter gear og sætter den et gear op.");
                motorCycle.ShiftGearsUp();
                Console.WriteLine(motorCycle.ToString());
                }
            }
            else
            {
                MotorCycle motorCycle = new MotorCycle(mcNavn, false);
                motorCycle.Stop();
            }


            
            Console.ReadLine();
        }
    }
}
