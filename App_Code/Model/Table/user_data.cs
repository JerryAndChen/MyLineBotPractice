using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class user_data
{
    [Column(TypeName = "numeric")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public decimal id { get; set; }

    [StringLength(50)]
    public string userId { get; set; }

    [StringLength(50)]
    public string userName { get; set; }

    [StringLength(50)]
    public string userPicUrl { get; set; }

    [StringLength(1)]
    public string sexType { get; set; }

    [StringLength(20)]
    public string phone { get; set; }

    [StringLength(50)]
    public string email { get; set; }

    [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode =true)]
    public DateTime birth { get; set; }

    [StringLength(2)]
    public string roleId { get; set; }

    [StringLength(10)]
    public string cityId { get; set; }

    [StringLength(10)]
    public string districtId { get; set; }

    [StringLength(10)]
    public string storeId { get; set; }

    public DateTime? registerTime { get; set; }

    public DateTime? lastLoginTime { get; set; }
}
