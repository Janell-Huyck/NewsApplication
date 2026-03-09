using NewsApplication.Services;
using NewsApplication.Models;
namespace NewsApplication.Pages;

public partial class NewsListPage : ContentPage
{
	public List<Article> ArticleList;
	public NewsListPage(Category category)
	{
		string categoryName = category.Name;
		BindingContext = new { categoryName };
		ArticleList = new List<Article>();
		InitializeComponent();
		LoadCategoryNewsAsync(categoryName);
	}

	private async void LoadCategoryNewsAsync(string categoryName)
	{
		var apiService = new ApiService();
		var newsResult = await apiService.GetNews(categoryName);
		foreach (var article in newsResult.Articles)
		{
			ArticleList.Add(article);
		}
		CatNews.ItemsSource = ArticleList;
	}

	private async void OnArticleSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is not Article article) return;
		var collectionView = (CollectionView)sender;
		await Navigation.PushAsync(new NewsDetailPage(article));
		collectionView.SelectedItem = null;
	}
}