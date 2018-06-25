using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.DB
{
    public class FoodPlaceDB
    {
        public List<FoodPlace> GetAllFoodPlaces()
        {
            using (Context ctx = new Context())
            {
                return ctx.FoodPlaces.ToList();
            }
        }
        public bool CreateFoodPlace(FoodPlace foodplace)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.FoodPlaces.Add(foodplace);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateFoodPlace(FoodPlace foodplace)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.FoodPlaces.Attach(foodplace);
                    ctx.Entry(foodplace).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteFoodPlace(FoodPlace foodplace)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.FoodPlaces.Attach(foodplace);
                    ctx.FoodPlaces.Remove(foodplace);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}