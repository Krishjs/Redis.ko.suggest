using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisList.Web.Models
{
    public class CityWrapper
    {
        private CityDataSource.City city;

        public CityDataSource.City City
        {
            get
            {
                if (city == null)
                {
                    this.city = new CityDataSource.City();
                }
                return city;
            }
            set { city = value; }
        }
        
    }
}