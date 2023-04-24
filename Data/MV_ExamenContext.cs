using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MV_Examen.Models;

namespace MV_Examen.Data
{
    public class MV_ExamenContext : DbContext
    {
        public MV_ExamenContext (DbContextOptions<MV_ExamenContext> options)
            : base(options)
        {
        }

        public DbSet<MV_Examen.Models.MF_Vasconez> MF_Vasconez { get; set; } = default!;

        public DbSet<MV_Examen.Models.VR_Fabiana>? VR_Fabiana { get; set; }
    }
}
