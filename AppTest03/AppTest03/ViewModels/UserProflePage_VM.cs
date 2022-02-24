using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppTest03.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AppTest03.ViewModels
{
	class UserProflePage_VM : BaseViewModel
	{
		private string Utext;
		public string Mensaje
		{
			get => Utext;
			set => SetProperty(ref Utext, value);
		}
        public async void LoadItemId()
        {
            t_usuarios_reg Data = await DataStore.GetUserAsync();

            Data = await DataStore.GetUserRegisterDB(Data.Id);

            Mensaje = "Usuario 28"
                + Data.id_usuario + "\n"
                + " nombre " + Data.nombre + "\n"
                + " Email " + Data.email + "\n"
                + " Password " + Data.contrasena + "\n"
                + " BirthDate " + Data.fecha_nacimiento + "\n"
                + " StartDate " + Data.fecha_registro + "\n"
                + " Ocupation " + Data.ocupacion + "\n"
                + " Mensaje " + Data.presentacion + "\n"
                + " Skills " + Data.habilidades + "\n"
                + " Interes_Matematicas " + Data.matematicas + "\n"
                + " Interes_Espanol " + Data.espanol + "\n"
                + " Interes_Idiomas " + Data.idiomas + "\n"
                + " Interes_Historia " + Data.historia + "\n"
                + " Interes_Geografia " + Data.geografia + "\n"
                + " Interes_Quimica " + Data.quimica + "\n"
                + " Interes_Biologia " + Data.biologia + "\n"
                + " Interes_Fisica " + Data.fisica + "\n"
                + " Interes_Tecnologia " + Data.tecnologia + "\n"
                + " Interes_Arte " + Data.arte + "\n"
                + " Interes_Oficios " + Data.especializado + "\n"
                + " Aprender_Graficas " + Data.tacticas_aprendizaje_graficas + "\n"
                + " Aprender_Escuchar " + Data.tacticas_aprendizaje_escuchar + "\n"
                + " Aprender_LeerEscribir " + Data.tacticas_aprendizaje_leeryescribir + "\n"
                + " Aprender_Debatir " + Data.tacticas_aprendizaje_debatir + "\n"
                + " Aprender_Practica " + Data.tacticas_aprendizaje_practicar + "\n"
                + " Aprender_Ejemplificar " + Data.tacticas_aprendizaje_ejemplificar + "\n"
                + " Aprender_Videos " + Data.tacticas_aprendizaje_videos + "\n"
                + " Aprender_Analisis " + Data.tacticas_aprendizaje_analizar + "\n"
                + " Ensenanza_Documental " + Data.metodos_ensenanza_documental + "\n"
                + " Ensenanza_Videocon " + Data.metodos_ensenanza_videoconferencias + "\n"
                + " Ensenanza_Audios " + Data.metodos_ensenanza_videos + "\n"
                + " Ensenanza_Debates " + Data.metodos_ensenanza_audios + "\n"
                + " Ensenanza_Graficas " + Data.metodos_ensenanza_debates + "\n"
                ;
            try
            {
               //var Data = await DataStore.GetItemAsync(User_id);
            }
            catch (Exception)
            {
                Mensaje = "Failed to Load Item";
            }
        }
        public void OnAppearing()
        {
            LoadItemId();
            //IsBusy = true;
        }
    }
}
