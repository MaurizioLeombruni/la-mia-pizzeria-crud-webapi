using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTest.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Un nome non può essere più lungo di 100 caratteri!")]
        public string? Name { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Column(TypeName = "varchar(500)")]
        [StringLength(500, ErrorMessage = "L'URL inserito è troppo lungo (max 500 caratteri)")]
        public string? Image { get; set; }

        [Column(TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "Ao va bene che non siamo una carità, ma così me sembra troppo!")]
        public string? Price { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public Pizza()
        {

        }

        public Pizza(int id, string name, string description, string image, string price)
        { 
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
