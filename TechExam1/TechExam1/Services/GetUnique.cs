using System.Collections.Generic;
using System.Xml.Linq;

namespace TechExam1.Services
{
    public class GetUnique
    {
        public List<string> characters { get; set; } = new List<string>();
        HashSet<string> set = new HashSet<string>();

        public List<string> RemoveDuplicateCharacters()
        {
            List<string> unique = new List<string>();

            var result = characters.GroupBy(x => x)
            .Where(x => x.Count() == 1)
            .Select(g => g.Key);

            return unique;
        }

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
            if (set.Add(character))
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
