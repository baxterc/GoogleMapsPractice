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

        public void Search()
        {
            var client = new RestClient("https://maps.googleapis.com/maps/api/place");
            var request = new RestRequest("/nearbysearch/json?location=" + Lat + "," + Long + "&radius=1000&name=" + Description + "&key=AIzaSyCVSYAYFCgQRLTaigD-y5QZfoZj_LhbbWU", Method.POST);
            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response.Content);
            });
        }
    }  
}
