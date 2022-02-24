using AppTest03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppTest03.Services
{
	public interface IDataStore<T> // Interfaz con el Modelo
	{
		Task<bool> AddUserAsync(T item);
		Task<bool> UpdateUserAsync(T item);
		Task<bool> DeleteUserAsync(string id);
		Task<T> GetUserAsync(t_usuarios_reg User);
		Task<t_usuarios_pub> GetPostAsync(string id);
		Task<T> GetUserAsync();
		Task<IEnumerable<T>> GetUsersAsync(bool forceRefresh = false);
		Task<IEnumerable<t_usuarios_pub>> GetPostAsync(bool forceRefresh = false);
		Task<t_usuarios_reg> PostUserRegisterDB(t_usuarios_reg Data);
		Task<t_usuarios_reg> GetUserRegisterDB(int DbId);
		Task<bool> UpdateUserRegisterDB(t_usuarios_reg UserData);
		Task<t_usuarios_reg> VerificarReg(t_usuarios_reg User);
		Task<string> UploadImage(Stream stream, string name, string ImExt);
		Task<bool> SetTagsAsync();
		Task<string> GetImageUrl(t_usuarios_reg user);
		Task<List<t_usuarios_pub>> GetRelevantPost(t_usuarios_reg user);
		Task<List<t_usuarios_tags>> GetAsignmentTags(string asignment);
		Task<bool> PostResponseDB(t_usuarios_resp Data);
		Task<bool> PostPublicationDB(t_usuarios_pub Data);
		Task<t_usuarios_reg> GetUserInfoDB(string uID);
		Task<List<t_usuarios_resp>> GetPostResponses(string postID);
	}
}
