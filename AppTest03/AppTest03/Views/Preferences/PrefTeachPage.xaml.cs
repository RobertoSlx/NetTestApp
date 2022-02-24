using AppTest03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest03.Views.Preferences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrefTeachPage : ContentPage
    {
        PrefTeachPage_VM _prefTeachPage;
        public PrefTeachPage()
        {
            InitializeComponent();
            BindingContext = _prefTeachPage = new PrefTeachPage_VM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _prefTeachPage.OnAppearing();
        }
    }
}