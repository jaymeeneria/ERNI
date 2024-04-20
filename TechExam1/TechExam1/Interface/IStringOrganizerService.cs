namespace TechExam1.Interface
{
    public interface IStringOrganizerService
    {
        Task<int> GetNumberOfUniqueCharacterFromString(string input);
    }
}
