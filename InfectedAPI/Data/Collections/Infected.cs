using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfectedAPI.Data.Collections
{
    public class Infected
    {
        public Infected(DateTime dateBirth, string gender, double latitude, double longitude)
        {
            DateBirth = dateBirth;
            Gender = gender;
            Location = new GeoJson2DGeographicCoordinates(longitude, latitude); ;
        }

        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public GeoJson2DGeographicCoordinates Location { get; set; }
    }
}
