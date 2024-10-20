using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DoctorAppoinment.Models.VM;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Newtonsoft.Json;

namespace financemanagement.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController()
        {
            // Initialize HttpClient
            _httpClient = new HttpClient();
        }
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(Login loginVm)
        {
            var apiUrl = "http://localhost:25869/api/ApplicationUser/Login?username=" + loginVm.UserName + "&password=" + loginVm.Password;

            // Create the data to send in the POST request


            try
            {
                // Serialize the login data to JSON format
                var jsonData = JsonConvert.SerializeObject(loginVm);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send POST request to the API
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // You can deserialize the response if needed
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                    // Store the token or handle the API response

                    if (apiResponse == null)
                    {
                        ViewBag.ErrorMessage = "Login failed. Please check your credentials.";
                        return View();
                    }
                    else
                    {
                        Session["token"] = apiResponse.refreshToken;
                        ViewBag.Token = apiResponse.refreshToken;
                        return RedirectToAction("Index", "Home");
                    }
                }
                // Redirect to Home after successful login

                else
                {
                    // Handle error response from API
                    ViewBag.ErrorMessage = "Login failed. Please check your credentials.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ViewBag.ErrorMessage = "Login failed. Please check your credentials";
                return View();
            }
        }
    }

    // Example of response model (adjust according to your API response structure)
    public class ApiResponse
    {
        public string refreshToken { get; set; }
    }

}
