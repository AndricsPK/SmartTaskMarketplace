using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApp.Models;

public class TasksController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string taskServiceUrl = "https://localhost:5001/api/task";

    public TasksController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    // GET: /Tasks
    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await _httpClient.GetAsync(taskServiceUrl);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"Error: {response.StatusCode}";
                return View(new List<TaskItemViewModel>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<TaskItemViewModel>>(content);
            return View(tasks);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Exception: {ex.Message}";
            return View(new List<TaskItemViewModel>());
        }
    }

    // GET: /Tasks/Details/5
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{taskServiceUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<TaskItemViewModel>(content);
            return View(task);
        }
        catch
        {
            return NotFound();
        }
    }

    // GET: /Tasks/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Tasks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskItemViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        try
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(taskServiceUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = $"Failed to create task. Status: {response.StatusCode}";
            return View(model);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Exception: {ex.Message}";
            return View(model);
        }
    }

    // GET: /Tasks/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{taskServiceUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<TaskItemViewModel>(content);
            return View(task);
        }
        catch
        {
            return NotFound();
        }
    }

    // POST: /Tasks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TaskItemViewModel model)
    {
        if (id != model.Id) return BadRequest();

        if (!ModelState.IsValid) return View(model);

        try
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{taskServiceUrl}/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = $"Failed to update task. Status: {response.StatusCode}";
            return View(model);
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Exception: {ex.Message}";
            return View(model);
        }
    }

    // GET: /Tasks/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{taskServiceUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<TaskItemViewModel>(content);
            return View(task);
        }
        catch
        {
            return NotFound();
        }
    }

    // POST: /Tasks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{taskServiceUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = $"Failed to delete task. Status: {response.StatusCode}";
            return RedirectToAction(nameof(Delete), new { id });
        }
        catch (Exception ex)
        {
            ViewBag.Error = $"Exception: {ex.Message}";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
