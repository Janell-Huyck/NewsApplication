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
		GetCategoryNews(categoryName);
		ArticleList = new List<Article>();
	}

	public async Task GetCategoryNews(string categoryName)
	{
		var apiService = new ApiService();
		var newsResult = await apiService.GetNews(categoryName);
		foreach (var article in newsResult.Articles)
		{
			ArticleList.Add(article);
		}
		CategoryNews.ItemsSource = ArticleList;
	}
}