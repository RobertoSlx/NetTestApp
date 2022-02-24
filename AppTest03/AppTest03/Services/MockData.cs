using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AppTest03.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using MsgPack.Serialization;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using System.Reflection;

namespace AppTest03.Services // Clase de escritura asincrona 
{
    class MockData : IDataStore<t_usuarios_reg>
    {
        public readonly List<t_usuarios_reg> PersonalUserData;
        public readonly List<t_usuarios_pub> PersonalUserPost;
        public readonly List<t_usuarios_tags> PersonalTagList;
        //private Uri WebResource = new Uri(string.Format("https://mainappreg.azurewebsites.net"));
        private string BaseWebResource = "https://mainappreg.azurewebsites.net/api";
        private string BlobImaResource = "https://cuentaimperfil.blob.core.windows.net/cont1/";
        //private string DefaultUserImage = "https://cuentaimperfil.blob.core.windows.net/cont1/noprofile.png";
        private string DefaultUserImage = "noprofile.png";
        private string UserResource = "/t_usuarios_reg/";
        private string PostResource = "/t_usuarios_pub/";
        private string RespResource = "/t_usuarios_resp/";

        public MockData()
        {
            PersonalUserData = new List<t_usuarios_reg>()
            {
                /*
                new t_usuarios_reg {Id=0,
                                    id_usuario="user",
                                    nombre="Nuevo usuario",
                                    email="",
                                    contrasena="",
                                    fecha_nacimiento=DateTime.Now,
                                    fecha_registro=DateTime.Now,
                                    ocupacion="",
                                    presentacion="",
                                    habilidades="",
                                    matematicas="0",
                                    espanol="0",
                                    idiomas="0",
                                    historia="0",
                                    geografia="0",
                                    quimica="0",
                                    biologia="0",
                                    fisica="0",
                                    tecnologia="0",
                                    arte="0",
                                    especializado="0",
                                    tacticas_aprendizaje_graficas="0",
                                    tacticas_aprendizaje_escuchar="0",
                                    tacticas_aprendizaje_leeryescribir="0",
                                    tacticas_aprendizaje_debatir="0",
                                    tacticas_aprendizaje_practicar="0",
                                    tacticas_aprendizaje_ejemplificar="0",
                                    tacticas_aprendizaje_videos="0",
                                    tacticas_aprendizaje_analizar="0",
                                    metodos_ensenanza_documental="0",
                                    metodos_ensenanza_videoconferencias="0",
                                    metodos_ensenanza_videos="0",
                                    metodos_ensenanza_audios="0",
                                    metodos_ensenanza_debates="0",
                                    metodos_ensenanza_graficos="0",
                                    url_im_perfil="noprofile.png"}
                */
                             
                new t_usuarios_reg{ Id= 51,
                                    id_usuario= "97b43424-99bb-4e8d-82d1-e981207782e0",
                                    nombre= "cosa@cosas.com",
                                    contrasena= "pass",
                                    fecha_nacimiento= Convert.ToDateTime("1989-05-21T00:00:00"),
                                    fecha_registro= Convert.ToDateTime("2021-11-05T01:10:50.59"),
                                    ocupacion= "Cosas",
                                    presentacion= "muchas cosas",
                                    habilidades= "01001100",
                                    matematicas= "1",
                                    espanol= "0",
                                    idiomas= "0",
                                    historia= "0",
                                    geografia= "0",
                                    quimica= "0",
                                    biologia= "0",
                                    fisica= "1",
                                    tecnologia= "1",
                                    arte= "0",
                                    especializado= "0",
                                    tacticas_aprendizaje_graficas= "1",
                                    tacticas_aprendizaje_escuchar= "0",
                                    tacticas_aprendizaje_leeryescribir= "0",
                                    tacticas_aprendizaje_debatir= "1",
                                    tacticas_aprendizaje_practicar= "1",
                                    tacticas_aprendizaje_ejemplificar= "0",
                                    tacticas_aprendizaje_videos= "0",
                                    tacticas_aprendizaje_analizar= "0",
                                    metodos_ensenanza_documental= "0",
                                    metodos_ensenanza_videoconferencias= "0",
                                    metodos_ensenanza_videos= "0",
                                    metodos_ensenanza_audios= "0",
                                    metodos_ensenanza_debates= "0",
                                    metodos_ensenanza_graficos= "0",
                                    url_im_perfil= "https://cuentaimperfil.blob.core.windows.net/cont1/97b43424-99bb-4e8d-82d1-e981207782e0.png",
                                    user_tags="1-dnir,8-dnir,1-gnir,1-pnir,9-gnir,1-bnir,9-dnir,"
                }
            };

            PersonalUserPost = new List<t_usuarios_pub>()
            {
                new t_usuarios_pub{Id=0,id_publicacion="",id_usuario="",fecha_publicacion=DateTime.Now, titulo="Por que esta app mola !",cuerpo="La verdad no... no esta chida", relacion="",tag="",estatus=0 },
            };

            PersonalTagList = new List<t_usuarios_tags>();

         }
        public async Task<List<t_usuarios_tags>> readJson()
        {
            string jsonFileName = "AppTag.json";
            List<t_usuarios_tags> TagList;
            var assembly = typeof(MockData).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Converting JSON Array Objects into generic list    
                TagList = JsonConvert.DeserializeObject<List<t_usuarios_tags>>(jsonString);
            }
            //Binding listview with json string     
            return await Task.FromResult(TagList);
        }

