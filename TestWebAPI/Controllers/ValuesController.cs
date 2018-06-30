using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Xml.Linq;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<SampleData> Get()
        {
            //XElement doc = new XElement("C:\\Ramesh\\TestWebAPI\\TestWebAPI\\App_Data\\SampleData.xml");
            XDocument d =  XDocument.Load("C:\\Ramesh\\TestWebAPI\\TestWebAPI\\App_Data\\SampleData.xml");
            List<SampleData> data = new List<SampleData>();

            //SampleData sdata = new SampleData { Id = "d2032222-47a6-4048-9894-11ab8ebb9f69", ApplicationId = 197104, Type = "Debit", Summary = "Payment", Amount = 50.09, ClearedDate = "2016-08-02T00:00:00", IsCleared = true, PostingDate = "2016-08-01T00:00:00" };
            
            //SampleData sdata1 = new SampleData {Id= "d2032222-47a6-4048-9894-11ab8ebb9f69", ApplicationId= 197104, Type= "Debit", Summary= "Payment", Amount= 50.09, ClearedDate= "2016-08-02T00:00:00", IsCleared=true,PostingDate= "2016-08-01T00:00:00" };
            //data.Add(sdata);
           // data.Add(sdata1);
           

            foreach (XElement element in d.Descendants("Samples").Descendants("SampleData"))

            {
                SampleData sdata2 = new SampleData();
                sdata2.Id = element.Element("Id").Value;
                sdata2.ApplicationId=Convert.ToInt32(element.Element("ApplicationId").Value);
                sdata2.Type = element.Element("Type").Value;
                sdata2.Summary = element.Element("Summary").Value;
                sdata2.Amount =Convert.ToDouble(element.Element("Amount").Value);
                sdata2.PostingDate = element.Element("PostingDate").Value;
                sdata2.IsCleared =Convert.ToBoolean(element.Element("IsCleared").Value);
                sdata2.ClearedDate = element.Element("ClearedDate").Value;

                data.Add(sdata2);

            }
            return  data;
        }

        // GET api/values/5
        public IEnumerable<SampleData> Get(string id)
        {
            
            XDocument d = XDocument.Load("C:\\Ramesh\\TestWebAPI\\TestWebAPI\\App_Data\\SampleData.xml");
            List<SampleData> data = new List<SampleData>();

            XElement element = d.Element("Samples") .Elements("SampleData").Elements("Id").SingleOrDefault(x => x.Value == id.ToString());


            XElement parent = element.Parent;

            SampleData sdata2 = new SampleData();
                sdata2.Id = parent.Element("Id").Value;
                sdata2.ApplicationId = Convert.ToInt32(parent.Element("ApplicationId").Value);
                sdata2.Type = parent.Element("Type").Value;
                sdata2.Summary = parent.Element("Summary").Value;
                sdata2.Amount = Convert.ToDouble(parent.Element("Amount").Value);
                sdata2.PostingDate = parent.Element("PostingDate").Value;
                sdata2.IsCleared = Convert.ToBoolean(parent.Element("IsCleared").Value);
                sdata2.ClearedDate = parent.Element("ClearedDate").Value;

                data.Add(sdata2);

           
            return data;
        }
        
        public void Post([FromBody]SampleData sdata)
        {
            List<SampleData> data = new List<SampleData>();
            XDocument d = XDocument.Load("C:\\Ramesh\\TestWebAPI\\TestWebAPI\\App_Data\\SampleData.xml");
            //XElement element =new XElement();
          

            //SampleData sdata2 = new SampleData();
            //sdata2.Id = "3fdsfsf8-2a06-45b4-b057-45949279b4e5";
            //sdata2.ApplicationId =2330;
            //sdata2.Type = "credit";
            //sdata2.Summary = "payment";
            //sdata2.Amount = 0.0;
            //sdata2.PostingDate = "2018-07-01T00:00:00";
            //sdata2.IsCleared = false;
            //sdata2.ClearedDate = "2018-07-02T00:00:00";

            data.Add(sdata);
            d.Add(data);
            
        }

        // PUT api/values/5
        public void Put(string id, [FromBody]SampleData sdata)
        {
            List<SampleData> data = new List<SampleData>();
            XDocument d = XDocument.Load("C:\\Ramesh\\TestWebAPI\\TestWebAPI\\App_Data\\SampleData.xml");
            XElement element = d.Element("Samples").Elements("SampleData").Elements("Id").SingleOrDefault(x => x.Value == id.ToString());
            XElement parent = element.Parent;

            SampleData sdata2 = new SampleData();
            sdata2.Id = parent.Element("Id").Value;
            sdata2.ApplicationId = sdata.ApplicationId;
            sdata2.Type = sdata.Type;
            sdata2.Summary = sdata.Summary;
            sdata2.Amount = sdata.Amount;
            sdata2.PostingDate = sdata.PostingDate;
            sdata2.IsCleared = sdata.IsCleared;
            sdata2.ClearedDate = sdata.ClearedDate;

            data.Add(sdata2);
            d.Add(data);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            XDocument d = XDocument.Load("C:\\Ramesh\\TestWebAPI\\TestWebAPI\\App_Data\\SampleData.xml");
            XElement element = d.Element("Samples").Elements("SampleData").Elements("Id").SingleOrDefault(x => x.Value == id.ToString());
            XElement parent = element.Parent;
            //d.Remove(element.RemoveAll);
        }
    }
}
