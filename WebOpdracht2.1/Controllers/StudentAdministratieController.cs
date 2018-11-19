using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebOpdracht2._1.Models;

namespace WebOpdracht2._1.Controllers
{
    public class StudentAdministratieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ZoekStudenten(char voorletter)
        {
            List<Student> Studenten = new List<Student>();
            Student piet = new Student()
            {
                voornaam = "piet",
                achternaam = "Alexander"

            };
            Student jan = new Student()
            {
                voornaam = "jan",
                achternaam = "Hendriksen"

            };
            Student klaas = new Student()
            {
                voornaam = "klaas",
                achternaam = "Willem"

            };
            Studenten.Add(piet);
            Studenten.Add(jan);
            Studenten.Add(klaas);

            var studentenList = (from student in Studenten
                                where student.achternaam.StartsWith(voorletter)
                                select student).ToList();
            /*
            foreach (Student s in Studenten.ToList())
            {
                if (!s.achternaam.StartsWith(voorletter))
                {
                    Studenten.Remove(s);
                }
            }
            */
            ViewData["voorletter"] = voorletter;
            return View(studentenList);
        }

    }
}