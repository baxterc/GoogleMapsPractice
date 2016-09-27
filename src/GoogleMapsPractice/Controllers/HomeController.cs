using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleMapsPractice.Models;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GoogleMapsPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task <IActionResult> Search(LocationSearch newSearch)
        {
            var client = new RestClient("https://maps.googleapis.com/maps/api/place");
            var placesRequest = new RestRequest("/nearbysearch/json?location=" + newSearch.Lat + "," + newSearch.Long + "&radius=1000&name=" + newSearch.Description + "&key=AIzaSyCVSYAYFCgQRLTaigD-y5QZfoZj_LhbbWU", Method.POST);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, placesRequest) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
 
            Console.WriteLine(jsonResponse);
            
            return Json(jsonResponse);
        }
        public IActionResult Results(object result)
        {
            ViewBag.result = result;
            return View();
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
