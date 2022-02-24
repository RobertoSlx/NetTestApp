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
	public partial class UserProfilePage : ContentPage
	{
		UserProflePage_VM _userProfile;
		public UserProfilePage()
		{
			InitializeComponent();
			BindingContext = _userProfile = new UserProflePage_VM();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			_userProfile.OnAppearing();
		}
	}
}