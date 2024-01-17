﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restful_MagicVillaAPI.Models
{
    public class Villa
    {
        [Key] //for primary key constraint
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set;}
        public string Details { get; set;}
        public double Rate{ get; set;}
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set; }
    }
}
