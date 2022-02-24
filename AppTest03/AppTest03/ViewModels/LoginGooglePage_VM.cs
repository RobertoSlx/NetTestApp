using AppTest03.Models;
using AppTest03.Services;
using AppTest03.Views;
using AppTest03.Views.Login;
using AppTest03.Views.Preferences;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
    class LoginGooglePage_VM : BaseViewModel
    {
        public Command SaveCommand { get; }

        public LoginGooglePage_VM() // Declaracion de loa comandos
        {
            SaveCommand = new Command(OnSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private async void OnSave() // Boton escriturA
        {
            t_usuarios_reg userData = new t_usuarios_reg() // Clase temporal
            {
                //Id = Guid.NewGuid().ToString(),
                id_usuario = "MainUser",
                email = "GoogleAcount@Gmail.com",
                contrasena = "GoogPass",
                nombre = "GoogUser",
                habilidades = "101101",
                presentacion = "I like doing stuff"
            };

            await DataStore.UpdateUserAsync(userData); // Aplicar la interfaz en IDaraStore

            await Shell.Current.GoToAsync($"//{nameof(PrefNamePage)}"); // Enviar a la siguiente pantalla
        }

        public async void GoogleLogin(t_usuarios_reg userData)
		{
            t_usuarios_reg RegData = await DataStore.VerificarReg(userData);

            if (RegData.id_usuario == "NotReg")
            {
                await DataStore.UpdateUserAsync(userData);
                await Shell.Current.GoToAsync($"//{nameof(PrefNamePage)}");
            }
            else
            {
                await DataStore.UpdateUserAsync(RegData);
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
        }
    }
}
