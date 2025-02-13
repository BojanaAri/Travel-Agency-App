﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;

namespace TravelAgency.Domain.DomainModelsFromMusicStore
{
    public class Album : BaseEntity
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Details { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? CoverImage { get; set; }

        // Foreign Key for Artist (One-to-Many)
        public Guid ArtistId { get; set; }
        public Artist? Artist { get; set; }

    }
}
