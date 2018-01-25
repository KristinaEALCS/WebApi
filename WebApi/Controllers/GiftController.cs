using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class GiftController : ApiController
    {
        // GET: api/Gift
        public List<Gifts> GetAll()
        {
            
            return GiftRepository.GetAllGifts();
        }

        // GET: api/Gift
        [Route("api/Gift/GetGirl")]
        public List<Gifts> GetGirl()
        {
            return GiftRepository.GetAllGirlGifts();
        }


        // POST: api/Gift
        public void Post([FromBody]Gifts gifts)
            
        {
            GiftRepository.Add(gifts.GiftName, gifts.GirlGift, gifts.BoyGift);
        }

        // PUT: api/Gift/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gift/5
        public void Delete(int id)
        {
        }
    }
}
