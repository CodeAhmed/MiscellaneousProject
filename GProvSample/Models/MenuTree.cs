using GProvSample.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GProvSample.Models
{
    public class MenuTree
    {
        public string ObjType { get; set; }
        public string ObjSubType { get; set; }
        public string ObjName { get; set; }
        public List<MenuTree> children { get; set; }
        

        public List<MenuTree> GetTreeData()
        {
            List<MenuTree> objects = new List<MenuTree>();

            DALProperty property = new DALProperty();
            DataSet ds = property.getObjects();
            objects = (from tmp in ds.Tables[0].AsEnumerable()
                       select new MenuTree
                       {
                           ObjType = tmp.Field<string>("ObjType"),
                           ObjSubType = tmp.Field<string>("ObjSubType"),
                           ObjName = tmp.Field<string>("ObjName"),
                       }).ToList();

            return objects;
        }

        

        public List<MenuTree> GetMenuTree(List<MenuTree> list)
        {

            var newList = list.GroupBy(x => new { x.ObjType, x.ObjSubType, x.ObjName }).Select(y => new MenuTree()
                {
                    ObjType = y.Key.ObjType,
                    ObjSubType = y.Key.ObjSubType,
                    ObjName = y.Key.ObjName,
                }
                );
            return newList.ToList();

        }

    }
}