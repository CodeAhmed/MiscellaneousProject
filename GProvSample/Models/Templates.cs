using GProvSample.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GProvSample.Models
{
    public class Templates
    {
        public TemplateTypes Type { get; set; }
    }

    public enum TemplateTypes
    {
        Object,
        ObjectProperties
    };

    public class ObjectData
    {
        public int SiteID { get; set; }
        public int ObjectID { get; set; }
        public string ObjName { get; set; }
        public string ObjType { get; set; }
        public string ObjSubType { get; set; }
        public string Obj_Ref_1 { get; set; }
        public string Obj_Ref_2 { get; set; }
        public string Obj_Ref_3 { get; set; }
        public string Obj_Ref_4 { get; set; }
        public string Obj_Ref_5 { get; set; }
        public string Obj_Ref_6 { get; set; }
        public string Obj_Ref_7 { get; set; }
        public string Obj_Ref_8 { get; set; }
        public string Obj_Ref_9 { get; set; }
        public string Obj_Ref_10 { get; set; }
        public string SiteName { get; set; }
        public List<ObjectData> ObjTmpList { get; set; }

        // Load All Objects from Database 
        public List<ObjectData> GetObjects()
        {
            List<ObjectData> objects = new List<ObjectData>();

            DALProperty property = new DALProperty();
            DataSet ds = property.getObjects();
            objects = (from tmp in ds.Tables[0].AsEnumerable()
                       select new ObjectData
                     {
                         SiteID = tmp.Field<int?>("SiteID") == null ? 0 : tmp.Field<int>("SiteID"),
                         ObjectID = tmp.Field<int>("ObjectID"),
                         ObjName = tmp.Field<string>("ObjName"),
                         ObjType = tmp.Field<string>("ObjType"),
                         ObjSubType = tmp.Field<string>("ObjSubType"),
                         Obj_Ref_1 = tmp.Field<string>("Obj_Ref_1"),
                         Obj_Ref_2 = tmp.Field<string>("Obj_Ref_2"),
                         Obj_Ref_3 = tmp.Field<string>("Obj_Ref_3"),
                         Obj_Ref_4 = tmp.Field<string>("Obj_Ref_4"),
                         Obj_Ref_5 = tmp.Field<string>("Obj_Ref_5"),
                         Obj_Ref_6 = tmp.Field<string>("Obj_Ref_6"),
                         Obj_Ref_7 = tmp.Field<string>("Obj_Ref_7"),
                         Obj_Ref_8 = tmp.Field<string>("Obj_Ref_8"),
                         Obj_Ref_9 = tmp.Field<string>("Obj_Ref_9"),
                         Obj_Ref_10 = tmp.Field<string>("Obj_Ref_10"),
                     }).ToList();

            return objects;
        }

        public List<ObjectData> GetMenuTree(List<ObjectData> list, string parent)
        {
            return list.Where(x => x.ObjType == parent).Select(x => new ObjectData()
            {
                ObjType = x.ObjType,
                ObjSubType = x.ObjSubType,
                ObjName = x.ObjName,
                ObjTmpList = GetMenuTree(list, x.ObjSubType)
            }).ToList();
        }
    }
}