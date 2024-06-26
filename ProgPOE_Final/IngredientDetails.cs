using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPOE_Final
{
    public class IngredientDetails
    {
        public IngredientDetails(TextBox textboxIngredName, TextBox textboxIngredQuantity, TextBox textboxIngredUnit, TextBox textboxIngredCalories, ComboBox comboFoodGroup)
        {
            this.textboxIngredName = textboxIngredName;
            this.textboxIngredQuantity = textboxIngredQuantity;
            this.textboxIngredUnit = textboxIngredUnit;
            this.textboxIngredCalories = textboxIngredCalories;
            this.comboFoodGroup = comboFoodGroup;
        }
        public TextBox textboxIngredName { get; set; }
        public TextBox textboxIngredQuantity { get; set; }
        public TextBox textboxIngredUnit { get; set; }
        public TextBox textboxIngredCalories { get; set; }
        public ComboBox comboFoodGroup { get; set; }
    }
}
