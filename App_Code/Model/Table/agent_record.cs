using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class agent_record
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [Column(TypeName = "numeric")]
    public decimal agtId { get; set; }

    [StringLength(50)]
    public string agtUserId { get; set; }

    [StringLength(10)]
    public string agtUserName { get; set; }
}
