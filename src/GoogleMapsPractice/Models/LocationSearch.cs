using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace GoogleMapsPractice.Models
{
    [Table("Sightings")]
    public class LocationSearch
    {
        [Key]
        public int Id { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public string Description { get; set; }

        public void CenterMap()
        {

        }

    }  
}
