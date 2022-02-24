using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest03.Models
{
	public class t_usuarios_pub
	{
		public int Id { get; set; }

		public string id_publicacion { get; set; }

		public string id_usuario { get; set; }

		public DateTime fecha_publicacion { get; set; }

		public string titulo { get; set; }

		public string cuerpo { get; set; }

		public string relacion { get; set; }

		public string tag { get; set; }

		public int estatus { get; set; }
	}
}

