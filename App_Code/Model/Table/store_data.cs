using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class store_data
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [StringLength(10)]
    public string city_id { get; set; }

    [StringLength(10)]
    public string city { get; set; }

    [StringLength(10)]
    public string district_id { get; set; }

    [StringLength(10)]
    public string district { get; set; }

    [StringLength(10)]
    public string store_id { get; set; }

    [StringLength(10)]
    public string store { get; set; }

    [StringLength(100)]
    public string address { get; set; }
}
