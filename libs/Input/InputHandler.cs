using System;

namespace libs
{
    public class InputHandler
    {
        private static InputHandler instance;

        private InputHandler() { } // Private constructor to prevent instantiation outside the class

        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }
                return instance;
            }
        }

        public void ProcessInput()
        {
            // Example implementation for processing input
            while (true)
            {
                Console.WriteLine("Enter your move (e.g., 'a2a4' for moving piece from a2 to a4):");
                string input = Console.ReadLine();

                // Implement your logic to interpret the input
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting input processing.");
                    break;
                }
                else
                {
                    // Example: Parse the input as a move
                    // Here, you'd parse the input and pass it to the game engine for processing
                    // For demonstration, let's assume we just print the move
                    Console.WriteLine("You entered: " + input);
                }
            }
        }
    }
}