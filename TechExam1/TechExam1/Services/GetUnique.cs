namespace TechExam1.Services
{
    public class GetUnique
    {
        public List<string> characters { get; set; } = new List<string>();
        public List<string> GetNumberOfUniqueCharacter()
        {
            List<string> unique = new List<string>();
            foreach (string character in characters)
            {
                if (CheckIfUnique(character))
                {
                    unique.Add(character);
                }
            }
            return unique;
            
        }
        public bool CheckIfUnique(string character)
        {
            if(characters.Where(y => y == character).Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
