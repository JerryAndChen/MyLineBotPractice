using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class tree_menu
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [StringLength(5)]
    public string menu_id { get; set; }

    [StringLength(2)]
    public string level { get; set; }

    [StringLength(20)]
    public string name { get; set; }

    [StringLength(255)]
    public string url { get; set; }

    [StringLength(1)]
    public string cancel { get; set; }
}
