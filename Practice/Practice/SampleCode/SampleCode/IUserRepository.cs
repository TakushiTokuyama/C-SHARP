namespace SampleCode
{
    public interface IUserRepository
    {
        User FindUserByToken(string token);
    }
}
