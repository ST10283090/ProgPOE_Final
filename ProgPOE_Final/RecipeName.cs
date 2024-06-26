using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgPOE_Final
{
    public class RecipeName
    {
        public RecipeName(TextBox textboxRecipeName)
        {
            this.textboxRecipeName = textboxRecipeName;
        }
        public TextBox textboxRecipeName { get; set; }
    }
}
