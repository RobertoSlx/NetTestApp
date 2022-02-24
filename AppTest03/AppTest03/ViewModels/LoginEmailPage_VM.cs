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
    class LoginEmailPage_VM : BaseViewModel
    {
        private string email;   // Declaracion de vaarables

        private string password;
        public Command RegisterEmail { get; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public LoginEmailPage_VM() // Declaracion de loa comandos
        {
            RegisterEmail = new Command(RegisterEmailButt);

            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            CancelCommand = new Command(OnCancel);
        }

        private async void RegisterEmailButt(object obj) // Pantalla de registro
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}/{nameof(LoginEmailPage)}/{nameof(LoginRegisterPage)}");
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private bool ValidateSave() // validar datos no nulos
        {
            return !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password);
        }
        private async void OnSave() // Boton escriturA
        {
            if (email.Contains("@") && email.Contains("."))
            {
                t_usuarios_reg userData = new t_usuarios_reg() // Clase temporal
                {
                    email = email.ToLower(),
                    contrasena = password
                };

                t_usuarios_reg RegData = await DataStore.VerificarReg(userData);

                if (RegData.id_usuario == "PassErr" || RegData.id_usuario == "NotReg")
                {
                    Password = "";
                    await Shell.Current.DisplayAlert("Message", "Contraseña o Correo Equivocado", "Ok");
                }
                else
                {
                    await DataStore.UpdateUserAsync(RegData);
                    //await Shell.Current .GoToAsync($"//{nameof(MainPage)}");
                    await AppShell.Current.Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                await AppShell.Current.DisplayAlert("Aviso", "El formato del correo \n es incorrecto", "Ok");
            }
            //await Shell.Current.GoToAsync($"//{nameof(MainPage)}"); // Enviar a la siguiente pantalla
        }
    }
}