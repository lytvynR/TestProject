using System.Collections.Generic;

namespace PM.Web.Persons.DataModels
{
    public class EntityWithPagingResponse<T>
    {
        public List<T> Entity { get; set; }

        public int PageNumber { get; set; }

        public int EntitiesCount { get; set; }
    }
}
