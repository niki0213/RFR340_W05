using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MessageRepository : Repository<Message>, IRepository<Message>
    {
        public MessageRepository(IEnumerable<Message> items) : base(items) { }


    }

}