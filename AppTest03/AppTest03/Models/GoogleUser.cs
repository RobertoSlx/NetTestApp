using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest03.Models
{
	public class GoogleUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }
    }
    public interface IGoogleManager
    {
        void Login(Action<GoogleUser, string> onLoginComplete);
        void Logout();
    }
}
