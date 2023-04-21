namespace M133BlazorServerApp.Pages.CookieLogin
{
    public class UserAccountService
    {
        private List<UserAccount> _users;

        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new() { Username = "joel", Password = "1234"}
            };
        }

        public UserAccount? GetUserByName(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
