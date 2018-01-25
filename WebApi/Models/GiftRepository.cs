using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public static class GiftRepository
    {
        public static List<Gifts> listOfGifts = new List<Gifts>();
        public static object myLock = new object();

        public static void Populate()
        {
            Gifts a = new Gifts("Pony", true, true);
            Gifts b = new Gifts("Axe", false, true);
            Gifts c = new Gifts("Axe", true, false);

            listOfGifts.Add(a);
            listOfGifts.Add(b);
            listOfGifts.Add(c);

        }
        public static string Add(string name, bool girl, bool boy)
        {
            lock (myLock) {
                string message = ("Gift created");
                listOfGifts.Add(new Gifts(name, girl, boy));
                return message;
            }

        }

        public static List<Gifts> GetAllGifts()
        {
            Populate();
            lock (myLock)
            {
                return listOfGifts.ToList();
            }
        }

        public static List<Gifts> GetAllGirlGifts()
        {
            
            List<Gifts> girlGifts = new List<Gifts>();
            lock (myLock)
            { 
            foreach (Gifts a in listOfGifts)
                    if (a.GirlGift == true)
                    {
                        girlGifts.Add(a);
                    }
             }
            return girlGifts;
        }
    }
}