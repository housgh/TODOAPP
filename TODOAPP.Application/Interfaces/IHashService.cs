namespace TODOAPP.Core.Interfaces
{
    public interface IHashService
    {
        string HashString(string text, string salt = "");
    }
}