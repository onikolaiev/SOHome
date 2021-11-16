using SOHome.Common.Models;

namespace SOHome.Common.DataModels
{
    public class UserDto : ObservableObject
    {
        #region Váriaveis privadas
        private int code;
        private string name;
        private string email;
        private string username;
        private string token;
        #endregion
        #region Propriedades
        public int Code { get => code; set => SetProperty(ref code, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Token { get => token; set => SetProperty(ref token, value); }
        #endregion
    }
}
