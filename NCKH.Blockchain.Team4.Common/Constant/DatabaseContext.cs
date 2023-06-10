using NCKH.Blockchain.Team4.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Constant
{
    public static class DatabaseContext
    {
        public const string ConnectionString = "Server=mysql-131055-0.cloudclusters.net;Port=10218;Database=sql12613779;Uid=admin;Pwd=mKy96Elo;";

        public const string DASHBOARD_INFOR = "proc_dashboard_GetInfor";

        public const string CONTACT_GETALL = "proc_contact_getAll";

        public const string CONTACT_ACCEPT = "Proc_contact_accept";

        public const string CONTACT_DELETE = "Proc_contact_delete";

        public const string CERTIFICATE_INSERT = "Proc_certificate_Insert";

        public const string CERTIFICATE_GETALL_ISSUED = "proc_certificate_getAllIssued";

        public const string CERTIFICATE_GETALL_RECEIVED = "proc_certificate_getAllReceived";

        public const string CERTIFICATE_SEND = "Proc_certificate_send";

        public const string CERTIFICATE_SIGN = "Proc_certificate_sign";

        public const string CERTIFICATE_BAN = "Proc_certificate_ban";

        public const string CERTIFICATE_DELETE = "Proc_certificate_delete";

        public const string CERTIFICATE_SIGN_MULTIPLE = "proc_certificate_SignMultiple";

        public const string CERTIFICATE_SEND_MULTIPLE = "proc_certificate_SendMultiple";

        public const string CERTIFICATE_BAN_MULTIPLE = "Proc_certificate_banMultiple";

        public const string CERTIFICATE_DELETE_MULTIPLE = "proc_certificate_DeleteMultiple";

        public const string CERTIFICATE_ADD_UPDATEAFTERSENT = "proc_Certificate_UpdateAfterSent";

        public const string USER_INSERT = "Proc_User_Insert";

        public const string USER_DELETE = "Proc_User_Delete";

        public const string USER_UPDATE = "proc_user_update";
    }
}
