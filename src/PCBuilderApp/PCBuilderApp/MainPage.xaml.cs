using HtmlAgilityPack;
using System.Linq;
using System.Web;

namespace PCBuilderApp;

public partial class MainPage : ContentPage
{
    
	public MainPage()
	{
		InitializeComponent();

        SQLiteDatabase database = new SQLiteDatabase();
        var results = database.ReadPCBuilds();
	}

    /*string urlBuilder(string url, string[] partsArray)
    {
        string newUrl = url;
        for (int i = 0; i < partsArray.Length; i++)
        {
            //Add a plus sign and the word after the url
            newUrl += "+";
            newUrl += partsArray[i];
        }
        return newUrl;
    }

    void OnEntryCompleted(object sender,EventArgs e)
    {
        //Get user input
        string inputText = PartEntry.Text;
        //Split each word in user input
        string[] textSplit = inputText.Split(" ");

        //Create search url on newegg
        string url = urlBuilder("https://www.newegg.com/p/pl?d=", textSplit);

        //Open URL
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);

        //Get item cells on page
        var productCells = doc.DocumentNode.Descendants("div")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("item-cell")).ToList();

        //Get the price of the first cell
        var productList = productCells[0].Descendants("li")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("price-current")).ToList();

        //get price text
        string product = productList[0].InnerText;
        //Format the string
        string[] priceSplit = product.Split("(");
        string price = priceSplit[0];
        
        //Display result
        DisplayAlert("Result", price, "Ok");
    }*/
    
}



