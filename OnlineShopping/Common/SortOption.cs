using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.Models
{
    public enum SortOption
    {
        [Description("Low to High Price")]
        Low,

        [Description("High to Low Price")]
        High,

        [Description("A - Z sort on the Name")]
        Ascending,

        [Description("Z - A sort on the Name")]
        Descending,

        [Description("Popular")]
        Recommended,
        
        [Description("Default")]
        Default
    }
}
