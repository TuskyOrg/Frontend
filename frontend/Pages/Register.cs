using System;
using System.IdentityModel.Tokens.Jwt;

namespace frontend.Pages
{
    [Serializable]
    public class UserRegistration
    {
        public string password {get; set; }

        public string username {get; set; }

    }

    [Serializable]
    public class LoginResponse{
       public string access_token {get;set;}
       public string token_type {get;set;}
    }

    public sealed class UserSingleton
    {
        private UserSingleton(){

        } 

        private static UserSingleton m_Instance = null;

        public static UserSingleton Instance()
        {
            if(m_Instance == null)
            {
                m_Instance = new UserSingleton();
            }

            return m_Instance;

        }

        public JwtSecurityToken jwt { get; set; }
    }
}
