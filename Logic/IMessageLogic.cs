using Model;
using System.Collections.Generic;

namespace Logic
{
    public interface IMessageLogic
    {
        void Add(Message item);
        IEnumerable<Message> ReadAll();
    }
}