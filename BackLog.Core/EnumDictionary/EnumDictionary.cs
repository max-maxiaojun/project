using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BackLog.EnumDictionary
{
    public enum Practice
    {
		[Description("AMS")]
		AMS,
		[Description("ITIS")]
		ITIS,
		[Description("BPO")]
		BPO,
		[Description("ERP")]
		ERP,
		[Description("Development")]
		Development,
		[Description("QA&Testing")]
		QATesting,
		[Description("Staffing")]
		Staffing,
		[Description("Product")]
		Product,
		[Description("Business Consulting")]
		BusinessConsulting,
		[Description("China")]
		China,
		[Description("Other")]
		Other,
	}

    public enum ProjectStatus
    {
		[Description("Active")]
		Active = 1,
		[Description("Closed")]
		Closed = 2,
		[Description("Bidding")]
		Bidding=3

	}

	public enum PipelineProportion
	{
		[Description("Existence")]
		Existence = 1,
		[Description("No Existence")]
		None = 0,
	}

	public enum Pipeline
	{
		[Description("Yes")]
		Existence = 1,
		[Description("No")]
		None = 0,
	}



	public enum Geography
    {
       [Description("China")]
	   China,
	   [Description("GNSS")]
	   GNSS
    }

    public enum Month
    {
        [Description("January")]
        Jan = 1,
        [Description("February")]
        Feb,
        [Description("March")]
        Mar,
        [Description("April")]
        Apr,
        [Description("May")]
        May,
        [Description("June")]
        Jun,
        [Description("July")]
        Jul,
        [Description("August")]
        Aug,
        [Description("September")]
        September,
        [Description("October")]
        Oct,
        [Description("November")]
        Nov,
        [Description("December")]
        Dec,
    }

    public enum BackLogStatus
    {
		[Description("Closed")]
		Closed=0,
		[Description("InProgress")]
		InProgress=1,
		[Description("Done")]
		Done=2,
		[Description("Rejected")]
		Rejected=3,
		[Description("Open")]
		Open = 4,
	}
}
