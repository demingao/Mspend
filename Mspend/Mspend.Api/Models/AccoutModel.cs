namespace Mspend.Api.Models
{
    public class AccoutLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AccoutRegister : AccoutLogin
    {
        public string NickName { get; set; }
    }
    public class AccoutModel
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string ProfilePicture { get; set; }
    }
}