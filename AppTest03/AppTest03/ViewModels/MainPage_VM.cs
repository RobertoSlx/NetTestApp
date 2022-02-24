using AppTest03.Models;
using AppTest03.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
	class MainPage_VM : BaseViewModel
	{
		public Color[] StatusColor = new Color[4] { Color.Red, Color.Red, Color.Yellow, Color.Green };
		private t_usuarios_reg UserActual = new t_usuarios_reg();
		private PostList _selectedItem;

		public Command LoadItemsCommand { get; }
		public Command NuevaPregunta { get; }
		public ObservableCollection<PostList> recentPosts { get; }

		public MainPage_VM()
		{
			recentPosts = new ObservableCollection<PostList>();
			NuevaPregunta = new Command(OnNewQuestion);
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
		}
		async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;
			recentPosts.Clear();
			UserActual = await DataStore.GetUserAsync();

			try
			{
				List<t_usuarios_pub> postPool = await DataStore.GetRelevantPost(UserActual);

				foreach(t_usuarios_pub it in postPool)
				{
					recentPosts.Add(new PostList
					{
						postId = it.id_publicacion,
						postText = it.titulo,
						postImage = it.relacion + "_Ima.png",
						postColor = StatusColor[it.estatus]
					});
				}
			}
			catch
			{
				await AppShell.Current.DisplayAlert("Message", "No hay publicciones ", "Ok");
				IsBusy = false;
			}
			finally
			{
				IsBusy = false;

			}
		}

		public PostList Selected
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				OnListTapped(value);
			}
		}

		private async void OnListTapped(PostList post)
		{
			await AppShell.Current.GoToAsync($"{nameof(MainPage)}/{nameof(QuestionDetailPage)}?{nameof(QuestionDetailPage_VM.PostId)}={post.postId}");
		}

		private async void OnNewQuestion()
		{
			await AppShell.Current.Navigation.PushAsync(new QuestionNewPage());
		}

		public async void OnAppearing()
		{
			IsBusy = true;
			//await ExecuteLoadItemsCommand();
		}
	}
}
