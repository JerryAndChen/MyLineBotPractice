using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class agent_apply
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [Column(TypeName = "numeric")]
    public decimal agtId { get; set; }

    [StringLength(50)]
    public string applNo { get; set; }

    [StringLength(10)]
    public string applName { get; set; }

    [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime applTime { get; set; }

    [StringLength(1)]
    public string isApprove { get; set; }
}
