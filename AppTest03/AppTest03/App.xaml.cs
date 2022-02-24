using AppTest03.Services;
using AppTest03.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockData>(); // inicializar la clase global
            MainPage = new AppShell();
        }
        protected async override void OnStart()
        {
            //await Shell.Current.GoToAsync("//LoginPage");
            await Shell.Current.GoToAsync("//MainPage");
            //await Shell.Current.GoToAsync("//PrefNamePage");
            //await Shell.Current.GoToAsync("//LoginRegisterPage");
            //await Shell.Current.GoToAsync("//PrefTagsPage");
            //await Shell.Current.GoToAsync("//PrefInterestPage");
            //await Shell.Current.GoToAsync("//PrefTeachPage");
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
