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
	public partial class MainPage : ContentPage
	{
		MainPage_VM _MainPageVM;
		public MainPage()
		{
			InitializeComponent();
			BindingContext = _MainPageVM = new MainPage_VM();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			_MainPageVM.OnAppearing();
		}
	}
}