using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class agent_data
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [StringLength(50)]
    public string title { get; set; }

    [StringLength(2)]
    public string roleId { get; set; }

    public int roleCnt { get; set; }

    [StringLength(10)]
    public string cityId { get; set; }

    [StringLength(10)]
    public string districtId { get; set; }

    [StringLength(10)]
    public string storeId { get; set; }

    [StringLength(50)]
    public string agtNo { get; set; }

    [StringLength(10)]
    public string agtName { get; set; }

    [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime agtStartDate { get; set; }

    [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime agtEndDate { get; set; }

    public string agtDescription { get; set; }

    [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? agtApplTime { get; set; }

    [StringLength(50)]
    public string dcsnNo { get; set; }

    [StringLength(10)]
    public string dcsnName { get; set; }

    [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? dcsnTime { get; set; }
}
