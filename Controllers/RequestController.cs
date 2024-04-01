using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using agileworks_test.Models;

namespace agileworks_test.Controllers;

public class RequestController : Controller
{
    static List<Request> requests = new List<Request>();

    public IActionResult Index()
    {
        return View(requests.OrderBy(r => r.ToBeSolvedBy));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Request request)
    {
        int id = requests.Count + 1;

        request.Id = id;
        request.CreatedAt = DateTime.Now;
        request.Solved = false;
        requests.Add(request);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Solved(int id)
    {
        requests.RemoveAt(requests.FindIndex(r => r.Id == id));
        return RedirectToAction("Index");
    }

    public IActionResult Solved(Request request)
    {
        return View(request);
    }
}