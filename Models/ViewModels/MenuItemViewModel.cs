using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models.ViewModels
{
    public class MenuItemViewModel
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<Category> ListCategories { get; set; }
        public IEnumerable<SubCategory> ListSubCategories { get; set; }
        
    }
}
