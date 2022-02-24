 using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.Models
{
	class ResList
	{
		public int Id { get; set; }
		public string id_resp { get; set; }
		public string id_usuario { get; set; }
		public string Name { get; set; }
		public ImageSource Imagen { get; set; }
		public DateTime fecha { get; set; }
		public Color status { get; set; }
		public string cuerpo { get; set; }
		public int valoraciones { get; set; }
	}
}
