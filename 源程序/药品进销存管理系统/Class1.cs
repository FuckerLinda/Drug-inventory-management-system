using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 药品进销存管理系统
{
    class DBConnect
    {
        public static SqlConnection con()
        {
            string ConStr= "server=03BA;uid=sa;pwd=root;database=drug;";
            return new SqlConnection(ConStr);
        }
    }
}
