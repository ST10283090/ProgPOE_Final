using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPOE_Final
{
    public class Recipe
    {
        public string RecipeName { get; set; }
        public List<IngredientDetails> Ingredients { get; set; }
        public List<StepDetails> Steps { get; set; }

        public Recipe(){

            Ingredients = new List<IngredientDetails>();
            Steps = new List<StepDetails>();

        }
        
    }
}
