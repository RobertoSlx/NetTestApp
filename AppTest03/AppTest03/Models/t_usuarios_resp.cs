using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest03.Models
{
	public class t_usuarios_resp
	{
		public int Id { get; set; }

		public string id_respuesta { get; set; }

		public string id_pregunta { get; set; }

		public string id_usuario { get; set; }

		public DateTime fecha_respuesta { get; set; }

		public string cuerpo { get; set; }

		public int estatus { get; set; }

		public int valoraciones { get; set; }
	}
}
