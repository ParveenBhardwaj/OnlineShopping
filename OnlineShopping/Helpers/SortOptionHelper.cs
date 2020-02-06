using OnlineShopping.Domain.Models;

namespace OnlineShopping.Helpers
{
    public static class SortOptionHelper
    {

        public static SortOption GetSortOption(string sortOption)
        {
            switch (sortOption)
            {
                case "High":
                case "high":
                    return SortOption.High;
                case "Low":
                case "low":
                    return SortOption.Low;
                case "Ascending":
                case "ascending":
                    return SortOption.Ascending;
                case "Descending":
                case "descending":
                    return SortOption.Descending;
                case "Recommended":
                case "recommended":
                    return SortOption.Recommended;
                default:
                    return SortOption.Default;
            }
        }
    }
}
