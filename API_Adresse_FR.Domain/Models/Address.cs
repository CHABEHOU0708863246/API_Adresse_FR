using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Adresse_FR.Domain.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public List<Feature> Features { get; set; }
        public string Attribution { get; set; }
        public string Licence { get; set; }
        public string Query { get; set; }
        public int Limit { get; set; }
        public Properties Properties { get; set; }
    }


    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }


    public class Properties
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Label { get; set; }
        public double Score { get; set; }
        public string HouseNumber { get; set; }
        public string FeatureId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string CityCode { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string City { get; set; }
        public string Context { get; set; }
        public double Importance { get; set; }
        public string Street { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public string version { get; set; }
        public List<Feature> features { get; set; }
        public string attribution { get; set; }
        public string licence { get; set; }
        public string query { get; set; }
        public int limit { get; set; }
    }
}
