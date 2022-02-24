using AppTest03.Models;
using AppTest03.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
    [QueryProperty(nameof(PostId), nameof(PostId))]
    class ResponseNewPage_VM : BaseViewModel
    {
        private string postId, cuerpo, titulo;
        public Command PublishResp { get; }

        public ResponseNewPage_VM()
		{
            PublishResp = new Command(OnResponded,Valdate);
            this.PropertyChanged += (_, __) => PublishResp.ChangeCanExecute();
        }
        public string Cuerpo
		{
            get => cuerpo;
            set
            {
                SetProperty(ref cuerpo, value);
            }
        }
        public string Titulo
        {
            get => titulo;
            set
            {
                SetProperty(ref titulo, value);
            }
        }
        public string PostId
        {
            get => postId;
            set
            {
                SetProperty(ref postId, value);
            }
        }
        private bool Valdate()
        {
            return !String.IsNullOrWhiteSpace(Cuerpo);
        }
        private async void OnResponded()
		{
            t_usuarios_reg User = await DataStore.GetUserAsync();

            t_usuarios_resp Resp = new t_usuarios_resp
            {
                fecha_respuesta = DateTime.Now,
                cuerpo = Cuerpo,
                estatus = 0,
                id_respuesta = Guid.NewGuid().ToString(),
                id_pregunta = PostId,
                id_usuario = User.id_usuario,
                valoraciones = 0,
                Id=0
            };

			try
			{
                await DataStore.PostResponseDB(Resp);
			}
			catch
			{
                await AppShell.Current.DisplayAlert("Error", "No se pudo subir \n la respuesta", "Ok");
			}
			finally
			{
                await AppShell.Current.GoToAsync("..");
            }
		}
        internal async void OnAppearing()
        {
            t_usuarios_pub Post = await DataStore.GetPostAsync(PostId);
            Titulo = Post.titulo;
        }
    }
}
