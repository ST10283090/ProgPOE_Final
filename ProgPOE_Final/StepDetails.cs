using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPOE_Final
{
    public class StepDetails
    {
        public StepDetails(TextBox textboxStepsDescription)
        {
            this.TextboxStepsDescription = textboxStepsDescription;
        }
        public TextBox TextboxStepsDescription { get; set; }
    }
}
