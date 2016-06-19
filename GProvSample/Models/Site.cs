using GProvSample.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GProvSample.Models
{
    public class Site
    {
        public int SiteID { get; set; }
        public int SiteCode { get; set; }
        public string SiteName { get; set; }


        public List<Site> GetSite()
        {
            List<Site> sites = new List<Site>();

            DALProperty property = new DALProperty();
            DataSet ds = property.getSite();
            sites = (from tmp in ds.Tables[0].AsEnumerable()
                     select new Site
                     {
                         SiteID = tmp.Field<int>("SiteID"),
                         SiteCode = tmp.Field<int>("SiteCode"),
                         SiteName = tmp.Field<string>("SiteName")
                     }).ToList();

            return sites;
        }
    }
}