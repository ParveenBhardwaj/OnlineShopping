using OnlineShopping.Common;

namespace OnlineShopping.Helpers
{
    public static class UriHelper
    {
        public static string GetProductUri()
        {
            string productUri = ProjectConstants.BASE_URL + ProjectConstants.RESOURCE_URL_PATH + ProjectConstants.PRODUCT_URL_PATH;
            string productUriWithToken = productUri + "?" + ProjectConstants.AUTH_TOKEN_NAME + "=" + ProjectConstants.AUTH_TOKEN_VALUE;
            return productUriWithToken;
        }

        public static string GetCustomerShoppingHistoryUri()
        {
            string shoppingHistoryUri = ProjectConstants.BASE_URL + ProjectConstants.RESOURCE_URL_PATH + ProjectConstants.SHOPPER_HISTORY_URL_PATH;
            string shoppingHistoryUriWithToken = shoppingHistoryUri + "?" + ProjectConstants.AUTH_TOKEN_NAME + "=" + ProjectConstants.AUTH_TOKEN_VALUE;
            return shoppingHistoryUriWithToken;
        }
    }
}
