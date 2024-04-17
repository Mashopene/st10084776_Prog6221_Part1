using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_app
{
    public class Recipe
    {
        public Ingredient[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        public Recipe(int maxIngredients)
        {
            Ingredients = new Ingredient[maxIngredients];
            Steps = new string[10];
        }

        public void AddIngredient(Ingredient ingredient, int index)
        {
            Ingredients[index] = ingredient;
        }

        public void AddStep(string step, int index)
        {
            Steps[index] = step;
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                if (ingredient != null)
                    ingredient.Scale(factor);
            }
        }

        public void ResetQuantities(Ingredient[] originalIngredients)
        {
            Console.WriteLine("Are you sure you want to reset quantities to the original values? (yes/no):");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes")
            {
                for (int i = 0; i < originalIngredients.Length; i++)
                {
                    Ingredients[i] = originalIngredients[i];
                }
                Console.WriteLine("Quantities have been reset.");
            }
            else
            {
                Console.WriteLine("Reset operation canceled.");
            }
        }

        public void ExitProgram()
        {
            Console.WriteLine("Are you sure you want to exit the program? (yes/no):");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes")
            {
                Environment.Exit(0);
            }
        }
        public void ClearAllData()
        {
            Console.WriteLine("Are you sure you want to clear all data? (yes/no):");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes")
            {
                Array.Clear(Ingredients, 0, Ingredients.Length);
                Array.Clear(Steps, 0, Steps.Length);
                Console.WriteLine("All data cleared.");
            }
            else
            {
                Console.WriteLine("Clear operation canceled.");
            }
        }

        /*public void ResetQuantities(Ingredient[] originalIngredients)
        {
            for (int i = 0; i < originalIngredients.Length; i++)
            {
                Ingredients[i] = originalIngredients[i];
            }
        }*/

        public override string ToString()
        {
            StringBuilder recipeString = new StringBuilder();

            recipeString.AppendLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                if (ingredient != null)
                    recipeString.AppendLine(ingredient.ToString());
            }

            recipeString.AppendLine("\nSteps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                if (!string.IsNullOrEmpty(Steps[i]))
                    recipeString.AppendLine($"{i + 1}. {Steps[i]}");
            }

            return recipeString.ToString();
        }
    }
}