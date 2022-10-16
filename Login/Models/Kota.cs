using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class Kota
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
    }
}
