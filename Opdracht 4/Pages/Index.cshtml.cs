using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Opdracht_4;

namespace Opdracht_4.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public ProductList myProducts = new ProductList();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;

        Music tmpMusic;
        Movie tmpMovie;
        Game tmpGame;

        tmpMusic = new Music("Test1", 7.09f, 8, 2.67f, "Marco's niewste hits singles!");
        tmpMusic.setArtist("Artiest 1");
        tmpMusic.AddNumber("number 1");
        tmpMusic.AddNumber("number 2");
        myProducts.AddProduct(tmpMusic);

        tmpMusic = new Music("Test2", 15.13f, 8, 9.23f, "Ali's niewste hits singles, inclusief singles 3 en 4!!!");
        tmpMusic.setArtist("Artiest 2");
        tmpMusic.AddNumber("number 3");
        tmpMusic.AddNumber("number 4");
        myProducts.AddProduct(tmpMusic);

        tmpMovie = new Movie("Starwars 1", 15.13f, 21, 3.23f, "I have the high ground anakin!!!");
        tmpMovie.setQuality("DVD");
        myProducts.AddProduct(tmpMovie);

        tmpMovie = new Movie("Starwars 2", 15.13f, 21, 3.23f, "The return of the Jedi, du du du du du du du du du");
        tmpMovie.setQuality("Blueray");
        myProducts.AddProduct(tmpMovie);

        tmpGame = new Game("Call of Duty 1", 7.87f, 21, 2.45f, "De nieuwste COD game van sony waar je iedereen dood maakt!");
        tmpGame.setGenre("FPS");
        tmpGame.addRequirement("8gb geheugen");
        tmpGame.addRequirement("970 GTX");
        myProducts.AddProduct(tmpGame);

        tmpGame = new Game("Call of Duty 2", 13.92f, 21, 6.35f, "De nieuwste COD game van sony waar je iedereen dood maakt! Nu met nog meer dood!");
        tmpGame.setGenre("FPS");
        tmpGame.addRequirement("16gb geheugen");
        tmpGame.addRequirement("2070 RTX");
        myProducts.AddProduct(tmpGame);
    }

    public void OnGet()
    {

    }
}