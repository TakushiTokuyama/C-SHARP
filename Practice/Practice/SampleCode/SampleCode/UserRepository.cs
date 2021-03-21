namespace SampleCode
{
    class UserRepository : IUserRepository
    {
        public User FindUserByToken(string token)
        {
            var user = new Service().getUser(token);
            return user;
        }
    }
}
