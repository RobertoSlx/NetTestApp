using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTest03.Services;
using AppTest03.Models;
using AppTest03.ViewModels;
using AppTest03.Views.Preferences;

namespace AppTest03.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginFacebookPage : ContentPage
    {
        LoginFacebookPage_VM _LoginFacebook_VM;
        public LoginFacebookPage()
        {
            InitializeComponent();
        }
		private void LoginButtFB_Clicked(object sender, EventArgs e)
		{
            WVFace.Source = "https://www.facebook.com/v7.0/dialog/oauth?client_id=1028516854358215&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";
            WVFace.Navigated += WebView_Nav;
        }
		private void WebView_Nav(object sender, WebNavigatedEventArgs c)
		{
            var AccessURL = c.Url;

            if (AccessURL.Contains("access_token"))
			{
                AccessURL = AccessURL.Replace("https://www.facebook.com/connect/login_success.html#access_token=", string.Empty);
                var accesstoken = AccessURL.Split('&')[0];
                HttpClient client = new HttpClient();
                var response = client.GetStringAsync("https://graph.facebook.com/me?fields=email,name,picture&access_token="+accesstoken).Result;

                var Data = JsonConvert.DeserializeObject<FaceProfile>(response);

                t_usuarios_reg userData = new t_usuarios_reg()
                {
                    id_usuario = "FBuser",
                    email = Data.email,
                    nombre = Data.Name
                };
                _LoginFacebook_VM.New_FbUser(userData);
            }
        }
        public class FaceProfile
		{
            public string Name { get; set; }
            public string email { get; set; }
        }
        public class Picture
		{
            public Data data { get; set; }
		}
        public class Data
		{
            public bool IsSilhouette { get; set; }
            public string Url { get; set; }
		}
    }
}