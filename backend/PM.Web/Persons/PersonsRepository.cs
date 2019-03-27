using PM.Web.Constants;
using PM.Web.Data;
using PM.Web.Data.Repository;
using PM.Web.Persons.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace PM.Web.Persons
{
    public class PersonsRepository : BaseRepository<Person>
    {
        public PersonsRepository(PMContext context) : base(context)
        {
        }

        public PersonWithPaging GetWithPage(int pageNumber)
        {

            PersonWithPaging personWithPaging = new PersonWithPaging();
            personWithPaging.EntitiesCount = Query().Count();
            personWithPaging.Entity = Query().Skip(pageNumber * PagingConstants.DefaultPageSize).ToList();
            personWithPaging.PageNumber = pageNumber;

            return personWithPaging;
        }

        public List<string> GetPersonNumbers()
        {
            return Query().Select(p => p.PersonalNumber).Distinct().ToList();
        }
    }
}
