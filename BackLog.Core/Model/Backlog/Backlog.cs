using Abp.Domain.Entities.Auditing;
using BackLog.EnumDictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackLog.Model
{
    public class Backlog : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 关联项目主键
        /// </summary>
        [Required]
        public virtual Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        [Required]
        public virtual int Year { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        [Required]
        public virtual Month Month { get; set; }

        /// <summary>
        /// Backlog
        /// </summary>
        [Required]
        [DecimalPrecision(18, 2)]
        public virtual decimal Revenue { get; set; }

        /// <summary>
        /// 调整值
        /// </summary>
        [Required]
        [DecimalPrecision(18, 2)]
        public virtual decimal Variance { get; set; }

        /// <summary>
        /// 预期值
        /// </summary>
        [Required]
        [DecimalPrecision(18, 2)]
        public virtual decimal Forecast { get; set; }

        /// <summary>
        /// 统计
        /// </summary>
        [Required]
        [DecimalPrecision(18, 2)]
        public virtual decimal Total { get; set; }

        /// <summary>
        /// 潜在销售值
        /// </summary>
        [Required]
        [DecimalPrecision(18, 2)]
        public virtual decimal Pipeline { get; set; }

        /// <summary>
        /// 销售概率
        /// </summary>
        [Required]
        [DecimalPrecision(2, 0)]
        public virtual decimal PipelineProportion { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual BackLogStatus BackLogStatus { get; set; }
    }
}
