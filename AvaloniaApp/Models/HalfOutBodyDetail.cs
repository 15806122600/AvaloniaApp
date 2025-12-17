using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaloniaApp.Models
{
    /// <summary>
    /// 白坯出库表身明细实体类
    /// </summary>
    [Table("HalfOutBodyDetail")]
    public class HalfOutBodyDetail
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [StringLength(25)]
        public string? Guid { get; set; }

        /// <summary>
        /// 操作日期
        /// </summary>
        [StringLength(50)]
        public string? DoDate { get; set; }

        /// <summary>
        /// 操作编号
        /// </summary>
        [StringLength(25)]
        public string DoCode { get; set; } = "";

        /// <summary>
        /// 操作身编号
        /// </summary>
        [StringLength(25)]
        public string? DoBodyCode { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        [StringLength(20)]
        public string? BodyID { get; set; }

        /// <summary>
        /// 扫描客户ID
        /// </summary>
        public int? ScanCustID { get; set; }

        /// <summary>
        /// 工厂ID
        /// </summary>
        public int? FactoryID { get; set; }

        /// <summary>
        /// 半成品出库ID
        /// </summary>
        public int? HalfOutID { get; set; }

        /// <summary>
        /// 单据身关键ID
        /// </summary>
        public int? BodyKeyID { get; set; }

        /// <summary>
        /// 坯布编号
        /// </summary>
        [StringLength(50)]
        public string? ByCode { get; set; }

        /// <summary>
        /// 机台编号
        /// </summary>
        [StringLength(50)]
        public string? FrameByCode { get; set; }

        /// <summary>
        /// 颜色类型ID
        /// </summary>
        public int? CTypeID { get; set; }

        /// <summary>
        /// 颜色类型名称
        /// </summary>
        [StringLength(50)]
        public string? CTypeName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int? PNums { get; set; }

        /// <summary>
        /// 是否已检查
        /// </summary>
        [StringLength(2)]
        public string? isChecked { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Weight { get; set; }

        /// <summary>
        /// 米数
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Meters { get; set; }

        /// <summary>
        /// 双数量
        /// </summary>
        public int? DualNums { get; set; }

        /// <summary>
        /// 入库明细关键ID
        /// </summary>
        public int? InDetailKeyID { get; set; }
    }
}
