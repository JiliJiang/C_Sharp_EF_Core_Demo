using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EFDemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _peopleContext;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext peopleContext)
        {
            _logger = logger;
            _peopleContext = peopleContext;
        }

        public void OnGet()
        {
            LoadSampleData();
            var myPeople = _peopleContext.People
                .Include(p => p.Addresses)
                .Include(p=> p.Emails)
                .ToList();
        }

        private void LoadSampleData()
        {
            if(!_peopleContext.People.Any())
            {
                string file = System.IO.File.ReadAllText("dataset.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _peopleContext.AddRange(people);
                _peopleContext.SaveChanges();
            }
        }
    }
}