using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaloniaApp.Models
{
    /// <summary>
    /// 半成品出库表身实体类
    /// </summary>
    [Table("HalfOutBody")]
    public class HalfOutBody
    {
        /// <summary>
        /// 主键，自增
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Guid { get; set; }

        /// <summary>
        /// 半成品出库计划身ID
        /// </summary>
        public int HalfOutPlanBodyID { get; set; } = 0;

        /// <summary>
        /// 单据编号
        /// </summary>
        [StringLength(20)]
        public string? BodyID { get; set; }

        /// <summary>
        /// 计划来源
        /// </summary>
        public int? PlanSource { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int? CustID { get; set; }

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
        /// 托盘编号
        /// </summary>
        [StringLength(50)]
        public string? TrayCode { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        [StringLength(50)]
        public string? CPNo { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? CPID { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [StringLength(50)]
        public string? OrderNo { get; set; }

        /// <summary>
        /// 客户订单号
        /// </summary>
        [StringLength(50)]
        public string? CustOrderNo { get; set; }

        /// <summary>
        /// 工厂ID
        /// </summary>
        public int? FactoryID { get; set; }

        /// <summary>
        /// 单据身关键ID
        /// </summary>
        public int? BodyKeyID { get; set; }

        /// <summary>
        /// 半成品出库ID
        /// </summary>
        public int? HalfOutID { get; set; }

        /// <summary>
        /// 计价方式
        /// </summary>
        public int? PriceWay { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public int? DType { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int? WareHouse { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [StringLength(50)]
        public string? WareHouseName { get; set; }

        /// <summary>
        /// 仓库区域ID
        /// </summary>
        public int? WHSecID { get; set; }

        /// <summary>
        /// 仓库区域名称
        /// </summary>
        [StringLength(50)]
        public string? WHSecName { get; set; }

        /// <summary>
        /// 机器ID
        /// </summary>
        public int? MachineID { get; set; }

        /// <summary>
        /// 机器名称
        /// </summary>
        [StringLength(10)]
        public string? MachineName { get; set; }

        /// <summary>
        /// 班别类型
        /// </summary>
        public int? ClassType { get; set; }

        /// <summary>
        /// 班别类型名称
        /// </summary>
        [StringLength(20)]
        public string? ClassTypeName { get; set; }

        /// <summary>
        /// 颜色类型ID
        /// </summary>
        public int? CTypeID { get; set; }

        /// <summary>
        /// 颜色类型名称
        /// </summary>
        [StringLength(20)]
        public string? CTypeName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int? PNums { get; set; }

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
        /// 单价
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Money { get; set; }

        /// <summary>
        /// 计划重量
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PlanWeight { get; set; }

        /// <summary>
        /// 生产计划ID
        /// </summary>
        public int? MPID { get; set; }

        /// <summary>
        /// 计划ID
        /// </summary>
        public int? PlanID { get; set; }

        /// <summary>
        /// 导入单号
        /// </summary>
        [StringLength(20)]
        public string? ImportBillNo { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        [StringLength(30)]
        public string? OrderID { get; set; }

        /// <summary>
        /// 订单身关键ID
        /// </summary>
        public int? HBCID { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [StringLength(50)]
        public string? MakeNo { get; set; }

        /// <summary>
        /// 其他金额
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OtherMoney { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string? BRem { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        [StringLength(60)]
        public string? Prd_No { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [StringLength(200)]
        public string? Prd_Name { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        [StringLength(100)]
        public string? SpecName { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        [StringLength(100)]
        public string? BatchNo { get; set; }

        /// <summary>
        /// 幅宽
        /// </summary>
        [StringLength(100)]
        public string? CWidth { get; set; }

        /// <summary>
        /// 克重
        /// </summary>
        [StringLength(100)]
        public string? CWeight { get; set; }

        /// <summary>
        /// 毛高
        /// </summary>
        [StringLength(100)]
        public string? CMaoGao { get; set; }

        /// <summary>
        /// 颜色名称
        /// </summary>
        [StringLength(100)]
        public string? ColorName { get; set; }

        /// <summary>
        /// 鞋码
        /// </summary>
        [StringLength(100)]
        public string? ShoeSize { get; set; }

        /// <summary>
        /// 订单身ID
        /// </summary>
        [StringLength(100)]
        public string? OrderBodyID { get; set; }

        /// <summary>
        /// 织造类型
        /// </summary>
        public int? ClothMakeType { get; set; }

        /// <summary>
        /// 织造类型名称
        /// </summary>
        [StringLength(100)]
        public string? ClothMakeTypeName { get; set; }

        /// <summary>
        /// 双数量
        /// </summary>
        public int? DualNums { get; set; }

        /// <summary>
        /// 父产品编号
        /// </summary>
        [StringLength(60)]
        public string? P_Prd_No { get; set; }

        /// <summary>
        /// 父产品名称
        /// </summary>
        [StringLength(200)]
        public string? P_Prd_Name { get; set; }

        /// <summary>
        /// 父产品规格
        /// </summary>
        [StringLength(100)]
        public string? P_SpecName { get; set; }

        /// <summary>
        /// 父产品批号
        /// </summary>
        [StringLength(100)]
        public string? P_BatchNo { get; set; }

        /// <summary>
        /// 父产品幅宽
        /// </summary>
        [StringLength(100)]
        public string? P_CWidth { get; set; }

        /// <summary>
        /// 父产品克重
        /// </summary>
        [StringLength(100)]
        public string? P_CWeight { get; set; }

        /// <summary>
        /// 父产品毛高
        /// </summary>
        [StringLength(100)]
        public string? P_CMaoGao { get; set; }

        /// <summary>
        /// 是否来自库存
        /// </summary>
        [StringLength(5)]
        public string? IsFromStock { get; set; }

        /// <summary>
        /// 半成品出库计划ID
        /// </summary>
        [StringLength(50)]
        public string? HalfOutPlanID { get; set; }

        /// <summary>
        /// 是否已出库
        /// </summary>
        [StringLength(5)]
        public string? IsCheckOut { get; set; }

        /// <summary>
        /// 出库重量比例
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OutWeightRate { get; set; }

        /// <summary>
        /// 半成品入库ID
        /// </summary>
        public int? HalfInID { get; set; }
    }
}
