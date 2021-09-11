using PhoneBook.Core.Contracts.Tags;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infrastructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructures.DataAccess.Tags
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(PhoneBookContext dbContext) : base(dbContext)
        {

        }
    }
}
