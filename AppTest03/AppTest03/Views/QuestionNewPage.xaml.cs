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
	public partial class QuestionNewPage : ContentPage
	{
		QuestionNewPage_VM _QuestionNewPage;

		public QuestionNewPage()
		{
			InitializeComponent();
			BindingContext = _QuestionNewPage = new QuestionNewPage_VM();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_QuestionNewPage.OnAppearing();
		}
	}
}