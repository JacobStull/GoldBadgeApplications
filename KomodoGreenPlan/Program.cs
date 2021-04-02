using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();




        }
        public class ProgramUI
        {
            private KGPRepo _repo = new KGPRepo();
            public void Run()
            {
                Menu();
            }

            private void Menu()
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();


                    Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                        "1. Show all cars \n" +
                        "2. Find car by type\n" +
                        "3. Add new car\n" +
                        "4. Update existing car\n" +
                        "5. Remove car\n" +
                        "6. Exit");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            
                            ShowAllContent();
                            break;
                        case "2":
                            
                            ShowContentByFuel();
                            break;
                        case "3":
                            
                            CreateNewContent();
                            break;
                        case "4":
                            
                            UpdateExistingContent();
                            break;
                        case "5":
                            
                            DeleteContentByModel();
                            break;
                        case "6":
                            
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            private void UpdateExistingContent()
            {
                KomodoGreen updateContent = new KomodoGreen();
                Console.Clear();

                ShowAllContent();
                Console.WriteLine("Enter the Model(Electric, Gas, Or Hybrid) for the car you would like to update");
                string titleToDelete = Console.ReadLine();
                KomodoGreen contentToDelete = _repo.GetContentByModel(titleToDelete);
                bool wasDeleted = _repo.DeleteExistingContent(contentToDelete); if (wasDeleted)
                {
                    Console.WriteLine("Enter new updates");
                }
                else
                {
                    Console.WriteLine("Content could not updated");
                }


                Console.WriteLine("Please update Make.");
                updateContent.Make = Console.ReadLine();
                Console.WriteLine("Please update Model");
                updateContent.Model = Console.ReadLine();
                Console.WriteLine("Please update a Fuel Type.");
                updateContent.Fuel = Console.ReadLine();

                Console.WriteLine("Please update a description.");
                updateContent.Description = Console.ReadLine();




                bool wasAdded = _repo.AddContentToDirectory(updateContent);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your content was successfully updated.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your Content was not added.");
                }

            }

            private void ShowAllContent()
            {
                Console.Clear();

                List<KomodoGreen> listofContent = _repo.GetContents();

                foreach (KomodoGreen content in listofContent)
                {
                    DisplayContent(content);


                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

            }

            private void CreateNewContent()
            {
                Console.Clear();

                KomodoGreen newContent = new KomodoGreen();

                Console.WriteLine("Please enter a Make.");
                newContent.Make = Console.ReadLine();
                Console.WriteLine("Please enter a Model");
                newContent.Model = Console.ReadLine();
                Console.WriteLine("Please enter a Fuel Type(Electric, Gas, or Hybrid).");
                newContent.Fuel = Console.ReadLine();

                Console.WriteLine("Please enter a description.");
                newContent.Description = Console.ReadLine();

                bool wasAdded = _repo.AddContentToDirectory(newContent);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your car was successfully added.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your car was not added.");
                }

            }

            private void ShowContentByFuel()
            {
                Console.Clear();

                Console.WriteLine("Enter the Fuel Type(Electric, Gas, Or Hybrid) of the cars you'd like to see.");
                string fuel = Console.ReadLine();

                KomodoGreen content = _repo.GetContentByFuel(fuel);

                if (content != null)
                {
                    DisplayContent(content);

                }
                else
                {
                    Console.WriteLine("That fuel type doesnt exist.");
                }
                Console.ReadKey();
            }

            private void DeleteContentByModel()
            {
                ShowAllContent();
                Console.WriteLine("Enter the Model for the Car you would like to delete");
                string titleToDelete = Console.ReadLine();
                KomodoGreen contentToDelete = _repo.GetContentByModel(titleToDelete);
                bool wasDeleted = _repo.DeleteExistingContent(contentToDelete);

                if (wasDeleted)
                {
                    Console.WriteLine("This content was successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Content could not be deleted");
                }



            }

            private void DisplayContent(KomodoGreen content)
            {
                Console.WriteLine($"Model: {content.Model}");
                Console.WriteLine($"Make: {content.Make}");
                Console.WriteLine($"Fuel Type: {content.Fuel}");
                Console.WriteLine($"Description: {content.Description}");
            }

        }
    }
}

