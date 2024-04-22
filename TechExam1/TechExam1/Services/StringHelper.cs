namespace TechExam1.Services
{
    public class StringHelper
    {
        public List<string> ConvertToListString(string input)
        {
            return input.ToLower().Select(x => x.ToString()).ToList();
        }
    }
}
