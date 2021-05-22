using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models.ViewModels
{
    public class CatAndSubCatViewModel
    {
        public SubCategory SubCategory { get; set; }
        public IEnumerable<Category> ListCategories { get; set; }
        public string StatusMessage { get; set; }
    }
}
