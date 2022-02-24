using AppTest03.Models;
using AppTest03.Views.Preferences;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{
	class QuestionNewPage_VM : BaseViewModel
	{
		private TagList _SelectedListed, _SelectedRemove, _SelectedAdd, _SelectedSelected;
		private AssList _AssSelect;
		private string asignStr = "", imageStr = "", _BodyString, _TitleString;
		private bool _AssEnable = false, _TagEnable = false, _TextEnable = false;

		public ObservableCollection<TagList> SelectedTags { get; set; }
		public ObservableCollection<TagList> ListedTags { get; set; }
		public ObservableCollection<AssList> MaterList { get; set; }

		public List<TagList> AsignList { get; }
		public Command<string> ToggleOpt { get; }
		public Command<TagList> SelectListTapp { get; }
		public Command<TagList> DeselectListTapp { get; }
		public Command<TagList> SelectSelectTapp { get; }
		public Command<TagList> DeselectSelectTapp { get; }
		public Command<TagList> RemoveItemTapp { get; }
		public Command<TagList> AddItemTapp { get; }

		public Command PubQuestion { get; }

		private t_usuarios_reg UserActual = new t_usuarios_reg();
		private TagList TempTagL { get; set; }
		private TagList TempTagS { get; set; }

		public Color ColorOn = Color.LightGreen, ColorOff = Color.LightGray;

		int _Hreq = 0;
		bool _AutoEn = false;

		public QuestionNewPage_VM()
		{
			AsignList = new List<TagList>();

			SelectedTags = new ObservableCollection<TagList>();
			ListedTags = new ObservableCollection<TagList>();
			MaterList = new ObservableCollection<AssList>
			{
				new AssList{materia="Matematicas", imagen="matematicas_Ima.png"},
				new AssList{materia="Espanol", imagen="espanol_Ima.png"},
				new AssList{materia="Idiomas", imagen="idiomas_Ima.png"},
				new AssList{materia="Historia", imagen="historia_Ima.png"},
				new AssList{materia="Geografia", imagen="geografia_Ima.png"},
				new AssList{materia="Quimica", imagen="quimica_Ima.png"},
				new AssList{materia="Biologia", imagen="biologia_Ima.png"},
				new AssList{materia="Fisica", imagen="fisica_Ima.png"},
				new AssList{materia="Tecnologia", imagen="tecnologia_Ima.png"},
				new AssList{materia="Arte", imagen="arte_Ima.png"},
				new AssList{materia="Oficios", imagen="oficios_Ima.png"},
				new AssList{materia="Superior", imagen="superior_Ima.png"}
			};

			SelectListTapp = new Command<TagList>(OnListTapped);
			AddItemTapp = new Command<TagList>(OnItemAdded);
			RemoveItemTapp = new Command<TagList>(OnItemRemoved);
			SelectSelectTapp = new Command<TagList>(OnSelectTapped);
			ToggleOpt = new Command<string>(ToggleSelction);

			PubQuestion = new Command(SaveQuestion, Valdate);
			this.PropertyChanged += (_, __) => PubQuestion.ChangeCanExecute();

			TempTagL = null;
			TempTagS = null;
		}

		public TagList SelectedListed
		{
			get => _SelectedListed;
			set
			{
				SetProperty(ref _SelectedListed, value);
				OnListTapped(value);
			}
		}
		public TagList SelectedSelected
		{
			get => _SelectedSelected;
			set
			{
				SetProperty(ref _SelectedSelected, value);
				OnItemRemoved(value);
			}
		}
		public AssList AssSelected
		{
			get => _AssSelect;
			set
			{
				SetProperty(ref _AssSelect, value);
				OnAssSelected(value);
			}
		}

		public bool AssEnable
		{
			get => _AssEnable;
			set
			{
				SetProperty(ref _AssEnable, value);
			}
		}
		public bool TagEnable
		{
			get => _TagEnable;
			set
			{
				SetProperty(ref _TagEnable, value);
			}
		}
		public bool TextEnable
		{
			get => _TextEnable;
			set
			{
				SetProperty(ref _TextEnable, value);
			}
		}

		public TagList SelectedAdd
		{
			get => _SelectedAdd;
			set
			{
				SetProperty(ref _SelectedAdd, value);
				OnItemAdded(value);
			}
		}
		public TagList SelectedRemove
		{
			get => _SelectedRemove;
			set
			{
				SetProperty(ref _SelectedRemove, value);
				OnItemRemoved(value);
			}
		}

		public string ImageStr
		{
			get => imageStr;
			set => SetProperty(ref imageStr, value);
		}
		public string AsignStr
		{
			get => asignStr;
			set => SetProperty(ref asignStr, value);
		}
		public string BodyString
		{
			get => _BodyString;
			set => SetProperty(ref _BodyString, value);
		}
		public string TitleString
		{
			get => _TitleString;
			set => SetProperty(ref _TitleString, value);
		}
		public bool AutoEn
		{
			get => _AutoEn;
			set => SetProperty(ref _AutoEn, value);
		}
		public int Hreq
		{
			get => _Hreq;
			set => SetProperty(ref _Hreq, value);
		}

		async void OnListTapped(TagList item)
		{
			if (item == null)
				return;
			if (SelectedListed != null)
			{
				if (TempTagL != null)
				{
					TempTagL.tapped = false;
					TempTagL.BgColor = ColorOff;
					TempTagL.CellH = 20;
					UpdateList(TempTagL);
					ListedTags[ListedTags.IndexOf(TempTagL)] = TempTagL;
				}

				SelectedListed.tapped = true;
				SelectedListed.BgColor = ColorOn;
				SelectedListed.CellH = 50;
				UpdateList(SelectedListed);

				TempTagL = SelectedListed;
			}
		}
		async void OnSelectTapped(TagList item)
		{
			if (item == null)
				return;
			if (SelectedSelected != null)
			{
				if (TempTagS != null)
				{
					TempTagS.tapped = false;
					TempTagS.BgColor = ColorOff;
					SelectedTags[SelectedTags.IndexOf(TempTagS)] = TempTagS;
				}

				SelectedSelected.tapped = true;
				SelectedSelected.BgColor = ColorOn;
				SelectedTags[SelectedTags.IndexOf(SelectedSelected)] = SelectedSelected;

				TempTagS = SelectedSelected;
			}
		}

		async void OnItemAdded(TagList item)
		{
			TempTagL = null;
			if (item == null)
				return;
			SelectedTags.Add(item);
			AsignList.FirstOrDefault(s => s.tag == item.tag).selected = true;
			if (SelectedTags.Count > 2) { Hreq = 100; }
			else if (SelectedTags.Count > 0) { Hreq = 50; }
			rewriteList();
		}
		async void OnItemRemoved(TagList item)
		{
			if (item == null)
				return;
			SelectedTags.Remove(item);
			AsignList.FirstOrDefault(s => s.tag == item.tag).selected = false;
			AsignList.FirstOrDefault(s => s.tag == item.tag).tapped = false;
			if (SelectedTags.Count < 1) { Hreq = 0; }
			else if (SelectedTags.Count < 3) { Hreq = 50; }
			rewriteList();
		}
		async void OnAssSelected(AssList item)
		{
			AsignStr = item.materia.ToLower();
			ImageStr = item.imagen;
			AssEnable = false;
			TagEnable = false;
			TextEnable = true;
			TagConfig();
		}
		async void ToggleSelction(string mode)
		{
			switch (mode)
			{
				case "2":
					AssEnable = false;
					TagEnable = false;
					if (TextEnable) { TextEnable = false; }
					else { TextEnable = true; }
					break;
				case "3":
					AssEnable = false;
					TextEnable = false;
					if (TagEnable) { TagEnable = false; }
					else { TagEnable = true; }
					break;
				case "1":
					TagEnable = false;
					TextEnable = false;
					if (TagEnable) { AssEnable = false; }
					else { AssEnable = true; }
					break;
				default:
					TagEnable = false;
					TextEnable = false;
					AssEnable = false;
					break;
			}
		}

		private void rewriteList()
		{
			ListedTags.Clear();

			foreach ( var n in AsignList)
			{
				if (!n.selected) { ListedTags.Add(n); }
			}
		}
		private void UpdateList(TagList item)
		{
			ListedTags[ListedTags.IndexOf(item)] = item;
		}
		private async void TagConfig()
		{
			if (AsignStr != "" && AsignStr != "Selecciona Campo")
			{
				TempTagL = null;
				TempTagS = null;
				AsignList.Clear();
				SelectedTags.Clear();
				List<t_usuarios_tags> TagRep = await DataStore.GetAsignmentTags(AsignStr);

				foreach (var n in TagRep)
				{
					AsignList.Add(new TagList
					{
						id_tag = n.id_tag,
						tag = n.tag,
						descripcion = n.descripcion,
						relacion = n.relacion,
						selected = false,
						tapped = false,
						BgColor = ColorOff,
						CellH = 20
					});
				}
				rewriteList();
			}
		}
		public async void OnAppearing()
		{
			SelectedListed = null;
			await DataStore.SetTagsAsync();
			AsignStr = "Selecciona Campo";
			ImageStr = "tree.jpg";
		}

		private bool Valdate()
		{
			return !String.IsNullOrWhiteSpace(_BodyString) &&
				   !String.IsNullOrWhiteSpace(_TitleString);
		}
		private async void SaveQuestion()
		{
			if (AsignStr == "" && AsignStr == "Selecciona Campo")
			{
				await AppShell.Current.DisplayAlert("Aviso", "Selecciona el campo \n de la pregunta", "Ok");
			}
			else if (SelectedTags.Count < 1)
			{
				await AppShell.Current.DisplayAlert("Aviso", "Selecciona al menos \n una Tag", "Ok");
			}
			else
			{
				UserActual = await DataStore.GetUserAsync();

				t_usuarios_pub NewPub = new t_usuarios_pub
				{
					id_publicacion = Guid.NewGuid().ToString(),
					id_usuario = UserActual.id_usuario,
					fecha_publicacion = DateTime.Now,
					titulo = TitleString,
					cuerpo = BodyString,
					relacion = AsignStr,
					estatus = 0
				};

				foreach (TagList t in SelectedTags)
				{
					NewPub.tag = NewPub.tag + t.id_tag + ",";
				}

				try
				{
					await DataStore.PostPublicationDB(NewPub);
				}
				catch
				{
					await AppShell.Current.DisplayAlert("Error", "No se pudo subir \n la Pregunta", "Ok");
				}
				finally
				{
					await AppShell.Current.GoToAsync("..");
				}
			}
		}
	}

	public class AssList
	{
		public string materia { get; set; }
		public string imagen { get; set; }

	}
}
