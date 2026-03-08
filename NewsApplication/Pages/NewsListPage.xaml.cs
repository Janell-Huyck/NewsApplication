using NewsApplication.Services;
using NewsApplication.Models;
namespace NewsApplication.Pages;

public partial class NewsListPage : ContentPage
{
	public List<Article> ArticleList;
	public NewsListPage(string categoryName)
	{
		Title = categoryName;
		InitializeComponent();
		ApiService.GetNews(categoryName);
		ArticleList = new List<Article>();
	}
}