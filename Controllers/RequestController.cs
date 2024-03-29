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
        int id = requests.Count + 1;

        request.Id = id;
        request.CreatedAt = DateTime.Now;
        request.Solved = false;
        requests.Add(request);
        return RedirectToAction("Index");
    }

    [HttpPatch]
    public IActionResult ChangeStatus(Request request)
    {
        if (ModelState.IsValid)
        {
            var originalRequest = requests.Find(r => r.Id == request.Id);
            bool changed = originalRequest.Solved != request.Solved;
            if (changed)
            {
                originalRequest.Solved = request.Solved;
                originalRequest.SolvedWhen = DateTime.Now;
            }
        }
        return View("Index");
    }
}