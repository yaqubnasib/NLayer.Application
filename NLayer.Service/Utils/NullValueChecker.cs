using NLayer.Core.Entites;
using NLayer.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Utils
{
    internal class NullValueChecker<T> where T : BaseEntity
    {
        public IEnumerable<T> Check(IEnumerable<T> data)
        {
            if (data != null)
                return data;
            throw new ClientSideException("");
        }

        public Task<T> Check(Task<T> data)
        {
            if (data != null)
                return data;
            throw new ClientSideException("");
        }
       
    }
}
