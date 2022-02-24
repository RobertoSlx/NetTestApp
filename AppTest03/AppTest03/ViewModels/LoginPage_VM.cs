using AppTest03.Views;
using AppTest03.Views.Login;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
    class LoginPage_VM : BaseViewModel
    {
        public Command LoginEmail { get; }
        public Command LoginFacebook { get; }
        public Command LoginGoogle { get; }

        public LoginPage_VM() // Declaracion de comandos
        {
            LoginEmail = new Command(ButtLoginEmail);
            LoginFacebook = new Command(ButtLoginFacebook);
            LoginGoogle = new Command(ButtLoginGoogle);
        }

        private async void ButtLoginEmail(object obj) // cambios de paagina con backstack para regresar
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}/{nameof(LoginEmailPage)}");
        }
        private async void ButtLoginFacebook(object obj)
        {
           await Shell.Current.GoToAsync($"{nameof(LoginPage)}/{nameof(LoginFacebookPage)}");
        }
        private async void ButtLoginGoogle(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}/{nameof(LoginGooglePage)}");
        }
        public async void OnAppearing()
        {
            //LoadItemId();
            //if(Its already signed in)
            //await Shell.Current.GoToAsync($"{nameof(LoginPage)}/{nameof(LoginGooglePage)}");
        }
    }
}
