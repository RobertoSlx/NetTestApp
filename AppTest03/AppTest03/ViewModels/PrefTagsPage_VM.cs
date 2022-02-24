using AppTest03.Models;
using AppTest03.Views.Preferences;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTest03.ViewModels
{	class PrefTagsPage_VM : BaseViewModel
	{
		private TagList _SelectedListed, _SelectedRemove, _SelectedAdd, _SelectedSelected;
		private string asignStr = "", imageStr = "",searchStr="";
		public ObservableCollection<TagList> SelectedTags { get; set; }
		public ObservableCollection<TagList> ListedTags { get; set; }
		public List<TagList> AsignList { get; }
		public Command<TagList> SelectListTapp { get; }
		public Command<TagList> DeselectListTapp { get; }
		public Command<TagList> SelectSelectTapp { get; }
		public Command<TagList> DeselectSelectTapp { get; }
		public Command<TagList> RemoveItemTapp { get; }
		public Command<TagList> AddItemTapp { get; }
		public Command<string> SearchStr { get; }
		public Command NextTag { get; }

		private t_usuarios_reg UserActual = new t_usuarios_reg();
		private TagList TempTagL{ get; set; }
		private TagList TempTagS { get; set; }

		public Color ColorOn = Color.LightGreen, ColorOff = Color.LightGray;

		string[] Asign = new string[4] { "", "", "", "" };
		int N_mat = -1, _Hreq = 50;
		bool _AutoEn = false;

		public PrefTagsPage_VM()
		{
			Title = "Browse";
			AsignList = new List<TagList>();
			SelectedTags = new ObservableCollection<TagList>();
			ListedTags = new ObservableCollection<TagList>();
			SelectListTapp = new Command<TagList>(OnListTapped);
			AddItemTapp = new Command<TagList>(OnItemAdded); 
			RemoveItemTapp = new Command<TagList>(OnItemRemoved);
			SelectSelectTapp = new Command<TagList>(OnSelectTapped);
			NextTag = new Command(NextTagButt);
			//SearchStr = new Command<string>(SearchBar);
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
		
		public String SearchString
		{
			get => searchStr;
			set
			{
				SetProperty(ref searchStr, value);
				SearchBar(value);
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
				if(TempTagL != null)
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
				//ListedTags[ListedTags.IndexOf(SelectedListed)] = SelectedListed;

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
			rewriteList();
		}
		async void OnItemRemoved(TagList item)
		{
			if (item == null)
				return;
			SelectedTags.Remove(item);
			AsignList.FirstOrDefault(s => s.tag == item.tag).selected = false;
			AsignList.FirstOrDefault(s => s.tag == item.tag).tapped = false;
			if (SelectedTags.Count < 3) { Hreq = 50; }
			rewriteList();
		}

		public async Task<bool> SearchBar(string e)
		{
			try
			{
				var dataEmpty = ListedTags.Where(i => i.tag.ToLower().Contains(e.ToLower()));

				if (string.IsNullOrWhiteSpace(e)){ rewriteList(); }
				else if (dataEmpty.Count() == 0){ rewriteList(); }
				else
				{
					ListedTags.Clear();
					foreach (TagList i in dataEmpty) 
					{ 
						ListedTags.Add(i);
						UpdateList(i);
					}
				}
				int res = ListedTags.Count();
			}
			catch (Exception ex)
			{
				rewriteList();
			}
			return await Task.FromResult(true);
		}

		private async void NextTagButt() // validar datos no nulos
		{
			if (SelectedTags.Count > 0)
			{
				NextTagConfig();
			}
			else
			{
				await Shell.Current.DisplayAlert("Aviso", "Seleccione al menos \n 1 tag", "Ok");
			}
		}
		private async void NextTagConfig() 
		{
			if(N_mat >= 0)
			{
				UserActual = await DataStore.GetUserAsync();

				foreach(TagList t in SelectedTags)
				{
					UserActual.user_tags =UserActual.user_tags+t.id_tag + ",";
				}
				await DataStore.UpdateUserAsync(UserActual);
			}
			
			N_mat += 1;

			if( Asign[N_mat] != "")
			{
				TempTagL = null;
				TempTagS = null;
				AsignList.Clear();
				SelectedTags.Clear();
				List<t_usuarios_tags> TagRep = await DataStore.GetAsignmentTags(Asign[N_mat]);
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
				ImageStr = Asign[N_mat] + "_Ima.png";
				AsignStr = Asign[N_mat];
			}
			else
			{
				try
				{
					bool DbResp = await DataStore.UpdateUserRegisterDB (UserActual);
					//await DataStore.UpdateUserAsync(UserActual);
					//await Shell.Current.GoToAsync($"//{nameof(PrefLearnPage)}");
					await AppShell.Current.Navigation.PushAsync(new PrefLearnPage());
				}
				catch
				{
					await Shell.Current.DisplayAlert("Error", "Problema al actualizar los datos", "Ok");
				}
			}
			
		}
		private void rewriteList()
		{
			ListedTags.Clear();
			foreach (var n in AsignList)
			{
				if (!n.selected) { ListedTags.Add(n); }
			}
		}
		private void UpdateList(TagList item)
		{
			ListedTags[ListedTags.IndexOf(item)] = item;
		}
		private void ReadPref()
		{
			int Iter = 0;
			if (UserActual.matematicas != "0")
			{
				Asign[Iter] = "matematicas";
				Iter += 1;
			}
			if (UserActual.espanol != "0")
			{
				Asign[Iter] = "espanol";
				Iter += 1;
			}
			if (UserActual.idiomas != "0")
			{
				Asign[Iter] = "idiomas";
				Iter += 1;
			}
			if (UserActual.historia != "0")
			{
				Asign[Iter] = "historia";
				Iter += 1;
			}
			if (UserActual.geografia != "0")
			{
				Asign[Iter] = "geografia";
				Iter += 1;
			}
			if (UserActual.quimica != "0")
			{
				Asign[Iter] = "quimica";
				Iter += 1;
			}
			if (UserActual.biologia != "0")
			{
				Asign[Iter] = "biologia";
				Iter += 1;
			}
			if (UserActual.fisica != "0")
			{
				Asign[Iter] = "fisica";
				Iter += 1;
			}
			if (UserActual.tecnologia != "0")
			{
				Asign[Iter] = "tecnologia";
				Iter += 1;
			}
			if (UserActual.arte != "0")
			{
				Asign[Iter] = "arte";
				Iter += 1;
			}
			if (UserActual.especializado != "0")
			{
				Asign[Iter] = "especializado";
				Iter += 1;
			}
			NextTagConfig();
		}
		public async void OnAppearing()
		{
			UserActual = await DataStore.GetUserAsync();
			SelectedListed = null;
			await DataStore.SetTagsAsync();
			ReadPref();
		}
	}
}
