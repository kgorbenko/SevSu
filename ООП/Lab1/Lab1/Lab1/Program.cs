using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main()
        {



            int userOption = -1;
            var enteredTrains = new List<ITrain>();

            do
            {
                //try-catch blocks to prevent program executing
                //is extensive situation
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter your option:\n" +
                                      "1 - Create new train\n" +
                                      "2 - Write all trains details\n" +
                                      "3 - Compare objects\n" +
                                      "4 - Exit");

                    userOption = int.Parse(Console.ReadLine());

                    switch (userOption)
                    {
                        case 1:
                            enteredTrains.Add(CreateObject());
                            break;
                        case 2:
                            WriteTrainsToConsole(enteredTrains);
                            break;
                        case 3:
                            if (AreSelectedTrainsEqual(enteredTrains))
                                Console.WriteLine("Selected trains are equal");
                            else Console.WriteLine("Selected trains are not equal");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("You have entered a wrong option, try again");
                            continue;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong. Try again");
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    continue;
                }
            } while (userOption != 4);
        }

        private static ITrain CreateObject()
        {
            int userOption = -1;

            //endless while loop to not to finish creating
            //of an object when invalid option is entered 
            do
            {
                Console.Clear();
                Console.WriteLine("What data type should new train be?\n" +
                                  "1 - Structure\n" +
                                  "2 - Class");

                userOption = int.Parse(Console.ReadLine());

                if (userOption == 1) return CreateTrainStructure();
                if (userOption == 2) return CreateTrainClass();
            } while (true);
        }

        //Method to create instance of train structure
        //endless while loops for each input ask
        //to make sure that appropriate value has been entered 
        private static TrainStruct CreateTrainStructure()
        {
            var train = new TrainStruct();

            while (train.Destination == null)
            {
                Console.Clear();
                Console.WriteLine("Enter train destination:");
                var destination = Console.ReadLine();

                train.Destination = destination;
            }

            while (train.Number == 0)
            {
                Console.Clear();
                Console.WriteLine("Enter train number:");
                var trainNumber = int.Parse(Console.ReadLine());

                train.Number = trainNumber;
            }

            while (train.Departure == DateTime.MinValue)
            {
                //try-catch blocks to make sure that user have 
                //entered valid value. When value is invalid, 
                //user gets asked again
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter train departure time:");
                    train.Departure = DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("The input string was not in the correct format. Try again");
                    continue;
                }
            }
            return train;
        }

        //Method to create instance of train class.
        //Endless while loops for each input ask
        //to make sure that appropriate value has been entered
        private static TrainClass CreateTrainClass()
        {
            string destination = null;
            var trainNumber = 0;
            DateTime departure = DateTime.MinValue;

            while (destination == null)
            {
                Console.Clear();
                Console.WriteLine("Enter train destination:");
                destination = Console.ReadLine();
            }

            while (trainNumber == 0)
            {
                Console.Clear();
                Console.WriteLine("Enter train number:");
                trainNumber = int.Parse(Console.ReadLine());
            }

            while (departure == DateTime.MinValue)
            {
                //try-catch blocks to make sure that user have 
                //entered valid value. When value is invalid, 
                //user gets asked again
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter train departure time:");
                    departure = DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("The input string was not in the correct format. Try again");
                    continue;
                }
            }

            return new TrainClass(destination, trainNumber, departure);
        }

        private static bool AreSelectedTrainsEqual(IEnumerable<ITrain> trains)
        {
            ITrain[] trainsArray = trains.ToArray();

            if (trainsArray.Count() < 2)
                throw new Exception("Not enough trains entered");

            WriteTrainsToConsole(trainsArray);

            Console.WriteLine("Select the comparable train");
            var comparable = int.Parse(Console.ReadLine());

            Console.WriteLine("Select the train to compare");
            var toCompare = int.Parse(Console.ReadLine());

            return trainsArray[comparable - 1].Equals(trainsArray[toCompare - 1]);
        }

        //method to list all available Train class and structure instances 
        private static void WriteTrainsToConsole(IEnumerable<ITrain> trains)
        {
            Console.Clear();
            var trainsArray = trains.ToArray();

            for (int i = 1; i <= trains.Count(); i++)
            {
                //string interpolation used 
                Console.WriteLine($"{i}\t{trainsArray[i - 1].ToString()}");
            }
            Console.ReadLine();
        }
    }
}
