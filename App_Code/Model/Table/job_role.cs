using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class job_role
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [StringLength(2)]
    public string role_id { get; set; }

    [StringLength(10)]
    public string role_name { get; set; }

    [StringLength(50)]
    public string role_auth { get; set; }
}
