using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest03.Views;
using AppTest03.Views.Login;
using AppTest03.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPage_VM _loginPage;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _loginPage = new LoginPage_VM(); // Binding el ViewModel
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _loginPage.OnAppearing();
        }
    }
}