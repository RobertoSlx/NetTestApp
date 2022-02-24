using AppTest03.Models;
using AppTest03.Services;
using AppTest03.Views.Preferences;
using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Stormlion.ImageCropper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
    public class PrefNamePage_VM : BaseViewModel
    {
        MediaFile imageToUpload;
        FileStream FotoStream;
        string ImExt;

        public List<DayBD> Day { get; set; }
        public List<MonthBD> Month { get; set; }
        public List<YearBD> Year { get; set; }
        public Command PhotoCapture { get; set; }
        public Command PhotoSelect { get; set; }
        public Command TapPhoto { get; }

        private bool PicTaken = false;
        private string nombre;   // Declaracion de vaarables
        private DateTime birthDay = DateTime.Now;
        private string todayTime;
        private string ocupacion;
        private string presentacion;
        private String IdActual;
        private ImageSource p_foto;

        private int Pressed = 0;

        private bool PB_0 = false, PB_1 = false, PB_2 = false, PB_3 = false, 
                     PB_4 = false, PB_5 = false, PB_6 = false, PB_7 = false;

        private Color offColor = Color.Blue, onColor = Color.LightBlue;

        public Color Color_B0 = Color.Blue, Color_B1 = Color.Blue, Color_B2 = Color.Blue, Color_B3 = Color.Blue,
                Color_B4 = Color.Blue, Color_B5 = Color.Blue, Color_B6 = Color.Blue, Color_B7 = Color.Blue;

        public List<DayBD> GetDay()
		{
            var dayBD = new List<DayBD>()
            {
               new DayBD(){ ValueD=1},
               new DayBD(){ ValueD=2},
               new DayBD(){ ValueD=3},
               new DayBD(){ ValueD=4},
               new DayBD(){ ValueD=5},
               new DayBD(){ ValueD=6},
               new DayBD(){ ValueD=7},
               new DayBD(){ ValueD=8},
               new DayBD(){ ValueD=9},
               new DayBD(){ ValueD=10},
               new DayBD(){ ValueD=11},
               new DayBD(){ ValueD=12},
               new DayBD(){ ValueD=13},
               new DayBD(){ ValueD=14},
               new DayBD(){ ValueD=15},
               new DayBD(){ ValueD=16},
               new DayBD(){ ValueD=17},
               new DayBD(){ ValueD=18},
               new DayBD(){ ValueD=19},
               new DayBD(){ ValueD=20},
               new DayBD(){ ValueD=21},
               new DayBD(){ ValueD=22},
               new DayBD(){ ValueD=23},
               new DayBD(){ ValueD=24},
               new DayBD(){ ValueD=25},
               new DayBD(){ ValueD=26},
               new DayBD(){ ValueD=27},
               new DayBD(){ ValueD=28},
               new DayBD(){ ValueD=29},
               new DayBD(){ ValueD=30},
               new DayBD(){ ValueD=31},
            };
            return dayBD;
		}
        public List<MonthBD> GetMonth()
        {
            var MonthBD = new List<MonthBD>()
            {
               new MonthBD(){Key=1, ValueM="Ene"},
               new MonthBD(){Key=2, ValueM="Feb"},
               new MonthBD(){Key=3, ValueM="Mar"},
               new MonthBD(){Key=4, ValueM="Abr"},
               new MonthBD(){Key=5, ValueM="May"},
               new MonthBD(){Key=6, ValueM="Jun"},
               new MonthBD(){Key=7, ValueM="Jul"},
               new MonthBD(){Key=8, ValueM="Ago"},
               new MonthBD(){Key=9, ValueM="Sep"},
               new MonthBD(){Key=10, ValueM="Oct"},
               new MonthBD(){Key=11, ValueM="Nov"},
               new MonthBD(){Key=12, ValueM="Dic"}
            };
            return MonthBD;
        }
        public List<YearBD> GetYear()
        {
            var yearDB = new List<YearBD>()
            {
               new YearBD(){ ValueY=1950 },
               new YearBD(){ ValueY=1951 },
               new YearBD(){ ValueY=1952 },
               new YearBD(){ ValueY=1953 },
               new YearBD(){ ValueY=1954 },
               new YearBD(){ ValueY=1955 },
               new YearBD(){ ValueY=1956 },
               new YearBD(){ ValueY=1957 },
               new YearBD(){ ValueY=1958 },
               new YearBD(){ ValueY=1959 },
               new YearBD(){ ValueY=1960 },
               new YearBD(){ ValueY=1961 },
               new YearBD(){ ValueY=1962 },
               new YearBD(){ ValueY=1963 },
               new YearBD(){ ValueY=1964 },
               new YearBD(){ ValueY=1965 },
               new YearBD(){ ValueY=1966 },
               new YearBD(){ ValueY=1967 },
               new YearBD(){ ValueY=1968 },
               new YearBD(){ ValueY=1969 },
               new YearBD(){ ValueY=1970 },
               new YearBD(){ ValueY=1971 },
               new YearBD(){ ValueY=1972 },
               new YearBD(){ ValueY=1973 },
               new YearBD(){ ValueY=1974 },
               new YearBD(){ ValueY=1975 },
               new YearBD(){ ValueY=1976 },
               new YearBD(){ ValueY=1977 },
               new YearBD(){ ValueY=1978 },
               new YearBD(){ ValueY=1979 },
               new YearBD(){ ValueY=1980 },
               new YearBD(){ ValueY=1981 },
               new YearBD(){ ValueY=1982 },
               new YearBD(){ ValueY=1983 },
               new YearBD(){ ValueY=1984 },
               new YearBD(){ ValueY=1985 },
               new YearBD(){ ValueY=1986 },
               new YearBD(){ ValueY=1987 },
               new YearBD(){ ValueY=1988 },
               new YearBD(){ ValueY=1989 },
               new YearBD(){ ValueY=1990 },
               new YearBD(){ ValueY=1991 },
               new YearBD(){ ValueY=1992 },
               new YearBD(){ ValueY=1993 },
               new YearBD(){ ValueY=1994 },
               new YearBD(){ ValueY=1995 },
               new YearBD(){ ValueY=1996 },
               new YearBD(){ ValueY=1997 },
               new YearBD(){ ValueY=1998 },
               new YearBD(){ ValueY=1999 },
               new YearBD(){ ValueY=2000 },
               new YearBD(){ ValueY=2001 },
               new YearBD(){ ValueY=2002 },
               new YearBD(){ ValueY=2003 },
               new YearBD(){ ValueY=2004 },
               new YearBD(){ ValueY=2005 },
               new YearBD(){ ValueY=2006 },
               new YearBD(){ ValueY=2007 },
               new YearBD(){ ValueY=2008 },
               new YearBD(){ ValueY=2009 },
               new YearBD(){ ValueY=2010 },
               new YearBD(){ ValueY=2011 },
               new YearBD(){ ValueY=2012 },
               new YearBD(){ ValueY=2013 },
               new YearBD(){ ValueY=2014 },
               new YearBD(){ ValueY=2015 },
               new YearBD(){ ValueY=2016 },
               new YearBD(){ ValueY=2017 },
               new YearBD(){ ValueY=2018 },
               new YearBD(){ ValueY=2019 },
               new YearBD(){ ValueY=2020 }
            };
            return yearDB;
        }

        public class MonthBD
		{
            public int Key { get; set; }
            public string ValueM { get; set; }
        }
        public class YearBD
        {
            public int ValueY { get; set; }
        }
        public class DayBD
        {
            public int ValueD { get; set; }
        }

        private DayBD _SelectDay { get; set; }
        public DayBD selectDay
		{
            get { return _SelectDay; }
            set
			{
                if(_SelectDay != value)
				{
                    _SelectDay = value;
                }
			}
		}
        private MonthBD _SelectMonth { get; set; }
        public MonthBD SelectMonth
        {
            get { return _SelectMonth; }
            set
            {
                if (_SelectMonth != value)
                {
                    _SelectMonth = value;
                }
            }
        }
        private YearBD _SelectYear { get; set; }
        public YearBD SelectYear
        {
            get { return _SelectYear; }
            set
            {
                if (_SelectYear != value)
                {
                    _SelectYear = value;
                }
            }
        }

        public PrefNamePage_VM() // Declaracion de loa comandos
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            TapPhoto = new Command(OnTapImage);
            //imageToUpload = ImageSource.FromStream(() => new MemoryStream(byteData));

            Day = GetDay().OrderBy(t => t.ValueD).ToList();
            Month = GetMonth().OrderBy(j => j.ValueM).ToList();
            Year = GetYear().OrderBy(k => k.ValueY).ToList();
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        public Command SkillPress_0{ 
            get {
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
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private bool ValidateSave() // validar datos no nulos
        {
            return (!String.IsNullOrWhiteSpace(nombre)
                && !String.IsNullOrWhiteSpace(ocupacion)
                && Pressed > 0);
        }

        public string Name
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }
        public string Ocupation
        {
            get => ocupacion;
            set => SetProperty(ref ocupacion, value);
        }
        public string Presentation
        {
            get => presentacion;
            set => SetProperty(ref presentacion, value);
        }
        public ImageSource P_foto
        {
            get => p_foto;
            set => SetProperty(ref p_foto, value);
        }
        public FileStream PhotoStream
		{
            get => FotoStream;
            set => SetProperty(ref FotoStream, value);
        }

        public DateTime Bday
        {
            get => birthDay;
            set => SetProperty(ref birthDay, value);
        }
        public String IdOnGui
        {
            get => IdActual;
            set => SetProperty(ref IdActual, value);
        }
        public Color ColorButton0
        {
            get{ return Color_B0; }
            set 
            {
                if (value == Color_B0)
                    return;

                Color_B0 = value;
                OnPropertyChanged(nameof(ColorButton0));
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

        private async void OnTapImage()
        {
            var action = await App.Current.MainPage.DisplayActionSheet("Escojer imagen", "Cancelar", null, "Toma una Foto", "Selecciona del album");

            if(action== "Toma una Foto")
			{
                var camara = new StoreCameraMediaOptions();
                camara.MaxWidthHeight = 600;
                camara.PhotoSize = PhotoSize.MaxWidthHeight;
                camara.SaveToAlbum = true;
                var foto = await CrossMedia.Current.TakePhotoAsync(camara);
                if (foto != null)
                {
                    P_foto = ImageSource.FromStream(() =>
                    {
                        return foto.GetStream();
                    });
                    imageToUpload = foto;
                    var filename = foto.Path;
                    filename = Path.GetFileName(filename);
                    ImExt = Path.GetExtension(filename);
                    PicTaken = true;
                }

                new ImageCropper()
                {
                    PageTitle = "Test Title",
                    AspectRatioX = 1,
                    AspectRatioY = 1,
                    CropShape = ImageCropper.CropShapeType.Rectangle,
                    SelectSourceTitle = "Select source",
                    TakePhotoTitle = "Take Photo",
                    PhotoLibraryTitle = "Photo Library",
                    Success = (imageFile) =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            P_foto = ImageSource.FromFile(imageFile);
                        });
                    }
                };

            }
            if (action == "Selecciona del album")
            {
                var result = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions(){ PhotoSize = PhotoSize.MaxWidthHeight,MaxWidthHeight=600});

                if (result != null)
                {
                    P_foto = ImageSource.FromStream(() =>
                    {
                        return result.GetStream();
                    });
                    imageToUpload = result;
                    var filename = result.Path;
                    filename = Path.GetFileName(filename);
                    ImExt = Path.GetExtension(filename);
                    PicTaken = true;
                }
            }
        }
        public void New_Picure(FileStream stream, string Ext)
		{
            ImExt = Ext;
            PicTaken = true;
            FotoStream = stream;
		}
        private async void OnSave() // Boton escriturA
        {
            t_usuarios_reg userData = await DataStore.GetUserAsync();
            userData.id_usuario = Guid.NewGuid().ToString();
            userData.nombre = Name;   // Declaracion de variabrables
            string dateStr = SelectYear.ValueY.ToString() + "-" + SelectMonth.ValueM.ToString() + "-" + selectDay.ValueD.ToString();
            //userData.fecha_nacimiento = Bday;
            userData.fecha_nacimiento = Convert.ToDateTime(dateStr);
            userData.fecha_registro = DateTime.Now;
            userData.ocupacion = ocupacion;
            userData.presentacion = presentacion;

            string Skills = "00000000";
            char[] Skills_C = Skills.ToCharArray();

            if (PB_0) { Skills_C[0] = '1'; };
            if (PB_1) { Skills_C[1] = '1'; };
            if (PB_2) { Skills_C[2] = '1'; };
            if (PB_3) { Skills_C[3] = '1'; };
            if (PB_4) { Skills_C[4] = '1'; };
            if (PB_5) { Skills_C[5] = '1'; };
            if (PB_6) { Skills_C[6] = '1'; };
            if (PB_7) { Skills_C[7] = '1'; };

            Skills = new string(Skills_C);
            userData.habilidades = Skills;

            try
            {
				if (PicTaken)
				{
                    //userData.url_im_perfil = await DataStore.UploadImage(imageToUpload.GetStream(), userData.id_usuario, ImExt);
                    userData.url_im_perfil = await DataStore.UploadImage(FotoStream, userData.id_usuario, ImExt);
                }
				else
				{
                    userData.url_im_perfil = await DataStore.GetImageUrl(userData);
				}
            }
            catch
            {
                await Shell.Current.DisplayAlert("Error", "La imagen no se pudo actualizar", "Ok");
            }
			finally
			{
				try
				{
                    t_usuarios_reg DbData = await DataStore.PostUserRegisterDB(userData);
                    await DataStore.UpdateUserAsync(DbData); // Aplicar la interfaz en IDaraStore
                    //await Shell.Current.GoToAsync($"//{nameof(PrefInterestPage)}"); // Enviar a la siguiente pantalla
                    await AppShell.Current.Navigation.PushAsync(new PrefInterestPage());
                }
				catch
				{
                    await Shell.Current.DisplayAlert("Error", "Error de conexion \n Verifique su red", "Ok");
                }
            }
        }
        public async void OnAppearing()
        {
            t_usuarios_reg userData = await DataStore.GetUserAsync();
            if(userData.nombre == "Test User") { Name = ""; }
			else { Name = userData.nombre; }
            Ocupation = userData.ocupacion;
            presentacion = userData.presentacion;
            selectDay = Day[1];
            SelectMonth = Month[1];
            SelectYear = Year[50];
			//IsBusy = true;
			if (userData.url_im_perfil.Contains("noprofile.png"))
			{
                P_foto = ImageSource.FromFile("noprofile.png");
			}
			else
			{
                Uri uri = new Uri(string.Format(userData.url_im_perfil));
                P_foto = ImageSource.FromUri(uri);
            }
        }
    }
}
