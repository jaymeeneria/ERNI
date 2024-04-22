using System;
using TechExam1.Interface;

namespace TechExam1.Services
{
    public class StringOrganizerService : IStringOrganizerService
    {
        private readonly GetUnique _getUnique;
        private readonly StringHelper _stringHelper;
        public StringOrganizerService(GetUnique getUnique, StringHelper stringHelper)
        {
            _getUnique = getUnique;
            _stringHelper = stringHelper;
        }
        public async Task<int> GetNumberOfUniqueCharacterFromString(string input)
        {
            _getUnique.characters = _stringHelper.ConvertToListString(input);

            return _getUnique.GetNumberOfUniqueCharacter();
        }

       
    }
}