        // Add
        public async Task<bool> AddUserAsync(t_usuarios_reg item)
        {
            PersonalUserData.Add(item);
            return await Task.FromResult(true);
        }
        public async Task<bool> AddPostAsync(t_usuarios_pub post)
        {
            PersonalUserPost.Add(post);
            return await Task.FromResult(true);
        }

        // Delete Item
        public async Task<bool> DeleteUserAsync(string id)
        {
            var oldItem = PersonalUserData.Where((t_usuarios_reg arg) => arg.id_usuario == id).FirstOrDefault();
            PersonalUserData.Remove(oldItem);

            return await Task.FromResult(true);
        }
        public async Task<bool> DeletePostAsync(int id)
        {
            var oldItem = PersonalUserPost.Where((t_usuarios_pub arg) => arg.Id == id).FirstOrDefault();
            PersonalUserPost.Remove(oldItem);

            return await Task.FromResult(true);
        }

        // Get item
        public async Task<t_usuarios_reg> GetUserAsync(t_usuarios_reg User)
        {
            PersonalUserData[0].Id = User.Id;
            return await Task.FromResult(PersonalUserData.FirstOrDefault(s => s.Id == User.Id));
        }
        public async Task<t_usuarios_reg> GetUserAsync()
        {
            int id = PersonalUserData[0].Id;
            return await Task.FromResult(PersonalUserData.FirstOrDefault(s => s.Id == id));
        }
        public async Task<t_usuarios_pub> GetPostAsync(string id)
        {
            return await Task.FromResult(PersonalUserPost.FirstOrDefault(s => s.id_publicacion == id));
        }

