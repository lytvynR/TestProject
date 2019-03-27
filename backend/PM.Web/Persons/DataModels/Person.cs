using PM.Web.Data.Entities;
using PM.Web.Persons.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PM.Web.Persons.DataModels
{
    public class Person : IEntityWithId
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(11)]
        public string PersonalNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public decimal Salary { get; set; }
    }
}
