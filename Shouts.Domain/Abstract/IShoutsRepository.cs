using System.Collections.Generic;

namespace Shouts.Domain.Abstract
{
    public interface IShoutsRepository
    {
        List<Shout> GetShoutsByUser(string id);
        void AddShout(Shout newShout);


    }
}
