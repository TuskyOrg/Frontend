namespace frontend.Networking{
    using frontend.Pages;
    using System.Threading.Tasks;
    public interface IAuthenticationService{
        public Task<RegistrationReponse> Register(UserRegistration userRegistration);
         public  Task<LoginResponse> Login(string data);
    }
}