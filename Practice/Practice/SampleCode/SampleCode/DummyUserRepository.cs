namespace SampleCode
{
    public class DummyUserRepository : IUserRepository
    {
        public User FindUserByToken(string token)
        {
            var user = new User();

            user.id = 4;
            user.Name = "D";
            user.Token = "999";

            return user;
        }
    }
}
