namespace TechExam1.Services
{
    public class StringHelper
    {
        public List<string> ConvertToListString(string input)
        {
            return input.Select(x => x.ToString().ToLower()).ToList();
        }
    }
}
