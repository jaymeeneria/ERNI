namespace TechExam1.Services
{
    public class GetUnique
    {
        public List<string> characters { get; set; } = new List<string>();
        public HashSet<string> set = new HashSet<string>();

        public int GetNumberOfUniqueCharacter()
        {
            List<string> unique = new List<string>();

            foreach (string character in characters)
            {
                if (set.Add(character))
                {
                    unique.Add(character);
                }
                else {
                    unique.RemoveAll(x => x == character);
                }
            }

            return unique.Count;
            
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
