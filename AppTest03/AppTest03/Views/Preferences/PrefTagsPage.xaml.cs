using AppTest03.Models;
using AppTest03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views.Preferences
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrefTagsPage : ContentPage
	{
		PrefTagsPage_VM _PrefTagsPage;
		public PrefTagsPage()
		{
			InitializeComponent();
			BindingContext = _PrefTagsPage = new PrefTagsPage_VM();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			_PrefTagsPage.OnAppearing();
		}

		private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			string textA = e.NewTextValue;
			await _PrefTagsPage.SearchBar(textA);
		}
	}
}