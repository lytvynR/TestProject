using PM.Web.Persons.DataModels;
using System.Threading.Tasks;

namespace PM.Web.Persons
{
    public class EditPersonService
    {
        private readonly PersonsRepository _personsRepository;

        public EditPersonService(PersonsRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        public async Task<Person> Create(PersonVm personVm)
        {
            Person person = EditCommonPersonProperties(new Person(), personVm);

            await _personsRepository.Create(person);

            return person;
        }

        public async Task<Person> Edit(PersonVm personVm)
        {
            Person personFromDb = await _personsRepository.GetOne(personVm.Id.Value);

            personFromDb = EditCommonPersonProperties(personFromDb, personVm);

            await _personsRepository.Update(personFromDb);

            return personFromDb;
        }

        public async Task Delete(int personId)
        {
            Person personFromDb = await _personsRepository.GetOne(personId);

            await _personsRepository.Delete(personId);
        }

        private Person EditCommonPersonProperties(Person person, PersonVm personVm)
        {
            person.FirstName = personVm.FirstName;
            person.LastName = personVm.LastName;
            person.PersonalNumber = personVm.PersonalNumber;
            person.BirthDate = personVm.BirthDate;
            person.Gender = personVm.Gender;
            person.Salary = personVm.Salary;

            return person;
        }

    }
}
