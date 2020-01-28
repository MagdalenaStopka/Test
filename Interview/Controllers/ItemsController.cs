using Interview.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Interview.Controllers
{
    public class ItemsController : ApiController
    {
      
        public IEnumerable<ItemModel> Get()
        {
            var content = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/data.json"));
            var items = Newtonsoft.Json
                .JsonConvert
                .DeserializeObject<IEnumerable<ItemModel>>(content).ToList();

            return items;
        }
        public ItemModel Get(string id)
        {
            var content = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/data.json"));
            var items = Newtonsoft.Json
                .JsonConvert
                .DeserializeObject<IEnumerable<ItemModel>>(content).ToList();

            var item = items.Where(e => e.Id == id)
                .SingleOrDefault<ItemModel>();

            return item;
        }

        public void Post([FromBody]ItemModel model)
        {
            var content = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/data.json"));
            var items = Newtonsoft.Json
             .JsonConvert
             .DeserializeObject<IEnumerable<ItemModel>>(content).ToList();

            var item = new ItemModel()
            {
                Id = model.Id,
                ApplicationId = model.ApplicationId,
                Type = model.Type,
                Summary = model.Summary,
                Amount = model.Amount,
                PostingDate = model.PostingDate,
                IsCleared = model.IsCleared,
                ClearedDate = model.ClearedDate
            };

            items.Add(item);
            content = Newtonsoft.Json.JsonConvert.SerializeObject(items);
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/App_Data/data.json"), content);

           
        }

        public void Put([FromBody]ItemModel model)
        {
            
        }

        public void Delete(string id)
        {
           
        }

    }
}
