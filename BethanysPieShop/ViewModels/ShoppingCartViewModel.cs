using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            this.ShoppingCart = shoppingCart;
            this.ShoppingCartTotal = shoppingCartTotal;
        }

        public IShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; }


    }
}
