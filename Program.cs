using System;

namespace CapsuleHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to Capsule-Capsule.\n===========================\nEnter the number of capsules available: ");
            string capacity = Console.ReadLine();
            int i = int.Parse(capacity);

            Console.WriteLine($"\nThere are {capacity} unoccupied capsules ready to be booked.");

            string[] menuOptions = new string[5];
            menuOptions = Seed4Menu(menuOptions);
            string[] guestList = new string[i];

            bool isRunning = true;

            while (isRunning)
            {
                switch (OpenMenu())
                {
                    case "1":
                        CheckInPrompt();
                        guestList = AddNewGuest(guestList);
                        break;
                    case "2":
                        CheckOutPrompt();
                        guestList = RemoveGuest(guestList);
                        break;
                    case "3":
                        ViewGuestList(guestList);
                        //ViewGuestList2(guestList); still working on this code.
                        break;
                    case "4":
                        ExitProgram();
                        break;
                    default:
                        isRunning = false;
                        break;

                }
            }
        }
        private static string OpenMenu()
        {
            Console.Write(@"

Guest Menu
==========
1. Check In
2. Check Out
3. View Guests
4. Exit
Choose on option [1-4]: ");
            return Console.ReadLine();

        }
        private static string[] Seed4Menu(string[] menuOptions)
        {
            menuOptions[0] = "Check In";
            menuOptions[1] = "Check Out";
            menuOptions[2] = "View Guests";
            menuOptions[3] = "Exit";

            return menuOptions;
        }
        //This code is showing all the capsules at ones instead of 10 at a time. 
        private static void ViewGuestList(string[] viewGuest)
        {
            int i = 0;
            while (i < viewGuest.Length)
            {
                if (string.IsNullOrEmpty(viewGuest[i]))
                {

                    Console.WriteLine($"{i + 1}: [unoccupied]");
                    i++;
                }
                else
                {
                    Console.WriteLine($"{i + 1}: {viewGuest[i]}");
                    i++;
                }

            }
        }
        private static string[] AddNewGuest(string[] guestRoom)
        {
            Console.Write("Guest Name: ");
            string newGuest = Console.ReadLine();

            string input;

            bool isEmpty = false;

            while (!isEmpty)
            {
                Console.Write($"Capsule #[1-{guestRoom.Length}]: ");
                input = Console.ReadLine();
                int i = int.Parse(input);

                if (string.IsNullOrEmpty(guestRoom[i - 1]))
                {
                    guestRoom[i - 1] = newGuest;
                    Console.WriteLine($"\nSuccess :)\n{newGuest} is booked in capsule #{i}.");
                    isEmpty = true;
                    break;
                }
                else
                {
                    Console.WriteLine($"\nError :( \nCapsule {i} is occupied.\n\n");
                }
            }

            return guestRoom;
        }
        private static string[] RemoveGuest(string[] removeOldGuest)
        {
            string input;

            bool isEmpty = true;

            while (isEmpty)
            {
                Console.Write("Capsule #[1-100]: ");
                input = Console.ReadLine();
                int guest2Remove = int.Parse(input);

                if (string.IsNullOrEmpty(removeOldGuest[guest2Remove - 1]))
                {
                    Console.WriteLine($"Error :( \nCapsule {guest2Remove} is unoccupied.");

                }
                else
                {
                    Console.WriteLine($"\nSuccess :) \n{removeOldGuest[guest2Remove - 1]} checked out from capsule #{guest2Remove}.");
                    removeOldGuest[guest2Remove - 1] = null;
                    isEmpty = true;
                    break;
                }
            }
            return removeOldGuest;
        }
        private static void CheckInPrompt()
        {
            Console.WriteLine("\n\nGuest Check In\n==============");
        }
        private static void CheckOutPrompt()
        {
            Console.WriteLine("\n\nGuest Check Out\n==============");
        }
        //TODO: Better way to exit program?
        private static void ExitProgram()
        {
            Console.Write("\nAre you sure you want to exit?\nAll data will be lost.\nExit [y/n]: ");
            string input = Console.ReadLine();

            if ((input.Equals("Y")) || (input.Equals("y")))
            {
                Console.WriteLine("Goodbye");
                Console.ReadKey();

            }
            else
            {
                OpenMenu();
            }


        }

        //TODO: View 5 smaller and larger based on input
        private static void ViewGuestList2(string[] viewGuest)
        {
            Console.Write($"Capsule #[1-{viewGuest.Length}]: ");
            string roomInput = Console.ReadLine();
            int count = int.Parse(roomInput);
            int totalCount = (count + 11);

            while (count < totalCount)
            {
                if (string.IsNullOrEmpty(viewGuest[count]))
                {
                    Console.WriteLine($"{count - 5}: [unoccupied]");
                    count++;
                }
                else
                {
                    Console.WriteLine($"{viewGuest[count - 1]}: {viewGuest[count]}");
                    count++;
                }

            }
        }
    }
}
