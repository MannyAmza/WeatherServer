using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CountryModel;

[Table("Country")]
public partial class Country
{
    [Key]
    [Column("CountryID")]
    public int CountryID { get; set; }

    //[StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(2)]
    [Unicode(false)]
    public string Iso2 { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string Iso3 { get; set; } = null!;

    [InverseProperty("CityNavigation")]
    public virtual City? City { get; set; }
}
