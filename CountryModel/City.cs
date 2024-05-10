﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CountryModel;

[Table("City")]
public partial class City
{
    [Key]
    public int CityId { get; set; }

    [Column(TypeName = "numeric(18, 4)")]
    public decimal Latitude { get; set; }

    [Column(TypeName = "numeric(18, 4)")]
    public decimal Longitude { get; set; }

    [Column("CountryID")]
    [StringLength(10)]
    public int CountryId { get; set; }

    public required string Name { get; set; }

    public int Population { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("City")]
    public virtual Country CityNavigation{ get; set; } = null!;
}
