using System.IdentityModel.Tokens.Jwt;

namespace frontend.Shared
{
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