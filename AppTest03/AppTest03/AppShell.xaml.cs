using AppTest03.ViewModels;
using AppTest03.Views;
using AppTest03.Views.Login;
using AppTest03.Views.Preferences;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppTest03
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell() // Diccionario de direccionamiento
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(LoginEmailPage), typeof(LoginEmailPage));
            Routing.RegisterRoute(nameof(LoginFacebookPage), typeof(LoginFacebookPage));
            Routing.RegisterRoute(nameof(LoginGooglePage), typeof(LoginGooglePage));
            Routing.RegisterRoute(nameof(LoginRegisterPage), typeof(LoginRegisterPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PrefInterestPage), typeof(PrefInterestPage));
            Routing.RegisterRoute(nameof(PrefLearnPage), typeof(PrefLearnPage));
            Routing.RegisterRoute(nameof(PrefNamePage), typeof(PrefNamePage));
            Routing.RegisterRoute(nameof(PrefTeachPage), typeof(PrefTeachPage));
            Routing.RegisterRoute(nameof(UserProfilePage), typeof(UserProfilePage));
            Routing.RegisterRoute(nameof(PrefTagsPage), typeof(PrefTagsPage));
            Routing.RegisterRoute(nameof(QuestionDetailPage), typeof(QuestionDetailPage));
            Routing.RegisterRoute(nameof(QuestionNewPage), typeof(QuestionNewPage));
            Routing.RegisterRoute(nameof(ResponseNewPage), typeof(ResponseNewPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
            
        }
    }
}
