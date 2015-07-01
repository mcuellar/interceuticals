using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using OTC.Web.ShoppingCart;
using OTC.Web.Product;

namespace Interceuticals.Common.Classes
{
    public class ITCShoppingCartManager
    {
        private int _cartID = -1;
        OTCShoppingCart _cart = null;
        OTCShoppingCartItem _item = null;
        OTCProduct _product = null;


        public int CartID
        {
            get { return (this._cartID); }
        }


        public ITCShoppingCartManager(int cartID)
        {
            _cartID = cartID;

            try
            {
                _cart = new OTCShoppingCart(_cartID);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);

            }

        }

        public void addToShoppingCart(int productID)
        {
            _item = new OTCShoppingCartItem();
            _product = new OTCProduct(productID);
            _item.ProductID = productID;
            _item.ProductPrice = _product.Price;
            _item.ItemCount = 1;
            _cart.AddCartItem(_item);

            _item = null;
            _product = null;

        }

        public void addToShoppingCart(String[] productList)
        {
            
            if (productList.Length > 0)
            {
                for (int i = 0; i < productList.Length; i++)
                {
                    _item = new OTCShoppingCartItem();
                    _product = new OTCProduct(Convert.ToInt32(productList[i]));
                    _item.ProductID = Convert.ToInt32(productList[i]);
                    _item.ProductPrice = _product.Price;
                    _item.ItemCount = 1;
                    _cart.AddCartItem(_item);

                    _item = null;
                    _product = null;
                }
            }

        }

        public void addToShoppingCart(ArrayList productList)
        {
            IEnumerator prodEnum = productList.GetEnumerator();
            
            while (prodEnum.MoveNext())
            {
                _item = new OTCShoppingCartItem();
                _product = new OTCProduct(Convert.ToInt32(prodEnum.Current));
                _item.ProductID = Convert.ToInt32(prodEnum.Current);
                _item.ProductPrice = _product.Price;
                _item.ItemCount = 1;
                _cart.AddCartItem(_item);

                _item = null;
                _product = null;
            }

            prodEnum.Reset();
        }

        public void Close()
        {
            if (_product != null)
                _product = null;

            if (_item != null)
                _item = null;

            if (_cart != null)
                _cart = null;

        }
    }
}
