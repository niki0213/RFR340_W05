using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MessageLogic : IMessageLogic
    {

        IRepository<Message> repo;
        public MessageLogic(IRepository<Message> repo)
        {
            this.repo = repo;
        }

        public void Add(Message item)
        {
            this.repo.Add(item);
        }

        public IEnumerable<Message> ReadAll()
        {
            return repo.ReadAll();
        }
    }
}
