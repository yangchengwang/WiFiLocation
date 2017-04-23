﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WiFiLocationServer.Models;
using WiFiLocationServer.DB;
using System.Text;
using System.Data;
using Newtonsoft.Json.Linq;


namespace WiFiLocationServer.Controllers
{
    public class DataTestController : ApiController
    {
        DB.data_test db = new DB.data_test();
        DB.rssi rssiDb = new DB.rssi();
        DB.fingerprint fingerDb = new DB.fingerprint();

        // Get /api/DataTest/id
        [HttpGet]
        public DataSet GetById(int id)
        {
            //Models.data_test model = db.GetModel(id);
            //dataset ds = rssidb.getrssilist("room_id = " + id + " and mobile_id = 3 and mac in ('0a:69:6c:51:36:80','0a:69:6c:51:36:7f')");
            DataSet ds = fingerDb.getCoordList(Convert.ToString(id));
            var response = Request.CreateResponse();
            if (ds != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(ds.ToString(), Encoding.Unicode);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
                response.Content = new StringContent("{\"message\":\"无该资源\"}", Encoding.Unicode);
            }
            return ds;
        }

    }
}