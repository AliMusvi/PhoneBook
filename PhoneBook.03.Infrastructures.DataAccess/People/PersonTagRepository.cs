using PhoneBook.Core.Contracts.Common;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Domain.Core;
using PhoneBook.Domain.Core.People;
using PhoneBook.Infrastructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Infrastructures.DataAccess.People
{
    public class PersonTagRepository : BaseRepository<PersonTag>, IPersonTagRepository
    {
        public PersonTagRepository(PhoneBookContext dbContext) : base(dbContext)
        {

        }
    }
}
