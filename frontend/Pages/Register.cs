using System;

namespace frontend.Pages
{
    [Serializable]
    public class UserRegistration
    {
        public string password {get; set; }

        public string username {get; set; }

    }

    public class RegistrationReponse : UserModel{
        public bool SuccessfulReponse { get; set; }
    }

    [Serializable]
    public class UserModel{
        public Int64 id { get; set; }

        public string email { get; set; }

        public bool is_active { get; set; }

        public bool is_superuser { get; set; }

        public string username { get; set; }

    }

    [Serializable]
    public class LoginResponse{
       public string access_token { get; set; }

       public string refresh_token { get; set; }
       public string token_type { get; set; }

       public bool IsSuccessful { get; set; }
    }
}
