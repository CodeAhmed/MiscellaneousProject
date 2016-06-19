using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GProvSample.DAL
{
    public class DALProperty : DataAccess
    {
        public DataSet getObjects()
        {
            using (DbCommand objCmd = DBDAL.GetStoredProcCommand("spListAllObjects"))
            {
                return DBDAL.ExecuteDataSet(objCmd);
            }
        }

        public void ParseExcel(string FilePath, string FileType)
        {
            ExcelDAL = String.Format(ExcelDAL, FilePath);
            OleDbConnection objOlecon = new OleDbConnection();
            objOlecon.ConnectionString = ExcelDAL;
            objOlecon.Open();
            OleDbDataAdapter objOleDa = new OleDbDataAdapter("Select * from [Sheet1$]", objOlecon);
            DataTable objdt = new DataTable();
            objOleDa.Fill(objdt);
            string storedProcName = FileType == "ObjectTemplate" ? "spUploadObjects" : "spUploadObjProperty";
            SqlConnection objsqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            objsqlCon.Open();
            SqlCommand cmd = new SqlCommand(storedProcName);//Here provide your stored procedure name
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = objsqlCon;
            cmd.Parameters.AddWithValue("@datatable", objdt);
            cmd.ExecuteNonQuery();
            objsqlCon.Close();
            objOlecon.Close();
        }

        public DataSet getSite()
        {
            using (DbCommand objCmd = DBDAL.GetStoredProcCommand("spListAllSite"))
            {
                return DBDAL.ExecuteDataSet(objCmd);
            }
        }
    }
}