using AppTest03.Models;
using AppTest03.Views;
using AppTest03.Services;
using AppTest03.Views.Preferences;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
    class PrefTeachPage_VM : BaseViewModel
    {
        private int Pressed = 0;

        private ImageSource p_foto;

        private bool PB_0 = false, PB_1 = false, PB_2 = false, PB_3 = false,
                     PB_4 = false;

        private Color offColor = Color.LightSalmon, onColor = Color.Salmon;

        public Color Color_B0 = Color.LightSalmon, Color_B1 = Color.LightSalmon, Color_B2 = Color.LightSalmon, Color_B3 = Color.LightSalmon,
                Color_B4 = Color.LightSalmon;
        public PrefTeachPage_VM() // Declaracion de loa comandos
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public ImageSource P_foto
        {
            get => p_foto;
            set => SetProperty(ref p_foto, value);
        }

        private bool ValidateSave() // validar datos no nulos
        {
            return Pressed != 0;
        }
        private async void OnSave() // Boton escriturA
        {
            t_usuarios_reg userData = await DataStore.GetUserAsync();

            if (PB_0) { userData.metodos_ensenanza_documental = "1"; }
            else { userData.metodos_ensenanza_documental = "0"; }
            if (PB_1) { userData.metodos_ensenanza_videoconferencias = "1"; }
            else { userData.metodos_ensenanza_videoconferencias = "0"; }
            if (PB_2) { userData.metodos_ensenanza_videos = "1"; }
            else { userData.metodos_ensenanza_videos = "0"; }
            if (PB_3) { userData.metodos_ensenanza_audios = "1"; }
            else { userData.metodos_ensenanza_audios = "0"; }
            if (PB_4) { userData.metodos_ensenanza_debates = "1"; }
            else { userData.metodos_ensenanza_debates = "0"; }

            try
            {
                //bool DbResp = await DataStore.UpdateUserRegisterDB(userData);
                await DataStore.UpdateUserAsync(userData);
                //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                await AppShell.Current.Navigation.PushAsync(new MainPage());
                //await AppShell.Current.GoToAsync($"//{new MainPage()}");
            }
            catch
            {
                await Shell.Current.DisplayAlert("Error", "Problema al actualizar los datos", "Ok");
            }

        }

        public Command SkillPress_0
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_0 && Pressed < 3)
                    {
                        PB_0 = true;
                        Pressed += 1;
                        ColorButton0 = onColor;
                    }
                    else if (PB_0)
                    {
                        PB_0 = false;
                        Pressed -= 1;
                        ColorButton0 = offColor;
                    }
                });
            }
        }
        public Color ColorButton0
        {
            get { return Color_B0; }
            set
            {
                if (value == Color_B0)
                    return;

                Color_B0 = value;
                OnPropertyChanged(nameof(ColorButton0));
            }
        }

        public Command SkillPress_1
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_1 && Pressed < 3)
                    {
                        PB_1 = true;
                        Pressed += 1;
                        ColorButton1 = onColor;
                    }
                    else if (PB_1)
                    {
                        PB_1 = false;
                        Pressed -= 1;
                        ColorButton1 = offColor;
                    }
                });
            }
        }
        public Color ColorButton1
        {
            get { return Color_B1; }
            set
            {
                if (value == Color_B1)
                    return;

                Color_B1 = value;
                OnPropertyChanged(nameof(ColorButton1));
            }
        }

        public Command SkillPress_2
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_2 && Pressed < 3)
                    {
                        PB_2 = true;
                        Pressed += 1;
                        ColorButton2 = onColor;
                    }
                    else if (PB_2)
                    {
                        PB_2 = false;
                        Pressed -= 1;
                        ColorButton2 = offColor;
                    }
                });
            }
        }
        public Color ColorButton2
        {
            get { return Color_B2; }
            set
            {
                if (value == Color_B2)
                    return;

                Color_B2 = value;
                OnPropertyChanged(nameof(ColorButton2));
            }
        }

        public Command SkillPress_3
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_3 && Pressed < 3)
                    {
                        PB_3 = true;
                        Pressed += 1;
                        ColorButton3 = onColor;
                    }
                    else if (PB_3)
                    {
                        PB_3 = false;
                        Pressed -= 1;
                        ColorButton3 = offColor;
                    }
                });
            }
        }
        public Color ColorButton3
        {
            get { return Color_B3; }
            set
            {
                if (value == Color_B3)
                    return;

                Color_B3 = value;
                OnPropertyChanged(nameof(ColorButton3));
            }
        }

        public Command SkillPress_4
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_4 && Pressed < 3)
                    {
                        PB_4 = true;
                        Pressed += 1;
                        ColorButton4 = onColor;
                    }
                    else if (PB_4)
                    {
                        PB_4 = false;
                        Pressed -= 1;
                        ColorButton4 = offColor;
                    }
                });
            }
        }
        public Color ColorButton4
        {
            get { return Color_B4; }
            set
            {
                if (value == Color_B4)
                    return;

                Color_B4 = value;
                OnPropertyChanged(nameof(ColorButton4));
            }
        }

        public async void OnAppearing()
        {
            t_usuarios_reg TempUser = await DataStore.GetUserAsync();
            //string imgUri = await DataStore.GetImageUrl(TempUser);
            //Uri uri = new Uri( string.Format(imgUri)); 
            //P_foto = ImageSource.FromUri(uri);
        }

        /*public async void EjecutarRegistro(UserData Data)
        {
            //AQUI SERIALIZO EL CONJUNTO DE DATOS
            var json = JsonConvert.SerializeObject(Data);
            //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var httpClient = new HttpClient();
            await httpClient.PostAsync(string.Format("https://registrousuariosapp.azurewebsites.net/api/t_usuarios_reg"), httpContent);

        }*/
    }
}
