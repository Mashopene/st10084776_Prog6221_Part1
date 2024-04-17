using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using recipe_app;
class Program
{
    static void Main(string[] args)

    {
        Console.WriteLine("Enter Recipe: ");
        string reci = Console.ReadLine();

        const int MaxIngredients = 10;
        Recipe recipe = new Recipe(MaxIngredients);
        Ingredient[] originalIngredients = new Ingredient[MaxIngredients];

        Console.WriteLine("Enter the number of ingredients:");
        int ingredientCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < ingredientCount; i++)
        {
            Console.WriteLine($"Ingredient {i + 1} - Name:");
            string name = Console.ReadLine();

            Console.WriteLine($"Ingredient {i + 1} - Quantity:");
            double quantity = double.Parse(Console.ReadLine());

            Console.WriteLine($"Ingredient {i + 1} - Unit of Measurement:");
            string unit = Console.ReadLine();

            var ingredient = new Ingredient(name, quantity, unit);
            recipe.AddIngredient(ingredient, i);
            originalIngredients[i] = new Ingredient(name, quantity, unit);
        }

        Console.WriteLine("Enter the number of steps:");
        int stepCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < stepCount; i++)
        {
            Console.WriteLine($"Step {i + 1}:");
            string step = Console.ReadLine();
            recipe.AddStep(step, i);
        }

        Console.WriteLine("\nYour Recipe:");
        Console.WriteLine(recipe.ToString());

        while (true)
        {
            Console.WriteLine("Enter a scale factor (0.5, 2, 3) or 'reset' to reset quantities, 'clear' to clear all data, 'new' to enter a new recipe, 'exit' to quit:");
            string command = Console.ReadLine();

            if (command == "exit")
            {
                recipe.ExitProgram();
                break;
            }
            else if (command == "reset")
            {
                recipe.ResetQuantities(originalIngredients);
                //Console.WriteLine("Quantities have been reset.");
            }
            else if (command == "new")
            {
                recipe = new Recipe(MaxIngredients);
                Array.Clear(originalIngredients, 0, originalIngredients.Length);
                Main(args);
                break;
            }
            else if (command == "clear")
            {
                recipe.ClearAllData();
            }
            else
            {
                double scaleFactor = double.Parse(command);
                recipe.ScaleRecipe(scaleFactor);
            }

            Console.WriteLine("\nScaled Recipe:");
            Console.WriteLine(recipe.ToString());
        }
    }
}
