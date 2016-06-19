using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GProvSample.DAL
{
    public class DataAccess
    {
        protected Database DBDAL = new SqlDatabase(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        protected string ExcelDAL = ConfigurationManager.ConnectionStrings["Excel07"].ConnectionString;
    }
}