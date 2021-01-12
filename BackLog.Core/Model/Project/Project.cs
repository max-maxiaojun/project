using Abp.Domain.Entities.Auditing;
using BackLog.Authorization.Users;
using BackLog.EnumDictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackLog.Model
{
    public class Project : FullAuditedEntity<Guid>
    {
        public const int MaxProjectIdLength = 50;
        public const int MaxProjectNameLength = 150;

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required, StringLength(MaxProjectIdLength)]
        public virtual string ProjectId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required, StringLength(MaxProjectNameLength)]
        public virtual string ProjectName { get; set; }

        /// <summary>
        /// DM
        /// </summary>
        [Required]
        public virtual long DMUserId { get; set; }

        /// <summary>
        /// PM
        /// </summary>
        
        public long? PMUserId { get; set; }

        [Required]
        public virtual Practice Practice { get; set; }

        /// <summary>
        /// BRM
        /// </summary>
        
        public long? BRMUserId { get; set; }

        /// <summary>
        /// 客户  
        /// </summary>
        [Required]
        public virtual Guid ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Required]
        public virtual ProjectStatus ProjectStatus { get; set; }

        [Required]
        public virtual Geography Geography { get; set; }

        /// <summary>
        /// 项目开始时间
        /// </summary>
        public virtual DateTime ProjectStart { get; set; }

        /// <summary>
        /// 项目结束时间
        /// </summary>
        public virtual DateTime ProjectEnd { get; set; }
            
        /// <summary>
        /// 销售概率
        /// </summary>

        public virtual decimal? PipelineProportion { get; set; }

    }
}
