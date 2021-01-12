using Abp.Domain.Entities.Auditing;
using BackLog.EnumDictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackLog.Model
{
    public class MonthClose : FullAuditedEntity<Guid>
    {
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
        /// 财政结算日
        /// </summary>
        public virtual DateTime CloseTime { get; set; }
    }
}
