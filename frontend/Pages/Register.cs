using System;

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
}
