using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApp.Models;

public class UsersController : Controller
{
    private readonly HttpClient _httpClient;

    public UsersController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    private string baseUrl = "http://localhost:6001/api/user"; // Adjust to match UserService launchsettings

    // GET: Users
    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync(baseUrl);
        if (!response.IsSuccessStatusCode)
        {
            return View(new List<UserViewModel>());
        }

        var content = await response.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
        return View(users);
    }

    // GET: Users/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Users/Create
    [HttpPost]
 
    public async Task<IActionResult> Create(UserViewModel user)
    {
        var json = JsonConvert.SerializeObject(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(baseUrl, content);
        var responseBody = await response.Content.ReadAsStringAsync(); // Log the body for debugging

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Error = $"Failed to create user. Status: {response.StatusCode}, Body: {responseBody}";
        return View(user);
    }


    // GET: Users/Edit/5


    public async Task<IActionResult> Edit(int id)
    {
        var response = await _httpClient.GetAsync($"{baseUrl}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var content = await response.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<UserViewModel>(content);
        return View(user);
    }

    // POST: Users/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, UserViewModel user)
    {
        var json = JsonConvert.SerializeObject(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{baseUrl}/{id}", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    // GET: Users/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.GetAsync($"{baseUrl}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var content = await response.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<UserViewModel>(content);
        return View(user);
    }

    // POST: Users/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _httpClient.DeleteAsync($"{baseUrl}/{id}");
        return RedirectToAction(nameof(Index));
    }

    // GET: Users/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetAsync($"{baseUrl}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var content = await response.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<UserViewModel>(content);
        return View(user);
    }
}
