using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SoftiDoc.Web.Api.Dto;

namespace SoftiDoc.Web.Api.Controllers
{
    [RoutePrefix("api/softidoc")]
    public class SoftiDocController : ApiController
    {
        private readonly string _connStr;
        private readonly SqlConnection conn;

        public SoftiDocController()
        {
            this._connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            conn = new SqlConnection(_connStr);
        }

        [HttpGet]
        [Route("getDatabases")]
        public HttpResponseMessage GetDatabases()
        {
            var command = new SqlCommand("select * from Databases", conn);
            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet("Databases");
            adapter.Fill(dataSet);
            
            var databases = new List<Databases>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var database = new Databases
                {
                    id = (int)row["DatabaseId"],
                    text = row["Databasename"].ToString(),
                    Guid = (Guid)row["Guid"],
                    SubdatabaseId = (int)row["SubDataBaseId"],
                    icon = "computer-icons documents",
                    items = GetSubdatabases((int)row["SubDataBaseId"]),

                };

                databases.Add(database);

            }
            
            return Request.CreateResponse(HttpStatusCode.OK, databases);
        }

        public List<Subdatabases> GetSubdatabases(int subDataBaseId)
        {
            var command = new SqlCommand("select * from SubDatabases where SubdatabaseId = " + subDataBaseId + "", conn);
            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet("SubDatabases");
            adapter.Fill(dataSet);

            var subdatabases = new List<Subdatabases>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var subdatabase = new Subdatabases
                {
                    id = (int)row["SubdatabaseId"],
                    pid = 1,
                    Databasename = row["Databasename"].ToString(),
                    text = row["subDatabaseName"].ToString(),
                    Guid = (Guid)row["Guid"],
                    CabinetId = (int)row["CabinetId"],
                    icon = "computer-icons documents",
                    items = GetCabinets((int)row["cabinetId"]),
                };

                subdatabases.Add(subdatabase);
            }

            return subdatabases;
        }

        public List<Cabinets> GetCabinets(int cabinetId)
        {
            var command = new SqlCommand("select * from Cabinets where CabinetId = " + cabinetId + "", conn);
            var adapter = new SqlDataAdapter(command);
            var dataSet = new DataSet("SubDatabases");
            adapter.Fill(dataSet);

            var cabinets = new List<Cabinets>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var cabinet = new Cabinets
                {
                    id = (int)row["CabinetId"],
                    pid = 11,
                    Database = row["Database"].ToString(),
                    SubdatabaseGuid = (Guid)row["SubdatabaseGuid"],
                    text = row["Cabinet"].ToString(),
                    icon = "computer-icons documents",
                    Guid = (Guid)row["Guid"],

                };

                cabinets.Add(cabinet);
            }

            return cabinets;
        }
    }
}
   
   