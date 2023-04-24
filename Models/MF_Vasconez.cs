using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MV_Examen.Models
{
    public class MF_Vasconez
    {

        [System.ComponentModel.DataAnnotations.Required]
        public int Id { get; set; }
        [Range(450, 1000000)]
        public decimal Salariomf { get; set; }
        [StringLength(10)]
        public string? Nombremf { get; set; }
        public bool Activomf { get; set; }
        public DateTime Cumpleañosmf { get; set; }

        public int Idv { get; set; }

    }
}
