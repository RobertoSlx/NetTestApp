using AppTest03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestionDetailPage : ContentPage
	{
		QuestionDetailPage_VM _QuestionDetailPage;
		public QuestionDetailPage()
		{
			InitializeComponent();
			BindingContext = _QuestionDetailPage = new QuestionDetailPage_VM();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			_QuestionDetailPage.OnAppearing();
		}
		protected override bool OnBackButtonPressed()
		{
			return base.OnBackButtonPressed();
			AppShell.Current.Navigation.PushAsync(new MainPage());
		}
	}
}