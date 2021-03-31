/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TestRequestParser
{
	[XmlRoot(ElementName = "line")]
	public class Line
	{
		[XmlAttribute(AttributeName = "seq")]
		public string Seq { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "special_instruction")]
	public class Special_instruction
	{
		[XmlElement(ElementName = "line")]
		public List<Line> Line { get; set; }
	}

	[XmlRoot(ElementName = "special_disposition")]
	public class Special_disposition
	{
		[XmlElement(ElementName = "line")]
		public Line Line { get; set; }
	}

	[XmlRoot(ElementName = "special_shipping")]
	public class Special_shipping
	{
		[XmlElement(ElementName = "line")]
		public Line Line { get; set; }
	}

	[XmlRoot(ElementName = "needle_depth_cl")]
	public class Needle_depth_cl
	{
		[XmlAttribute(AttributeName = "uom")]
		public string Uom { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "offset_from_cl")]
	public class Offset_from_cl
	{
		[XmlAttribute(AttributeName = "uom")]
		public string Uom { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "needle_depth_sh")]
	public class Needle_depth_sh
	{
		[XmlAttribute(AttributeName = "uom")]
		public string Uom { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "sh_offset_from_cl")]
	public class Sh_offset_from_cl
	{
		[XmlAttribute(AttributeName = "uom")]
		public string Uom { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "tire_tdwr_ind")]
	public class Tire_tdwr_ind
	{
		[XmlAttribute(AttributeName = "uom")]
		public string Uom { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "tire_rslt")]
	public class Tire_rslt
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "uom")]
		public string Uom { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "tire")]
	public class Tire
	{
		[XmlElement(ElementName = "tire_activity_byte")]
		public string Tire_activity_byte { get; set; }
		[XmlElement(ElementName = "tire_at_test_site")]
		public string Tire_at_test_site { get; set; }
		[XmlElement(ElementName = "tire_status_co")]
		public string Tire_status_co { get; set; }
		[XmlElement(ElementName = "tire_status_machine")]
		public string Tire_status_machine { get; set; }
		[XmlElement(ElementName = "step_set_number")]
		public string Step_set_number { get; set; }
		[XmlElement(ElementName = "tire_test_pref_no")]
		public string Tire_test_pref_no { get; set; }
		[XmlElement(ElementName = "rim_width")]
		public string Rim_width { get; set; }
		[XmlElement(ElementName = "rim_flange")]
		public string Rim_flange { get; set; }
		[XmlElement(ElementName = "tire_disposition")]
		public string Tire_disposition { get; set; }
		[XmlElement(ElementName = "tire_group")]
		public string Tire_group { get; set; }
		[XmlElement(ElementName = "tire_dot_no")]
		public string Tire_dot_no { get; set; }
		[XmlElement(ElementName = "tire_spare_flag")]
		public string Tire_spare_flag { get; set; }
		[XmlElement(ElementName = "tire_rslt")]
		public Tire_rslt Tire_rslt { get; set; }
		[XmlAttribute(AttributeName = "tire_sequence")]
		public string Tire_sequence { get; set; }
	}

	[XmlRoot(ElementName = "tires")]
	public class Tires
	{
		[XmlElement(ElementName = "tire")]
		public Tire Tire { get; set; }
	}

	[XmlRoot(ElementName = "cnst")]
	public class Cnst
	{
		[XmlElement(ElementName = "tire_size")]
		public string Tire_size { get; set; }
		[XmlElement(ElementName = "tire_type_co")]
		public string Tire_type_co { get; set; }
		[XmlElement(ElementName = "needle_depth_cl")]
		public Needle_depth_cl Needle_depth_cl { get; set; }
		[XmlElement(ElementName = "offset_from_cl")]
		public Offset_from_cl Offset_from_cl { get; set; }
		[XmlElement(ElementName = "needle_depth_sh")]
		public Needle_depth_sh Needle_depth_sh { get; set; }
		[XmlElement(ElementName = "sh_offset_from_cl")]
		public Sh_offset_from_cl Sh_offset_from_cl { get; set; }
		[XmlElement(ElementName = "tire_grv_meas_co")]
		public string Tire_grv_meas_co { get; set; }
		[XmlElement(ElementName = "tire_grv_prim_grp")]
		public string Tire_grv_prim_grp { get; set; }
		[XmlElement(ElementName = "tire_grv_scnd_grp")]
		public string Tire_grv_scnd_grp { get; set; }
		[XmlElement(ElementName = "tire_tdwr_ind")]
		public Tire_tdwr_ind Tire_tdwr_ind { get; set; }
		[XmlElement(ElementName = "construction_use_code")]
		public string Construction_use_code { get; set; }
		[XmlElement(ElementName = "tires")]
		public Tires Tires { get; set; }
		[XmlAttribute(AttributeName = "construction_number")]
		public string Construction_number { get; set; }
	}

	[XmlRoot(ElementName = "cnsts")]
	public class Cnsts
	{
		[XmlElement(ElementName = "cnst")]
		public Cnst Cnst { get; set; }
	}

	[XmlRoot(ElementName = "cond")]
	public class Cond
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "seq")]
		public string Seq { get; set; }
		[XmlAttribute(AttributeName = "uom")]
		public string Uom { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "conds")]
	public class Conds
	{
		[XmlElement(ElementName = "cond")]
		public List<Cond> Cond { get; set; }
	}

	[XmlRoot(ElementName = "step")]
	public class Step
	{
		[XmlElement(ElementName = "test_step_number")]
		public string Test_step_number { get; set; }
		[XmlElement(ElementName = "conds")]
		public Conds Conds { get; set; }
		[XmlAttribute(AttributeName = "step_sequence")]
		public string Step_sequence { get; set; }
	}

	[XmlRoot(ElementName = "steps")]
	public class Steps
	{
		[XmlElement(ElementName = "step")]
		public List<Step> Step { get; set; }
	}

	[XmlRoot(ElementName = "step_set")]
	public class Step_set
	{
		[XmlElement(ElementName = "steps")]
		public Steps Steps { get; set; }
		[XmlAttribute(AttributeName = "step_set_number")]
		public string Step_set_number { get; set; }
	}

	[XmlRoot(ElementName = "step_sets")]
	public class Step_sets
	{
		[XmlElement(ElementName = "step_set")]
		public Step_set Step_set { get; set; }
	}

	[XmlRoot(ElementName = "test")]
	public class Test
	{
		[XmlElement(ElementName = "test_rslt_type")]
		public string Test_rslt_type { get; set; }
		[XmlElement(ElementName = "test_pref_no")]
		public string Test_pref_no { get; set; }
		[XmlElement(ElementName = "test_pref_grp")]
		public string Test_pref_grp { get; set; }
		[XmlElement(ElementName = "reissue_date")]
		public string Reissue_date { get; set; }
		[XmlElement(ElementName = "test_site")]
		public string Test_site { get; set; }
		[XmlElement(ElementName = "test_status_co")]
		public string Test_status_co { get; set; }
		[XmlElement(ElementName = "tire_site_flag")]
		public string Tire_site_flag { get; set; }
		[XmlElement(ElementName = "test_code")]
		public string Test_code { get; set; }
		[XmlElement(ElementName = "test_title")]
		public string Test_title { get; set; }
		[XmlElement(ElementName = "preference_date")]
		public string Preference_date { get; set; }
		[XmlElement(ElementName = "project_number")]
		public string Project_number { get; set; }
		[XmlElement(ElementName = "request_purpose")]
		public string Request_purpose { get; set; }
		[XmlElement(ElementName = "originator_name")]
		public string Originator_name { get; set; }
		[XmlElement(ElementName = "originator_department")]
		public string Originator_department { get; set; }
		[XmlElement(ElementName = "special_instruction")]
		public Special_instruction Special_instruction { get; set; }
		[XmlElement(ElementName = "special_disposition")]
		public Special_disposition Special_disposition { get; set; }
		[XmlElement(ElementName = "special_shipping")]
		public Special_shipping Special_shipping { get; set; }
		[XmlElement(ElementName = "cnsts")]
		public Cnsts Cnsts { get; set; }
		[XmlElement(ElementName = "step_sets")]
		public Step_sets Step_sets { get; set; }
		[XmlAttribute(AttributeName = "test_number")]
		public string Test_number { get; set; }
	}

	[XmlRoot(ElementName = "tests")]
	public class Tests
	{
		[XmlElement(ElementName = "test")]
		public Test Test { get; set; }
	}

	[XmlRoot(ElementName = "l2l1testreq")]
	public class L2l1testreq
	{
		[XmlElement(ElementName = "tests")]
		public Tests Tests { get; set; }
	}

}
