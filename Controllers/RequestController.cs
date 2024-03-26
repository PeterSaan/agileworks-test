using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using agileworks_test.Models;

namespace agileworks_test.Controllers;

public class RequestController : Controller
{
    static List<Request> requests = new List<Request>();

    public IActionResult Index()
    {
        return View(requests);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Request request)
    {
        // TODO: Implement the logic to check for last id and, if needed, increment it. ID should be unique and autoincremented.
        int id = requests.Count + 1;
        request.Id = id;
        request.Created_at = DateTime.Now;
        request.Solved = true;
        requests.Add(request);
        return RedirectToAction("Index");
    }

    public IActionResult Solved(int id)
    {
        requests.RemoveAt(requests.FindIndex(r => r.Id == id));
        return RedirectToAction("Index");
    }
}