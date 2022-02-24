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
	public partial class ResponseNewPage : ContentPage
	{
		ResponseNewPage_VM _ResponseNewPage;

		public ResponseNewPage()
		{
			InitializeComponent();
			BindingContext = _ResponseNewPage = new ResponseNewPage_VM();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_ResponseNewPage.OnAppearing();
		}
	}
}