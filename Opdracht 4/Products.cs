using System.Linq;

namespace Opdracht_4
{
    public class ProductList
    {
        // Properties
        public List<Product> products { get; private set; } = new List<Product>();

        // Methods
        public void AddProduct(Product pProduct) {
            products.Add(pProduct);
        }
    }

    public abstract class Product
    {
        // Properties
        public string name { get; private set; }
        public float purchasePrice { get; private set; }
        public int tax { get; private set; }
        public string description { get; private set; }
        public float profit { get; private set; }
        public string category { get; protected set; }

        // Methods
        public abstract string printInfo();

        public abstract string getInfo();

        public void setCategory(string pCategory) {
            category = pCategory;
        }

        // Constructor
        public Product(string pName
                     , float pPurchasePrice
                     , int pTax
                     , float pProfit
                     , string pDescription
                      )
        {
            name = pName;
            purchasePrice = pPurchasePrice;
            tax = pTax;
            profit = pProfit;
            description = pDescription;
        }
    }
}