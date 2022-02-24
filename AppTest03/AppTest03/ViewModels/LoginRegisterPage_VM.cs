using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppTest03.Views;
using AppTest03.Models;
using AppTest03.Views.Login;
using AppTest03.Views.Preferences;

namespace AppTest03.ViewModels
{
    class LoginRegisterPage_VM : BaseViewModel
    {
        private string email;   // Declaracion de vaarables
        private string password_1;
        private string password_2;
        public Command SaveCommand { get; }
        public LoginRegisterPage_VM() // Declaracion de loa comandos
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave() // validar datos no nulos
        {
            return !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(password_1)
                && !String.IsNullOrWhiteSpace(password_2);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password_1
        {
            get => password_1;
            set => SetProperty(ref password_1, value);
        }
        public string Password_2
        {
            get => password_2;
            set => SetProperty(ref password_2, value);
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave() // Boton escriturA
        {
            if (password_1 != password_2)
            {
                await Shell.Current.DisplayAlert("Error", "Las contraseñas no coinciden", "Ok");
            }
            else if (password_1.Length < 3)
            {
                await Shell.Current.DisplayAlert("Error", "La contraseña es muy corta", "Ok");
            }
            else if (email.Contains("@") && email.Contains("."))
			{
                var userData = await DataStore.GetUserAsync();
                userData.email = email.ToLower();
                userData.contrasena = password_1;
                var RegData = await DataStore.VerificarReg(userData);

                if (RegData.id_usuario != "NotReg")
                {
                    await Shell.Current.DisplayAlert("Error", "Este correo ya esta registrado", "Ok");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
					try
					{
                        await DataStore.UpdateUserAsync(userData); // Aplicar la interfaz en IDaraStore
                    }
					catch
					{
                        await AppShell.Current.DisplayAlert("Error", "Error de conexion \n  Verifique su red", "Ok");
                    }
					finally
					{
                        await AppShell.Current.Navigation.PushAsync(new PrefNamePage());
                    }
                }
            }
			else
			{
                await AppShell.Current.DisplayAlert("Aviso", "El formato del correo \n es incorrecto", "Ok");
            }
        } 
    }
}
