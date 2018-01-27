using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudmersiveClient.Audit
{
    public class AuditLogWriteRequest
    {
        public string AuditLogMessage;
        public string AuditLogMeta;
        public string AuditLogUserIdentifier;
        public string AuditLogReferenceID;
        public string AuditLogReferenceIP;
        public string AuditLogReferenceLocation;
        public string AuditLogAction;
    }

    public class AuditLogResponse
    {
        public bool Successful;
    }
}
