using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgPOE_Final
{
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Window
    {
        List<Recipe> recipes = new List<Recipe>();
        List<RecipeName> recipeNames = new List<RecipeName>();
        List<IngredientDetails> ingredients = new List<IngredientDetails>();
        List<StepDetails> stepDetails = new List<StepDetails>();

        double scalingFactor = 1.0;

        public menu()
        {
            InitializeComponent();
        }

        private void AddIngreds() {

            StackPanel ingredPanel = new StackPanel()

            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 10)
            };

            TextBox textboxIngredName = new TextBox() { Width = 100 };
            TextBox textboxQuantity = new TextBox() { Width = 100 };
            TextBox textboxUnit = new TextBox() { Width = 100 };
            TextBox textboxCalories = new TextBox() { Width = 100 };
            ComboBox comboFoodGroup = new ComboBox() { Width = 100 };

            comboFoodGroup.Items.Add("Vegetables");
            comboFoodGroup.Items.Add("Fruits");
            comboFoodGroup.Items.Add("Grains");
            comboFoodGroup.Items.Add("Protein Foods");
            comboFoodGroup.Items.Add("Dairy");
            comboFoodGroup.Items.Add("Oils and Solid Fats");
            comboFoodGroup.Items.Add("Added Sugars");
            comboFoodGroup.Items.Add("Beverages");

            ingredPanel.Children.Add(new TextBlock()
                { Text = "Ingredient Name: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxIngredName);


            ingredPanel.Children.Add(new TextBlock()
               { Text = "Quantity: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxQuantity);


            ingredPanel.Children.Add(new TextBlock()
               { Text = "Unit: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxUnit);


            ingredPanel.Children.Add(new TextBlock()
               { Text = "Calories: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(textboxCalories);


            ingredPanel.Children.Add(new TextBlock()
               { Text = "Food Group: ", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(comboFoodGroup);


            ingredients.Add(new IngredientDetails(textboxIngredName, textboxQuantity, textboxUnit, textboxCalories, comboFoodGroup));

            pnlDisplay.Children.Add(ingredPanel);

        }

        private void AddSteps(string stepDescription)
        {
            StackPanel stepPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 10)
            };

            TextBox textboxStepDescription = new TextBox() { Width = 300, Text = stepDescription };

            stepPanel.Children.Add(new TextBlock()
            {
                Text = "Step: ",
                VerticalAlignment = VerticalAlignment.Center
            });

            
            stepPanel.Children.Add(textboxStepDescription);

            stepDetails.Add(new StepDetails(textboxStepDescription));

            pnlDisplay.Children.Add(stepPanel);
        }

        private void btnEnterIngredsandSteps_Click(object sender, RoutedEventArgs e)
        {
            btnsaveanddisplay.IsEnabled = true;
            int numIngreds;

            if (int.TryParse(textboxNumIngreds.Text, out numIngreds))
            {
                for (int i = 0; i < numIngreds; i++)
                {
                    AddIngreds();
                }
            }
            textboxNumIngreds.Text = string.Empty;

            int numSteps;
            if (int.TryParse(textBoxnumSteps.Text, out numSteps))
            {
                for (int i = 0; i < numSteps; i++)
                {
                    AddSteps("");
                }
            }

            textBoxnumSteps.Text = string.Empty;

            btnEnterIngredsandSteps.IsEnabled = false;
            textboxNumIngreds.IsEnabled = false;
            textBoxnumSteps.IsEnabled = false;
            textboxRecipeName.IsEnabled = false;
            textboxMaxCal.IsEnabled = false;
            textboxsearchIngred.IsEnabled = false;

        }

        int index = 1;
        private void btnsaveanddisplay_Click(object sender, RoutedEventArgs e)
        {
            SearchIngred.IsEnabled = true;
            SearchFoodGroup.IsEnabled = true;
            SearchMaxCal.IsEnabled = true;

            Recipe newRecipe = new Recipe();

            newRecipe.RecipeName = textboxRecipeName.Text;
            newRecipe.Ingredients.AddRange(ingredients);
            newRecipe.Steps.AddRange(stepDetails);

            recipes.Add(newRecipe);

            textBlockList.Text += index + ": " + newRecipe.RecipeName + "\n"; 
            index++;

            textboxRecipeName.Text = string.Empty;
            textboxNumIngreds.Text = string.Empty;
            textBoxnumSteps.Text = string.Empty;
            textboxMaxCal.Text = string.Empty;
            textboxsearchIngred.Text = string.Empty;

            textboxRecipeName.IsEnabled = true;
            textboxNumIngreds.IsEnabled = true;
            textBoxnumSteps.IsEnabled = true;
            textboxMaxCal.IsEnabled = true;
            textboxsearchIngred.IsEnabled = true;

            pnlDisplay.Children.Clear();
            stepDetails.Clear();
            ingredients.Clear();

            btnsaveanddisplay.IsEnabled = false;
            btnEnterIngredsandSteps.IsEnabled = true;

            btnDisplayRecipe.IsEnabled = true;
            btnDelete.IsEnabled = true;

        }

        private void DisplayRecipes(List<Recipe> filteredRecipes)
        {
            textBlockList.Text = string.Empty;
            int index = 1;
            foreach (var recipe in filteredRecipes)
            {
                textBlockList.Text += $"{index}: {recipe.RecipeName}\n";
                index++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchIngred_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = textboxsearchIngred.Text.Trim();
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.textboxIngredName.Text.Contains(ingredientName, StringComparison.OrdinalIgnoreCase))).ToList();
            DisplayRecipes(filteredRecipes);

        }

        private void SearchFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            string foodGroup = (comboboxsearchFoodGroup.SelectedItem as ComboBoxItem)?.Content.ToString();
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.comboFoodGroup.SelectedItem.ToString() == foodGroup)).ToList();
            DisplayRecipes(filteredRecipes);
        }

        private void SearchMaxCal_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textboxMaxCal.Text.Trim(), out int maxCalories))
            {
                var filteredRecipes = recipes.Where(r => r.Ingredients.Sum(i => int.Parse(i.textboxIngredCalories.Text)) <= maxCalories).ToList();
                DisplayRecipes(filteredRecipes);
            }
            else
            {
                MessageBox.Show("Please enter a valid number for calories.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you wanna to delete all your  recipes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                recipes.Clear();
                textBlockList.Text = string.Empty;
                pnlDisplay.Children.Clear();

                MessageBox.Show("All recipes deleted!");

                btnDisplayRecipe.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
        }

        private void btnDisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes to display.");
                return;
            }

            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the recipe number:", "Recipe Display", "");

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                if (int.TryParse(userInput, out int recipeNumber))
                {
                    if (recipeNumber > 0 && recipeNumber <= recipes.Count)
                    {
                        Recipe selectedRecipe = recipes[recipeNumber - 1];
                        DisplayRecipeDetails(selectedRecipe);
                    }
                    else
                    {
                        MessageBox.Show("Invalid recipe number. Please enter a valid number.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for the recipe.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a recipe number.");
            }
        }

        private void DisplayRecipeDetails(Recipe selectedRecipe)
        {
            pnlDisplay.Children.Clear();

            TextBlock recipeNameBlock = new TextBlock()
            {
                Text = $"Recipe Name: {selectedRecipe.RecipeName}",
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10)
            };
            pnlDisplay.Children.Add(recipeNameBlock);

            TextBlock ingredientsBlock = new TextBlock()
            {
                Text = "Ingredients:",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 5)
            };
            pnlDisplay.Children.Add(ingredientsBlock);

            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                StackPanel ingredientPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                ingredientPanel.Children.Add(new TextBlock()
                {
                    Text = $"- {ingredient.textboxIngredName.Text}, Quantity: {ingredient.textboxIngredQuantity.Text}, Unit: {ingredient.textboxIngredUnit.Text}, Calories: {ingredient.textboxIngredCalories.Text}, Food Group: {ingredient.comboFoodGroup.SelectedItem}",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 500
                });

                pnlDisplay.Children.Add(ingredientPanel);
            }

            TextBlock stepsBlock = new TextBlock()
            {
                Text = "\nSteps:",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 5)
            };
            pnlDisplay.Children.Add(stepsBlock);

            foreach (var step in selectedRecipe.Steps)
            {
                StackPanel stepPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                stepPanel.Children.Add(new TextBlock()
                {
                    Text = $"- {step.TextboxStepsDescription.Text}",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 500
                });

                pnlDisplay.Children.Add(stepPanel);
            }
        }


        private void btnScale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
