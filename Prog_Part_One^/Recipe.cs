using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Part_One_
{

    internal class Recipe

    {

        // use global list<T> and global variables

        //list<T>

        private static List<Ingredient> ingredients = new List<Ingredient>();
        private static List<Ingredient> recipeSteps = new List<Ingredient>();
        private static List<Ingredient> scaledQuantity = new List<Ingredient>();


        //variables

        public static int ingredientNum = 0;
        public static int stepsNum = 0;
        public bool scale = false;
        public static string recipeName = "";

        //Method for a genric welcome message
        public void welcomeMsg()
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("WELCOME TO YOUR ONLINE RECIPE BOOK!");
            Console.WriteLine("=================================================================");

            mainMenu();
        }

        //Method for Main menu
        public void mainMenu()
        {//show user their options
            Console.WriteLine("1. Add a new recipe \n"
                            + "2. Display the recipe \n"
                            + "3. Scale the recipe \n"
                            + "4. Return to original scale of the recipe \n"
                            + "5. Clear all the data \n"
                            + "6. Exit the Program!");
            //record option chosen
            string kb = Console.ReadLine();

            switch (kb)
            {
                case "1"://check if recipe already exists
                    if (ingredientNum > 0)
                    {
                        Console.WriteLine("A recipe has already been saved. Kindly delete to continue.");
                        mainMenu();
                    }
                    else { addRecipe(); }
                    break;
                case "2":
                    displayRecipe();
                    break;
                case "3":
                    scaleRecipe();
                    break;
                case "4":
                    restoreRecipe();
                    break;
                case "5":
                    deleteRecipe();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("Thank you for using our online recipe book!");
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter a valid option between 1 to 5.");
                    mainMenu(); 
                    break;
            }//switch
        }//mainMenu

        public void addRecipe()
        {

            Console.Clear();
            //meeting criteria
            Console.WriteLine("How many ingredients does the recipe call for?");
            bool temp = false;
            while (temp == false)
            {
                try
                {
                    ingredientNum = int.Parse(Console.ReadLine());
                    if (ingredientNum == 0)
                    {
                        Console.WriteLine("Are we gonna be smelling what The Rock is cooking?");
                    }//if
                    else { temp = true; }
                }
                catch (Exception) { Console.WriteLine("Please enter a valid value!"); }//try

            }//while

            Console.WriteLine("Enter the name of the recipe: ");
            recipeName = Console.ReadLine();

            for (int i = 0; i < ingredientNum; i++)
            {
                Console.WriteLine("Enter the names of the ingredients : {0} ", i+1);
                string name = Console.ReadLine();
                Console.WriteLine("Enter the quantity for " + name);
                double ingredQuantity = 0;

                temp = false;
                while (temp == false)
                {
                    try
                    {
                        ingredQuantity = Double.Parse(Console.ReadLine());
                        temp = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Are we cooking for John Cena?");
                    }
                }//while
                //generic measurements
                Console.WriteLine("Choose the unit of measurement for the ingredient:\n" +
                  "1. kg\n" +
                  "2. cups\n" +
                  "3. mg\n" +
                  "4. L\n" +
                  "5. mL\n" +
                  "6. tablespoon\n" +
                  "7. teaspoons");

                string unit = "";
                string input = Console.ReadLine();
                bool temp2 = false; 
                //temp is giving an error???
                while (temp2==false)
                {
                    switch (input)
                    {
                        case "1":
                            unit = "kg";
                            temp2 = true;
                            break;

                        case "2":
                            unit = "cups";
                            temp2 = true;
                            break;

                        case "3":
                            unit = "mg";
                            temp2 = true;
                            break;

                        case "4":
                            unit = "L";
                            temp2 = true;
                            break;

                        case "5":
                            unit = "mL";
                            temp2 = true;
                            break;

                        case "6":
                            unit = "tablespoons";
                            temp2 = true;
                            break;

                        case "7":
                            unit = "teaspoons";
                            temp2 = true;
                            break;

                        default:
                            Console.WriteLine("Please enter a valid unit of measurement.");
                            input = Console.ReadLine();
                            break;
                    }//switch
                }//while

                scaledQuantity.Add(new Ingredient { ScaledName = name, ScaledQuantity = ingredQuantity, ScaledUnit = unit });
                ingredients.Add(new Ingredient { IngredName = name, IngredQuantity = ingredQuantity, IngredUnit = unit });


            }//for

            Console.WriteLine("How many steps does the recipe have?");
            bool temp3 = false;
            while (!temp3)
            {
                try
                {
                    stepsNum = int.Parse(Console.ReadLine());
                    if (stepsNum <= 0)
                    {
                        Console.WriteLine("Man who is afraid of elevators: \" I need to take steps to get over my fear:)\"");
                    }
                    else
                    {
                        temp3 = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid integer.");
                }
            }

            for (int i = 0; i < stepsNum; i++)
            {//loop to add descriptions in to the array
                Console.WriteLine("Enter description for step {0}:", i+1);
                string stepDescription = Console.ReadLine();
                recipeSteps.Add(new Ingredient { IngredSteps = stepDescription });
            }

            mainMenu();
        }//addRecipe

        public void displayRecipe()
        {
            if (recipeSteps.Count == 0)
            {//formatting
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("Let's add a recipe before we try to display it!");
                Console.WriteLine("==================================================");
                mainMenu();
            }

            Console.Clear();
            Console.WriteLine("Full recipe for " + recipeName);
            Console.WriteLine("\nIngredients:");

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine("{0} {1} of {2}", ingredient.IngredQuantity, ingredient.IngredUnit, ingredient.IngredName);
            }

            Console.WriteLine("========================================================");
            Console.WriteLine("Steps:");
            
            int stepNumber = 1;
            foreach (var step in recipeSteps)
            {
                Console.WriteLine("Step {0}: {1}", stepNumber, step.IngredSteps);
                stepNumber = stepNumber + 1;
            }
            Console.WriteLine("========================================================");
            mainMenu();
        }//displayRecipe

        public void deleteRecipe()
        {//criteria/ask user if they r sure, safety net for error
            Console.WriteLine("Do you want to delete your saved recipe? Enter 1 or 2.\n" +
                              "1. Yes\n" +
                              "2. No");

            string kb = Console.ReadLine();
            bool temp4 = false;

            while (!temp4)
            {
                switch (kb)
                {
                    case "1":
                        ingredients.Clear();
                        recipeSteps.Clear();
                        scaledQuantity.Clear();
                        ingredientNum = 0;
                        stepsNum = 0;
                        scale = true;//confirm action.
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("Recipe has been cleared. You can now add a new recipe!");
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
                        mainMenu();
                        temp4 = true;
                        break;

                    case "2":
                        Console.Clear();
                        mainMenu();
                        temp4 = true;
                        break;

                    default:
                        Console.WriteLine("(T_T). How do you even mess that up?");
                        kb = Console.ReadLine();
                        break;
                }//switch

            }//while

        }//deleteRecipe

        public void restoreRecipe()
        {
            if (scale)
            {
                Console.WriteLine("Recipe is already at its original scale.");
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.ScaledQuantity = ingredient.IngredQuantity;
            }

            Console.WriteLine("Recipe restored to its original scale.");
            mainMenu();
        }//restoreRecipe

        public void scaleRecipe() {

            Console.WriteLine("By what factor would you like to scale the recipe?\n Enter the option number!");
            Console.WriteLine("1. 0.5 \n"
                            + "2. 2 \n"
                            + "3. 3");

            double multiplier = 0.00;
            string scaledName = "";

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    multiplier = 0.5;
                    break;
                case 2: 
                    multiplier = 2;
                    break;
                case 3: 
                    multiplier = 3;
                    break;
                default:
                    Console.WriteLine("Choose a valid option...");
                    return;
            }//switch

            foreach (var ingredient in ingredients) {

                ingredient.ScaledQuantity = ingredient.IngredQuantity * multiplier;
                ingredient.ScaledName = ingredient.IngredName;
                ingredient.ScaledUnit = ingredient.IngredUnit;
            }
            //display changed recipe
            Console.Clear();
            Console.WriteLine("SCALED recipe for " + scaledName);
            Console.WriteLine("\nIngredients:");

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine("{0} {1} of {2}", ingredient.ScaledQuantity, ingredient.IngredUnit, ingredient.ScaledName);
            }

            Console.WriteLine("========================================================");
            Console.WriteLine("Steps:");

            int stepNumber = 1;
            foreach (var step in recipeSteps)
            {
                Console.WriteLine("Step {0}: {1}", stepNumber, step.IngredSteps);
                stepNumber = stepNumber + 1;
            }
            Console.WriteLine("========================================================");
            mainMenu();

        }//scaleRecipe

    }//recipe class

}//program
