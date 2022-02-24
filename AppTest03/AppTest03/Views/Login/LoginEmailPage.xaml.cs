using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTest03.Models;
using AppTest03.ViewModels;
using MvvmHelpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginEmailPage : ContentPage
    {
        public t_usuarios_reg UserData { get; set; }

        public LoginEmailPage()
        {
            InitializeComponent();
            BindingContext = new LoginEmailPage_VM(); // Binding el Viewmodel
        }
    }
}