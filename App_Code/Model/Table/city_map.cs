using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class city_map
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [StringLength(10)]
    public string up_code_id { get; set; }

    [StringLength(10)]
    public string code_id { get; set; }

    [StringLength(10)]
    public string code_name { get; set; }

    [StringLength(1)]
    public string code_level { get; set; }
}
