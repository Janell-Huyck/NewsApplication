using NewsApplication.Models;

namespace NewsApplication.Pages;

public partial class NewsDetailPage : ContentPage
{
	public NewsDetailPage(Article article)
	{
		InitializeComponent();
		DetailImage.Source = article.Image;
		DetailTitle.Text = article.Title;
		DetailText.Text = article.Content ?? article.Description ?? string.Empty;
	}
}