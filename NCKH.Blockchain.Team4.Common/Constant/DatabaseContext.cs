using NCKH.Blockchain.Team4.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Constant
{
    public class DatabaseContext
    {
        public static string ConnectionString = "Server=mysql-124537-0.cloudclusters.net;Port=19880;Database=sql12613779;Uid=admin;Pwd=qaEXVdtb;";

        public static string DASHBOARD_INFOR = "proc_dashboard_GetInfor";

        public static string CONTACT_GETALL = "proc_contact_getAll";

        public static string CONTACT_ACCEPT = "Proc_contact_accept";

        public static string CONTACT_DELETE = "Proc_contact_delete";

        public static string CERTIFICATE_INSERT = "Proc_certificate_Insert";

        public static string CERTIFICATE_GETALL_ISSUED = "proc_certificate_getAllIssued";

        public static string CERTIFICATE_GETALL_RECEIVED = "proc_certificate_getAllReceived";

        public static string CERTIFICATE_SEND = "Proc_certificate_send";

        public static string CERTIFICATE_SIGN = "Proc_certificate_sign";

        public static string CERTIFICATE_BAN = "Proc_certificate_ban";

        public static string CERTIFICATE_DELETE = "Proc_certificate_delete";

        public static string CERTIFICATE_SIGN_MULTIPLE = "proc_certificate_SignMultiple";

        public static string CERTIFICATE_SEND_MULTIPLE = "proc_certificate_SendMultiple";

        public static string CERTIFICATE_BAN_MULTIPLE = "Proc_certificate_banMultiple";

        public static string CERTIFICATE_DELETE_MULTIPLE = "proc_certificate_DeleteMultiple";

        public static string CERTIFICATE_ADD_UPDATEAFTERSENT = "proc_Certificate_UpdateAfterSent";

        public static string USER_INSERT = "Proc_User_Insert";

        public static string USER_DELETE = "Proc_User_Delete";
    }
}
