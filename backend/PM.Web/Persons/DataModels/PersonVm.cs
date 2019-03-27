using PM.Web.Persons.Enums;
using System;

namespace PM.Web.Persons.DataModels
{
    public class PersonVm
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public decimal Salary { get; set; }
    }
}
