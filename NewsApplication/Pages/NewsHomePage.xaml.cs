
using NewsApplication.Models;
using NewsApplication.Services;
using System.Threading.Tasks;

namespace NewsApplication.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticleList;
	public List<Category> CategoryList = new List<Category>()
	{
		new Category(){Name="World", ImageUrl="world.png"},
		new Category(){Name="Nation", ImageUrl="nation.png"},
		new Category(){Name="Business", ImageUrl="business.png"},
		new Category(){Name="Technology", ImageUrl="technology.png"},
		new Category(){Name="Entertainment", ImageUrl="entertainment.png"},
		new Category(){Name="Sports", ImageUrl="sports.png"},
		new Category(){Name="Science", ImageUrl="science.png"},
		new Category(){Name="Health", ImageUrl="health.png"},
	};
	public NewsHomePage()
	{
		InitializeComponent();
		ArticleList = new List<Article>();
		CvCategories.ItemsSource = CategoryList;
		GetBreakingNews();
	}

	private async Task GetBreakingNews()
	{
		var apiService = new ApiService();
		var newsResult = await apiService.GetNews();
		foreach (var item in newsResult.Articles)
		{
			ArticleList.Add(item);
		}
		CvNews.ItemsSource = ArticleList;
	}

	private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is not Category category) return;

		await Navigation.PushAsync(new NewsListPage(category));
		((CollectionView)sender).SelectedItem = null;
	}
}