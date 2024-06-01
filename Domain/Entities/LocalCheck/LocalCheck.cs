using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.LocalCheck
{
    public class LocalCheck
    {
        public static bool isLocal;
    }

    public class LocalCheckLocal : ILocalCheck
    {
        public bool isLocal = true;
        public bool IsLocal() { return isLocal; }
    }

    public class LocalCheckHost : ILocalCheck
    {
        public bool isLocal = false;
        public bool IsLocal() { return isLocal; }
    }

    public interface ILocalCheck
    {
        bool IsLocal();
    }
}
