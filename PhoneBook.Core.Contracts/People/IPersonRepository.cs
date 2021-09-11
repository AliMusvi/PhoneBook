using PhoneBook.Core.Contracts.Common;
using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Contracts.People
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
    }
}
