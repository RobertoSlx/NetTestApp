using AppTest03.Models;
using AppTest03.Services;
using AppTest03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginGooglePage : ContentPage
    {

        LoginGooglePage_VM _loginGooglePage;
        private readonly IGoogleManager _googleManager;

        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLoggedIn { get; set; }

        public LoginGooglePage()
        {
            _googleManager = DependencyService.Get<IGoogleManager>();
            CheckUserLoggedIn();
            InitializeComponent();
        }
        private void CheckUserLoggedIn()
		{
            _googleManager.Login(onLoginComplete);
        }

        private void LoginGoogleButt_Clicked(object sender, EventArgs e)
		{
            
        }
        private void onLoginComplete(GoogleUser googleUser, string mensage)
		{
            if(googleUser != null)
			{
                GoogleUser = googleUser;
                IsLoggedIn = true;

                t_usuarios_reg userData = new t_usuarios_reg() // Clase temporal
                {
                    email = GoogleUser.Email,
                    contrasena = "Go_User",
                    nombre = GoogleUser.Name,
                    url_im_perfil = GoogleUser.Picture.ToString()
                };

                _loginGooglePage.GoogleLogin(userData);
            }
			else
			{
                DisplayAlert("Message", mensage, "Ok");
			}
		}
        private void GoogleLogout()
		{
            _googleManager.Logout();
            IsLoggedIn = false;
		}

	}
}