using PM.Web.Persons.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Web.Persons
{
    public class PersonsPriovider
    {
        private readonly PersonsRepository _personRepository;

        public PersonsPriovider(PersonsRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetOne(int personId)
        {
            return await _personRepository.GetOne(personId);
        }

        public PersonWithPaging GetWithPage(int pageNumber)
        {
            return _personRepository.GetWithPage(pageNumber);
        }

        public List<string> GetPersonNumbers()
        {
            return _personRepository.GetPersonNumbers();
        }


    }
}
