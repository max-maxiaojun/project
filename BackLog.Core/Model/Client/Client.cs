using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackLog.Model
{
    /// <summary>
    /// 客户管理
    /// </summary>
    public class Client : FullAuditedEntity<Guid>, IPassivable
    {
        public const int MaxCodeLength = 50;
        public const int MaxBEULength = 100;
        public const int MaxAbbreviationLength = 100;

        /// <summary>
        /// 代号
        /// </summary>
        [Required, StringLength(MaxCodeLength)]
        public string Code { get; set; }

        /// <summary>
        /// business unit 业务部门
        /// </summary>
        [Required, StringLength(MaxCodeLength)]
        public string BEU { get; set; }

        /// <summary>
        /// 全称
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [Required,StringLength(MaxAbbreviationLength)]
        public string Abbreviation { get; set; }

        public bool IsActive { get; set; }

        public string Phone { get; set; }

        public string Contacts { get; set; }

        public string Mail { get; set; }

        public int? CustomerID { get; set; }

        //public int CMSCustomerID { get;set; }


    }
}
