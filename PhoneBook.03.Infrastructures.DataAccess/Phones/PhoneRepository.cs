using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Infrastructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructures.DataAccess.Phones
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(PhoneBookContext dbContext) : base(dbContext)
        {

        }
    }
}
