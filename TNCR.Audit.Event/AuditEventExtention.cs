using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNCR.Audit.Event
{
    public static class AuditEventExtention
    {
        public static IProvider RegistrEventAudit(this IProvider provider)
        {
            return provider;
        }
    }
}
