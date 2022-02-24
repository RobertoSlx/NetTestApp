using AppTest03.Models;
using AppTest03.Views.Preferences;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
    class PrefLearnPage_VM : BaseViewModel
    {
        private int Pressed = 0;

        private bool PB_0 = false, PB_1 = false, PB_2 = false, PB_3 = false,
                     PB_4 = false, PB_5 = false, PB_6 = false, PB_7 = false;

        private Color offColor = Color.Olive, onColor = Color.DarkOliveGreen;

        public Color Color_B0 = Color.Olive, Color_B1 = Color.Olive, Color_B2 = Color.Olive, Color_B3 = Color.Olive,
                Color_B4 = Color.Olive, Color_B5 = Color.Olive, Color_B6 = Color.Olive, Color_B7 = Color.Olive;

        public PrefLearnPage_VM() // Declaracion de loa comandos
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private bool ValidateSave() // validar datos no nulos
        {
            return Pressed != 0;
        }
        private async void OnSave() // Boton escriturA
        {
            t_usuarios_reg userData = await DataStore.GetUserAsync();

            if (PB_0) { userData.tacticas_aprendizaje_graficas = "1"; }
            else { userData.tacticas_aprendizaje_graficas = "0"; }
            if (PB_1) { userData.tacticas_aprendizaje_escuchar = "1"; }
            else { userData.tacticas_aprendizaje_escuchar = "0"; }
            if (PB_2) { userData.tacticas_aprendizaje_leeryescribir = "1"; }
            else { userData.tacticas_aprendizaje_leeryescribir = "0"; }
            if (PB_3) { userData.tacticas_aprendizaje_debatir = "1"; }
            else { userData.tacticas_aprendizaje_debatir = "0"; }
            if (PB_4) { userData.tacticas_aprendizaje_practicar = "1"; }
            else { userData.tacticas_aprendizaje_practicar = "0"; }
            if (PB_5) { userData.tacticas_aprendizaje_ejemplificar = "1"; }
            else { userData.tacticas_aprendizaje_ejemplificar = "0"; }
            if (PB_6) { userData.tacticas_aprendizaje_videos = "1"; }
            else { userData.tacticas_aprendizaje_videos = "0"; }
            if (PB_7) { userData.tacticas_aprendizaje_analizar = "1"; }
            else { userData.tacticas_aprendizaje_analizar = "0"; }

            //await DataStore.UpdateUserAsync(userData); // Aplicar la interfaz en IDaraStore
            //await Shell.Current.GoToAsync($"//{nameof(PrefTeachPage)}"); // Enviar a la siguiente pantalla

            try
            {
                bool DbResp = await DataStore.UpdateUserRegisterDB(userData);
                //await Shell.Current.GoToAsync($"//{nameof(PrefLearnPage)}");
                await AppShell.Current.Navigation.PushAsync(new PrefTeachPage());
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
    }
}
