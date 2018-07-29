﻿using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class FoodPlaceDB
    {
        public ICollection<FoodPlace> GetAllFoodPlaces()
        {
            using (Context ctx = new Context())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                return ctx.FoodPlaces
                    .Include("City")
                    .Include("PatientAtFoodplaces")
                    .ToList();
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