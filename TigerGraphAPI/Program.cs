using System;
using TigerGraphAPI.Managers.TG;
using TigerGraphAPI.Managers.TigerGraphAPI;

namespace TigerGraphAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TGRESTPPManager TGRPPMgr = new TGRESTPPManager("https://2c52cbcd2cb642579703bccbf2cfa36b.i.tgcloud.io", authtoken: "vppn7le7t2c2eq1jh9b9oe5ps9okmlkm");

            //Models.TigerGraphAPI.ResponseEcho result = TGRPPMgr.getEcho();
            //Models.TigerGraphAPI.ResponsegetEndpoints endpoints = TGRPPMgr.getEndpoints();
            //result = result;

            // not functional yet
            TGRESTManager TGMgr = new TGRESTManager("http://10.10.20.101:14240/", "tigergraph", "tigergrap");

            string result = TGMgr.postLogin("tigergraph", "tigergrap");
        }
    }
}