        // Get Items
        public async Task<IEnumerable<t_usuarios_reg>> GetUsersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(PersonalUserData);
        }
        public async Task<IEnumerable<t_usuarios_pub>> GetPostAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(PersonalUserPost);
        }

        // Update Items
        public async Task<bool> UpdateUserAsync(t_usuarios_reg item)
        {
            PersonalUserData[0].Id = item.Id;
            var oldItem = PersonalUserData.Where((t_usuarios_reg arg) => arg.Id == item.Id).FirstOrDefault();
            PersonalUserData.Remove(oldItem);
            PersonalUserData.Add(item);

            return await Task.FromResult(true);
        }
        public async Task<bool> UpdatePostAsync(t_usuarios_pub post)
        {
            var oldItem = PersonalUserPost.Where((t_usuarios_pub arg) => arg.Id == post.Id).FirstOrDefault();
            PersonalUserPost.Remove(oldItem);
            PersonalUserPost.Add(post);

            return await Task.FromResult(true);
        }

        public async Task<bool> SetTagsAsync()
        {
            PersonalTagList.Clear();
            List<t_usuarios_tags> TagList = await readJson();
            foreach (t_usuarios_tags tag in TagList)
            {
                PersonalTagList.Add(tag);
            }
            return await Task.FromResult(true);
        }

        public async Task<List<t_usuarios_tags>> GetAsignmentTags(string asignment)
		{
            if (PersonalTagList.Count < 2)
			{
                await SetTagsAsync();
			}

            List<t_usuarios_tags> result = new List<t_usuarios_tags>();

            var pubs = from m in PersonalTagList select m;

            pubs = pubs.Where(s => s.relacion == asignment);

            result = pubs.ToList();

            return  result;
		}

        public async Task<List<t_usuarios_pub>> GetRelevantPost(t_usuarios_reg user)
		{
            List<t_usuarios_pub> Rpost = await GetSearchPosts(user.user_tags);

            if(Rpost != null)
			{
                Rpost.OrderBy(x => x.fecha_publicacion);
                PersonalUserPost.Clear();
                foreach (t_usuarios_pub pub in Rpost)
                {
                    PersonalUserPost.Add(pub);
                }
                return PersonalUserPost;
            }
			else
			{
                PersonalUserPost.Clear();
                return null;
			}
        }

        // Post
        public async Task<t_usuarios_reg> PostUserRegisterDB(t_usuarios_reg Data)
        {
            t_usuarios_reg ObjContactList = new t_usuarios_reg();
            var json = JsonConvert.SerializeObject(Data);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var httpClient = new HttpClient();
            Uri url = new Uri(string.Format(BaseWebResource + "/t_usuarios_reg"));
            var response = await httpClient.PostAsync(url, httpContent);

            var contactsJson = await response.Content.ReadAsStringAsync();

            if (contactsJson != "")
            {
                ObjContactList = JsonConvert.DeserializeObject<t_usuarios_reg>(contactsJson);
            }

            return ObjContactList;
        }

        public async Task<bool> PostResponseDB(t_usuarios_resp Data)
        {
            var json = JsonConvert.SerializeObject(Data);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClient = new HttpClient();
            Uri url = new Uri(string.Format(BaseWebResource + "/t_usuarios_resp"));
            var response = await httpClient.PostAsync(url, httpContent);

            return await Task.FromResult(true);
        }
        public async Task<bool> PostPublicationDB(t_usuarios_pub Data)
        {
            var json = JsonConvert.SerializeObject(Data);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClient = new HttpClient();
            Uri url = new Uri(string.Format(BaseWebResource + "/t_usuarios_pub"));
            var response = await httpClient.PostAsync(url, httpContent);

            return await Task.FromResult(true);
        }

        // Get 

        public async Task<t_usuarios_reg> GetUserRegisterDB(int DbId)
        {
            var httpClient = new HttpClient();
            t_usuarios_reg udata = null;
            string regUrl = BaseWebResource + UserResource + DbId;
            Uri url = new Uri(string.Format(regUrl));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            var DbResponse = await response.Content.ReadAsStringAsync();
            udata = JsonConvert.DeserializeObject<t_usuarios_reg>(DbResponse);

            return udata;
        }

        public async Task<t_usuarios_reg> GetUserInfoDB(string uID)
        {
            var httpClient = new HttpClient();
            t_usuarios_reg udata = null;
            string regUrl = BaseWebResource + UserResource + "inf/" + uID;
            Uri url = new Uri(string.Format(regUrl));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            var DbResponse = await response.Content.ReadAsStringAsync();
            udata = JsonConvert.DeserializeObject<t_usuarios_reg>(DbResponse);

            return udata;
        }

        public async Task<bool> UpdateUserRegisterDB(t_usuarios_reg UserData)
        {
            await UpdateUserAsync(UserData);
            int DbId = UserData.Id;
            var json = JsonConvert.SerializeObject(UserData);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var httpClient = new HttpClient();
            Uri url = new Uri(string.Format(BaseWebResource + UserResource + DbId));
            var response = await httpClient.PutAsync(url, httpContent);
            if (response.StatusCode != HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public async Task<List<t_usuarios_pub>> GetSearchPosts( string Tags)
        {
            var httpClient = new HttpClient();
            List<t_usuarios_pub> udata = new List<t_usuarios_pub>();
            Uri url = new Uri(string.Format(BaseWebResource + PostResource + "tag/" + Tags));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            var DbResponse = await response.Content.ReadAsStringAsync();

            if(DbResponse != null)
			{
                udata = JsonConvert.DeserializeObject<List<t_usuarios_pub>>(DbResponse);
            }
			else
			{
                udata = null;
			}
            
            return udata;
        }

        public async Task<List<t_usuarios_resp>> GetPostResponses(string postID)
        {
            var httpClient = new HttpClient();
            List<t_usuarios_resp> udata = new List<t_usuarios_resp>();
            Uri url = new Uri(string.Format(BaseWebResource + RespResource + "post/" + postID));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            var DbResponse = await response.Content.ReadAsStringAsync();

            if (DbResponse != null)
            {
                udata = JsonConvert.DeserializeObject<List<t_usuarios_resp>>(DbResponse);
            }
            else
            {
                udata = null;
            }

            return udata;
        }

        // Verify

        public async Task<t_usuarios_reg> VerificarReg(t_usuarios_reg User)
        {
            var httpClient = new HttpClient();
            Uri url = new Uri(string.Format(BaseWebResource + UserResource + User.email + "/" + User.contrasena));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            var DbResponse = await response.Content.ReadAsStringAsync();
            var udata = JsonConvert.DeserializeObject<t_usuarios_reg>(DbResponse);

            return udata;
        }

        // Image
        public async Task<string> UploadImage(Stream stream, string name, string ImExt)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cuentaimperfil;AccountKey=uKi2wcIovYVuxVGXOjWDaUA7pyo8c5Tqghfu9vcWGaeknHxYM1iMYfQOfH6zospdi1mRZWNsnACajEAU3zI6dw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("cont1");
            await container.CreateIfNotExistsAsync();
            var blockBlob = container.GetBlockBlobReference($"{name}{ImExt}");
            await blockBlob.UploadFromStreamAsync(stream);
            //string URL = blockBlob.Uri.OriginalString;
            //UploadedUrl.Text = URL;
            return (BlobImaResource + name + ImExt);
        } 

        public async Task<string> GetImageUrl(t_usuarios_reg user)
		{
            if(PersonalUserData[0].url_im_perfil.Length < 20)
			{
                PersonalUserData[0].url_im_perfil = DefaultUserImage;
			}

            return await Task.FromResult(PersonalUserData[0].url_im_perfil);
		} 
    }
}
