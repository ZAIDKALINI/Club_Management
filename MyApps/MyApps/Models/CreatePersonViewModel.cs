using Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace MyApps.Models
{
    public class CreatePersonViewModel
    {
       
        public Guid Person_Id { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Phone { get; set; }

        public DateTime DateInscri { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public Genre genre { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile image { get; set; }
    }
    public class EditPersonViewModel
    {

        public Guid Person_Id { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Phone { get; set; }

        public DateTime DateInscri { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adresse { get; set; }
        public Genre genre { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile image { get; set; }
    }
}
