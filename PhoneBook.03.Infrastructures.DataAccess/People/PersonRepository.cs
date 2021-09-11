using PhoneBook.Core.Contracts.People;
using PhoneBook.Domain.Core;
using PhoneBook.Infrastructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructures.DataAccess.People
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
