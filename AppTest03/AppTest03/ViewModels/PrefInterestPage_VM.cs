using AppTest03.Models;
using AppTest03.Views.Preferences;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
    class PrefInterestPage_VM : BaseViewModel
    {
        private int Pressed = 0;

        private bool PB_0 = false, PB_1 = false, PB_2 = false, PB_3 = false,
                     PB_4 = false, PB_5 = false, PB_6 = false, PB_7 = false,
                    PB_8 = false, PB_9 = false, PB_10 = false, PB_11 = false;

         Color offColor = Color.White, onColor = Color.LightGray;

        public Color Color_B0 = Color.White, Color_B1 = Color.White, Color_B2 = Color.White, Color_B3 = Color.White,
                Color_B4 = Color.White, Color_B5 = Color.White, Color_B6 = Color.White, Color_B7 = Color.White,
                Color_B8 = Color.White, Color_B9 = Color.White, Color_B10 = Color.White, Color_B11 = Color.White;

        public PrefInterestPage_VM() // Declaracion de loa comandos
        {
            Pressed = 0;
            //t_usuarios_reg user = await DataStore.GetUserAsync();
            SaveCommand = new Command(OnSave,ValidateSave);
            this.PropertyChanged +=(_, __) => SaveCommand.ChangeCanExecute();
        }

        public Command SaveCommand{get;}
        public Command CancelCommand { get; }

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

        public Command SkillPress_5
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_5 && Pressed < 3)
                    {
                        PB_5 = true;
                        Pressed += 1;
                        ColorButton5 = onColor;
                    }
                    else if (PB_5)
                    {
                        PB_5 = false;
                        Pressed -= 1;
                        ColorButton5 = offColor;
                    }
                });
            }
        }
        public Color ColorButton5
        {
            get { return Color_B5; }
            set
            {
                if (value == Color_B5)
                    return;

                Color_B5 = value;
                OnPropertyChanged(nameof(ColorButton5));
            }
        }

        public Command SkillPress_6
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_6 && Pressed < 3)
                    {
                        PB_6 = true;
                        Pressed += 1;
                        ColorButton6 = onColor;
                    }
                    else if (PB_6)
                    {
                        PB_6 = false;
                        Pressed -= 1;
                        ColorButton6 = offColor;
                    }
                });
            }
        }
        public Color ColorButton6
        {
            get { return Color_B6; }
            set
            {
                if (value == Color_B6)
                    return;

                Color_B6 = value;
                OnPropertyChanged(nameof(ColorButton6));
            }
        }

        public Command SkillPress_7
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_7 && Pressed < 3)
                    {
                        PB_7 = true;
                        Pressed += 1;
                        ColorButton7 = onColor;
                    }
                    else if (PB_7)
                    {
                        PB_7 = false;
                        Pressed -= 1;
                        ColorButton7 = offColor;
                    }
                });
            }
        }
        public Color ColorButton7
        {
            get { return Color_B7; }
            set
            {
                if (value == Color_B7)
                    return;

                Color_B7 = value;
                OnPropertyChanged(nameof(ColorButton7));
            }
        }

        public Command SkillPress_8
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_8 && Pressed < 3)
                    {
                        PB_8 = true;
                        Pressed += 1;
                        ColorButton8 = onColor;
                    }
                    else if (PB_8)
                    {
                        PB_8 = false;
                        Pressed -= 1;
                        ColorButton8 = offColor;
                    }
                });
            }
        }
        public Color ColorButton8
        {
            get { return Color_B8; }
            set
            {
                if (value == Color_B8)
                    return;

                Color_B8 = value;
                OnPropertyChanged(nameof(ColorButton8));
            }
        }

        public Command SkillPress_9
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_9 && Pressed < 3)
                    {
                        PB_9 = true;
                        Pressed += 1;
                        ColorButton9 = onColor;
                    }
                    else if (PB_9)
                    {
                        PB_9 = false;
                        Pressed -= 1;
                        ColorButton9 = offColor;
                    }
                });
            }
        }
        public Color ColorButton9
        {
            get { return Color_B9; }
            set
            {
                if (value == Color_B9)
                    return;

                Color_B9 = value;
                OnPropertyChanged(nameof(ColorButton9));
            }
        }

        public Command SkillPress_10
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_10 && Pressed < 3)
                    {
                        PB_10 = true;
                        Pressed += 1;
                        ColorButton10 = onColor;
                    }
                    else if (PB_10)
                    {
                        PB_10 = false;
                        Pressed -= 1;
                        ColorButton10 = offColor;
                    }
                });
            }
        }
        public Color ColorButton10
        {
            get { return Color_B10; }
            set
            {
                if (value == Color_B10)
                    return;

                Color_B10 = value;
                OnPropertyChanged(nameof(ColorButton10));
            }
        }

        public Command SkillPress_11
        {
            get
            {
                return new Command(() =>
                {
                    if (!PB_11 && Pressed < 3)
                    {
                        PB_11 = true;
                        Pressed += 1;
                        ColorButton11 = onColor;
                    }
                    else if (PB_11)
                    {
                        PB_11 = false;
                        Pressed -= 1;
                        ColorButton11 = offColor;
                    }
                });
            }
        }
        public Color ColorButton11
        {
            get { return Color_B11; }
            set
            {
                if (value == Color_B11)
                    return;

                Color_B11 = value;
                OnPropertyChanged(nameof(ColorButton11));
            }
        }

        private bool ValidateSave() // validar datos no nulos
        {
            return Pressed != 0;
        }
        private async void OnSave() // Boton escriturA
        {
            t_usuarios_reg userData = await DataStore.GetUserAsync();

            if (PB_0) { userData.matematicas = "1"; }
            else { userData.matematicas = "0"; }
            if (PB_1) { userData.espanol = "1"; }
            else { userData.espanol = "0"; }
            if (PB_2) { userData.idiomas = "1"; }
            else { userData.idiomas = "0"; }
            if (PB_3) { userData.historia = "1"; }
            else { userData.historia = "0"; }
            if (PB_4) { userData.geografia = "1"; }
            else { userData.geografia= "0"; }
            if (PB_5) { userData.quimica = "1"; }
            else { userData.quimica = "0"; }
            if (PB_6) { userData.biologia = "1"; }
            else { userData.biologia = "0"; }
            if (PB_7) { userData.fisica = "1"; }
            else { userData.fisica = "0"; }
            if (PB_8) { userData.tecnologia = "1"; }
            else { userData.tecnologia = "0"; }
            if (PB_9) { userData.arte = "1"; }
            else { userData.arte = "0"; }
            if (PB_10) { userData.especializado = "1"; }
            else { userData.especializado = "0"; }
            if (PB_11) { userData.metodos_ensenanza_graficos = "1"; }
            else { userData.metodos_ensenanza_graficos = "0"; }

			try
			{
                await DataStore.UpdateUserRegisterDB(userData);
                //await DataStore.UpdateUserAsync(userData);
			}
			catch
			{
                await AppShell.Current.DisplayAlert("Error", "Error de conexion \n Verifique su red", "Ok");
            }
			finally
			{
                //await Shell.Current.GoToAsync($"//{nameof(PrefTagsPage)}"); // Enviar a la siguiente pantalla
                await AppShell.Current.Navigation.PushAsync(new PrefTagsPage());
            }
        }
    }
}
