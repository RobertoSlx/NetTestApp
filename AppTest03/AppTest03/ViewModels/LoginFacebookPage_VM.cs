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
    class LoginFacebookPage_VM : BaseViewModel
    {
        public Command SaveCommand { get; }

        public LoginFacebookPage_VM() // Declaracion de loa comandos
        {

            SaveCommand = new Command(OnSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public async void New_FbUser(t_usuarios_reg data)
		{
            t_usuarios_reg userData = new t_usuarios_reg() // Clase temporal
            {
                email = data.email,
                contrasena = "FB_User",
                nombre = data.nombre,
            };

            t_usuarios_reg RegData = await DataStore.VerificarReg(userData);

            if(RegData.id_usuario == "NotReg")
			{
                await DataStore.UpdateUserAsync(userData);
                await Shell.Current.GoToAsync($"//{nameof(PrefNamePage)}");
            }
			else
			{
                await DataStore.UpdateUserAsync(RegData);
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
                 // Enviar a la siguiente pantalla
        }
        private async void OnSave() // Boton escriturA
        {
            t_usuarios_reg userData = new t_usuarios_reg() // Clase temporal
            {
                //Id = Guid.NewGuid().ToString(),
                id_usuario = "MainUser",
                email = "Facebook@Hotmail.com",
                contrasena = "FacePass",
                nombre = "FaceUser",
                habilidades = "101101",
                presentacion = "I like doing stuff"
            };

            await DataStore.UpdateUserAsync(userData); // Aplicar la interfaz en IDaraStore
     
            await Shell.Current.GoToAsync($"//{nameof(PrefNamePage)}"); // Enviar a la siguiente pantalla
        }
    }
}
