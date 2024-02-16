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

        // Methods
        public abstract string printInfo();

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

    public class Game : Product
    {
        public string genre { get; private set; } = "";
        public List<string> requirements { get; private set; } = new List<string>();

        public Game(string pName
              , float pPurchasePrice
              , int pTax
              , float pProfit
              , string pDescription)
              : base(pName, pPurchasePrice, pTax, pProfit, pDescription)
        {
        }
        public void setGenre(string pGenre) {
            genre = pGenre;
        }

        public void addRequirement(string pRequirement) {
            requirements.Add(pRequirement);
        }
        public override string printInfo()
        {
            return @$"<tr>
                          <td>{this.GetType().Name}</td>
                          <td>{name}</td>
                          <td>{System.Math.Round(purchasePrice, 2)}</td>
                          <td>
                              <ul><li>{genre}</li>
                                  <li>Extra info
                                      <ul style=""list-style-type:circle;"">
                                          {string.Join("", requirements.Select(req => $"<li>{req}</li>"))}
                                      </ul>
                                  </li>
                              </ul>
                          </td>
                      </tr>";           
        }
    }

    public class Movie : Product
    {
        public string quality { get; private set; } = "";

        public Movie(string pName
              , float pPurchasePrice
              , int pTax
              , float pProfit
              , string pDescription)
              : base(pName, pPurchasePrice, pTax, pProfit, pDescription)
        {
        }
        public void setQuality(string pQuality) {
            quality = pQuality;
        }
        public override string printInfo()
        {
            return @$"<tr>
                          <td>{this.GetType().Name}</td>
                          <td>{name}</td>
                          <td>{System.Math.Round(purchasePrice, 2)}</td>
                          <td>
                              <ul><li>{quality}</li>
                              </ul>
                          </td>
                      </tr>";           
        }
    }

    public class Music : Product
    {
        public string artist { get; private set; } = "";
        public List<string> numbers { get; private set; } = new List<string>();

        public Music(string pName
              , float pPurchasePrice
              , int pTax
              , float pProfit
              , string pDescription)
              : base(pName, pPurchasePrice, pTax, pProfit, pDescription)
        {
        }
        public void setArtist(string pArtist) {
            artist = pArtist;
        }

        public void AddNumber(string pNumber) {
            numbers.Add(pNumber);
        }
        public override string printInfo()
        {
            return @$"<tr>
                          <td>{this.GetType().Name}</td>
                          <td>{name}</td>
                          <td>{System.Math.Round(purchasePrice, 2)}</td>
                          <td>
                              <ul><li>{artist}</li>
                                  <li>Extra info
                                      <ul style=""list-style-type:circle;"">
                                          {string.Join("", numbers.Select(num => $"<li>{num}</li>"))}
                                      </ul>
                                  </li>
                               </ul>
                          </td>
                      </tr>";           
        }
    }
}