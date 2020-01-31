using Rover.Logic;
using System;

namespace TechTest
{
    public class Progam
    {

        public static void Main()
        {

            try
            {
                // we will randomize the start position and facing 
                //(it's not specified what should be the initial location/facing)            

                var rover = Mars.StartExpedition(new Map(4, 4));

                if (rover != null)
                {
                    while (true)
                    {
                        Console.WriteLine(rover.StatusString());
                        var command = Console.ReadLine();

                        var commandResult = rover.ExecuteCommand(command);
                        if (!commandResult)
                            Console.WriteLine(commandResult?.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Expedition not started. Terminating.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        

        }
    }
}
