using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.Models
{
	class TagList
	{
		public int id { get; set; }

		public string id_tag { get; set; }

		public string tag { get; set; }

		public string descripcion { get; set; }

		public string relacion { get; set; }

		public bool selected { get; set; }

		public bool tapped { get; set; }

		public Color BgColor { get; set; }

		public int CellH { get; set; }
	}
}
