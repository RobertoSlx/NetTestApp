using AppTest03.Models;
using AppTest03.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
	[QueryProperty(nameof(PostId), nameof(PostId))]
	class QuestionDetailPage_VM : BaseViewModel
    {
		private string postId, titulo, cuerpo, imaperf, _PubName;
        public Color[] StatusColor = new Color[3] { Color.White,Color.LightGreen,Color.LightGreen };
        public Color colorStat;
        private ImageSource _PubIma;
        public Command NuevaRespuesta { get; }
        public Command<ResList> DarPuntuacion { get; }
        public Command LoadItemsCommand { get; }
		internal async void OnAppearing()
		{
            await LoadPost();
		}
		public ObservableCollection<ResList> Responses { get; }

        public QuestionDetailPage_VM()
		{
            Responses = new ObservableCollection<ResList>();
            NuevaRespuesta = new Command(OnNewResponse);
            DarPuntuacion = new Command<ResList>(OnDarPuntos);
            LoadItemsCommand = new Command(async () => await LoadPost());
        }
        public string PostId
        {
            get
            {
                return postId;
            }
            set
            {
                postId = value;
                //LoadItemId(value);
            }
        }
        public string PubName
        {
            get => _PubName;
            set => SetProperty(ref _PubName, value);
        }
        public string Titulo
		{
            get => titulo;
            set => SetProperty(ref titulo, value);

        }
        public string Cuerpo
        {
            get => cuerpo;
            set => SetProperty(ref cuerpo, value);

        }
        public Color ColorStat
		{
            get => colorStat;
            set => SetProperty(ref colorStat, value);
        }
        public ImageSource ImaPerf
        {
            get => _PubIma;
            set => SetProperty(ref _PubIma, value);

        }
        private async void OnNewResponse()
		{
            await AppShell.Current.GoToAsync($"{nameof(QuestionDetailPage)}/{nameof(ResponseNewPage)}?{nameof(QuestionDetailPage_VM.PostId)}={postId}?{nameof(QuestionDetailPage_VM.PostId)}={postId}");
        }
        
        private async void OnDarPuntos(ResList resp)
        {

        }

        public async Task LoadPost()
		{
            IsBusy = true;
            Responses.Clear();

			try
			{
                t_usuarios_pub pub = await DataStore.GetPostAsync(PostId);

                if (pub.id_usuario != null)
                {
                    t_usuarios_reg Poster = await DataStore.GetUserInfoDB(pub.id_usuario);

                    PubName = Poster.nombre;

                    if (Poster.url_im_perfil == null)
                    { 
                        ImaPerf = ImageSource.FromFile("noprofile.png");
                    }
                    else
                    {
						if (Poster.url_im_perfil.Length < 20)
						{
                            ImaPerf = ImageSource.FromFile("noprofile.png");
                        }
						else
						{
                            Uri uri = new Uri(string.Format(Poster.url_im_perfil));
                            ImaPerf = ImageSource.FromUri(uri);
                        }
                        
                    }
                }
                else
                {
                    PubName = "Nuevo usuario";
                    ImaPerf = ImageSource.FromFile("noprofile.png");
                }

                Titulo = pub.titulo;
                Cuerpo = pub.cuerpo;

                List<t_usuarios_resp> Resp = await DataStore.GetPostResponses(PostId);

                if(Resp!= null)
				{
                    foreach(t_usuarios_resp resp in Resp)
					{
                        t_usuarios_reg user = await DataStore.GetUserInfoDB(resp.id_usuario);

                        ResList nRes = new ResList
                        {
                            Id = resp.Id,
                            id_resp = resp.id_respuesta,
                            id_usuario = resp.id_usuario,
                            Name = user.nombre,
                            Imagen = user.url_im_perfil,
                            fecha = resp.fecha_respuesta,
                            status = Color.White,
                            cuerpo = resp.cuerpo,
                            valoraciones = resp.valoraciones
                        };
                        if(resp.estatus == 0) { nRes.status = Color.LightGreen; }
						if (user.url_im_perfil.Length < 20) { nRes.Imagen = ImageSource.FromFile("noprofile.png"); }
						else
						{
                            Uri uri = new Uri(string.Format(user.url_im_perfil));
                            nRes.Imagen = ImageSource.FromUri(uri);
                        }
                        Responses.Add(nRes);
					}
                    Responses.OrderBy(x => x.valoraciones).ToList();
				}
			}
			catch
			{
                IsBusy = false;
                await AppShell.Current.DisplayAlert("Error", "No se pudo recuperar la inormacion", "Ok");
			}
			finally
			{
                IsBusy = false;
			}
		}
    }
}
