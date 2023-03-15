using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKH.Blockchain.Team4.Common.Constant
{
    public class DatabaseContext
    {
        public static string ConnectionString = "Server=sql12.freesqldatabase.com;Port=3306;Database=sql12604943;Uid=sql12604943;Pwd=3MwLRCfhE9;";

        public static string DASHBROAD_INFOR = "proc_dashbroad_GetInfor";

        public static string CONTACT_GET_PAGING_AND_FILLTER = "proc_contact_GetPaging";

        public static string CONTACT_DELETE = "Proc_contact_Delete";

        public static string CONTACT_ACCEPT = "Proc_contact_accept";

        public static string CERTIFICATE_ISSUED_GET_PAGING_AND_FILLTER = "proc_certificate_GetPagingIssued";

        public static string CERTIFICATE_RECEIVED_GET_PAGING_AND_FILLTER = "proc_certificate_GetPagingReceived";

        public static string CERTIFICATE_INSERT = "Proc_certificate_Insert";

        public static string CERTIFICATE_DELETE = "Proc_certificate_delete";

        public static string CERTIFICATE_DELETE_MULTIPLE = "proc_certificate_DeleteMultiple";

        public static string CERTIFICATE_SEND = "Proc_certificate_send";

        public static string CERTIFICATE_SIGN = "Proc_certificate_sign";

        public static string USER_INSERT = "Proc_User_Insert";

    }
}
