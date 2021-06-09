
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class l2l1testreq
{

    private l2l1testreqTests testsField;

    /// <remarks/>
    public l2l1testreqTests tests
    {
        get
        {
            return this.testsField;
        }
        set
        {
            this.testsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTests
{

    private l2l1testreqTestsTest testField;

    /// <remarks/>
    public l2l1testreqTestsTest test
    {
        get
        {
            return this.testField;
        }
        set
        {
            this.testField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTest
{

    private string test_rslt_typeField;

    private ushort test_pref_noField;

    private string test_pref_grpField;

    private System.DateTime reissue_dateField;

    private string test_siteField;

    private string test_status_coField;

    private string tire_site_flagField;

    private string test_codeField;

    private string test_titleField;

    private System.DateTime preference_dateField;

    private string project_numberField;

    private string request_purposeField;

    private string originator_nameField;

    private string originator_departmentField;

    private l2l1testreqTestsTestLine[] special_instructionField;

    private l2l1testreqTestsTestSpecial_disposition special_dispositionField;

    private l2l1testreqTestsTestSpecial_shipping special_shippingField;

    private l2l1testreqTestsTestCnst[] cnstsField;

    private l2l1testreqTestsTestStep_sets step_setsField;

    private string test_numberField;

    /// <remarks/>
    public string test_rslt_type
    {
        get
        {
            return this.test_rslt_typeField;
        }
        set
        {
            this.test_rslt_typeField = value;
        }
    }

    /// <remarks/>
    public ushort test_pref_no
    {
        get
        {
            return this.test_pref_noField;
        }
        set
        {
            this.test_pref_noField = value;
        }
    }

    /// <remarks/>
    public string test_pref_grp
    {
        get
        {
            return this.test_pref_grpField;
        }
        set
        {
            this.test_pref_grpField = value;
        }
    }

    /// <remarks/>
    public System.DateTime reissue_date
    {
        get
        {
            return this.reissue_dateField;
        }
        set
        {
            this.reissue_dateField = value;
        }
    }

    /// <remarks/>
    public string test_site
    {
        get
        {
            return this.test_siteField;
        }
        set
        {
            this.test_siteField = value;
        }
    }

    /// <remarks/>
    public string test_status_co
    {
        get
        {
            return this.test_status_coField;
        }
        set
        {
            this.test_status_coField = value;
        }
    }

    /// <remarks/>
    public string tire_site_flag
    {
        get
        {
            return this.tire_site_flagField;
        }
        set
        {
            this.tire_site_flagField = value;
        }
    }

    /// <remarks/>
    public string test_code
    {
        get
        {
            return this.test_codeField;
        }
        set
        {
            this.test_codeField = value;
        }
    }

    /// <remarks/>
    public string test_title
    {
        get
        {
            return this.test_titleField;
        }
        set
        {
            this.test_titleField = value;
        }
    }

    /// <remarks/>
    public System.DateTime preference_date
    {
        get
        {
            return this.preference_dateField;
        }
        set
        {
            this.preference_dateField = value;
        }
    }

    /// <remarks/>
    public string project_number
    {
        get
        {
            return this.project_numberField;
        }
        set
        {
            this.project_numberField = value;
        }
    }

    /// <remarks/>
    public string request_purpose
    {
        get
        {
            return this.request_purposeField;
        }
        set
        {
            this.request_purposeField = value;
        }
    }

    /// <remarks/>
    public string originator_name
    {
        get
        {
            return this.originator_nameField;
        }
        set
        {
            this.originator_nameField = value;
        }
    }

    /// <remarks/>
    public string originator_department
    {
        get
        {
            return this.originator_departmentField;
        }
        set
        {
            this.originator_departmentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("line", IsNullable = false)]
    public l2l1testreqTestsTestLine[] special_instruction
    {
        get
        {
            return this.special_instructionField;
        }
        set
        {
            this.special_instructionField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestSpecial_disposition special_disposition
    {
        get
        {
            return this.special_dispositionField;
        }
        set
        {
            this.special_dispositionField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestSpecial_shipping special_shipping
    {
        get
        {
            return this.special_shippingField;
        }
        set
        {
            this.special_shippingField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("cnst", IsNullable = false)]
    public l2l1testreqTestsTestCnst[] cnsts
    {
        get
        {
            return this.cnstsField;
        }
        set
        {
            this.cnstsField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestStep_sets step_sets
    {
        get
        {
            return this.step_setsField;
        }
        set
        {
            this.step_setsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string test_number
    {
        get
        {
            return this.test_numberField;
        }
        set
        {
            this.test_numberField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestLine
{

    private byte seqField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte seq
    {
        get
        {
            return this.seqField;
        }
        set
        {
            this.seqField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestSpecial_disposition
{

    private l2l1testreqTestsTestSpecial_dispositionLine lineField;

    /// <remarks/>
    public l2l1testreqTestsTestSpecial_dispositionLine line
    {
        get
        {
            return this.lineField;
        }
        set
        {
            this.lineField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestSpecial_dispositionLine
{

    private byte seqField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte seq
    {
        get
        {
            return this.seqField;
        }
        set
        {
            this.seqField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestSpecial_shipping
{

    private l2l1testreqTestsTestSpecial_shippingLine lineField;

    /// <remarks/>
    public l2l1testreqTestsTestSpecial_shippingLine line
    {
        get
        {
            return this.lineField;
        }
        set
        {
            this.lineField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestSpecial_shippingLine
{

    private byte seqField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte seq
    {
        get
        {
            return this.seqField;
        }
        set
        {
            this.seqField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestCnst
{

    private string tire_sizeField;

    private string tire_type_coField;

    private l2l1testreqTestsTestCnstNeedle_depth_cl needle_depth_clField;

    private l2l1testreqTestsTestCnstOffset_from_cl offset_from_clField;

    private l2l1testreqTestsTestCnstNeedle_depth_sh needle_depth_shField;

    private l2l1testreqTestsTestCnstSh_offset_from_cl sh_offset_from_clField;

    private object tire_grv_meas_coField;

    private object tire_grv_prim_grpField;

    private object tire_grv_scnd_grpField;

    private l2l1testreqTestsTestCnstTire_tdwr_ind tire_tdwr_indField;

    private string construction_use_codeField;

    private l2l1testreqTestsTestCnstTire[] tiresField;

    private string construction_numberField;

    /// <remarks/>
    public string tire_size
    {
        get
        {
            return this.tire_sizeField;
        }
        set
        {
            this.tire_sizeField = value;
        }
    }

    /// <remarks/>
    public string tire_type_co
    {
        get
        {
            return this.tire_type_coField;
        }
        set
        {
            this.tire_type_coField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestCnstNeedle_depth_cl needle_depth_cl
    {
        get
        {
            return this.needle_depth_clField;
        }
        set
        {
            this.needle_depth_clField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestCnstOffset_from_cl offset_from_cl
    {
        get
        {
            return this.offset_from_clField;
        }
        set
        {
            this.offset_from_clField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestCnstNeedle_depth_sh needle_depth_sh
    {
        get
        {
            return this.needle_depth_shField;
        }
        set
        {
            this.needle_depth_shField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestCnstSh_offset_from_cl sh_offset_from_cl
    {
        get
        {
            return this.sh_offset_from_clField;
        }
        set
        {
            this.sh_offset_from_clField = value;
        }
    }

    /// <remarks/>
    public object tire_grv_meas_co
    {
        get
        {
            return this.tire_grv_meas_coField;
        }
        set
        {
            this.tire_grv_meas_coField = value;
        }
    }

    /// <remarks/>
    public object tire_grv_prim_grp
    {
        get
        {
            return this.tire_grv_prim_grpField;
        }
        set
        {
            this.tire_grv_prim_grpField = value;
        }
    }

    /// <remarks/>
    public object tire_grv_scnd_grp
    {
        get
        {
            return this.tire_grv_scnd_grpField;
        }
        set
        {
            this.tire_grv_scnd_grpField = value;
        }
    }

    /// <remarks/>
    public l2l1testreqTestsTestCnstTire_tdwr_ind tire_tdwr_ind
    {
        get
        {
            return this.tire_tdwr_indField;
        }
        set
        {
            this.tire_tdwr_indField = value;
        }
    }

    /// <remarks/>
    public string construction_use_code
    {
        get
        {
            return this.construction_use_codeField;
        }
        set
        {
            this.construction_use_codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("tire", IsNullable = false)]
    public l2l1testreqTestsTestCnstTire[] tires
    {
        get
        {
            return this.tiresField;
        }
        set
        {
            this.tiresField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string construction_number
    {
        get
        {
            return this.construction_numberField;
        }
        set
        {
            this.construction_numberField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestCnstNeedle_depth_cl
{

    private string uomField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uom
    {
        get
        {
            return this.uomField;
        }
        set
        {
            this.uomField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestCnstOffset_from_cl
{

    private string uomField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uom
    {
        get
        {
            return this.uomField;
        }
        set
        {
            this.uomField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestCnstNeedle_depth_sh
{

    private string uomField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uom
    {
        get
        {
            return this.uomField;
        }
        set
        {
            this.uomField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestCnstSh_offset_from_cl
{

    private string uomField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uom
    {
        get
        {
            return this.uomField;
        }
        set
        {
            this.uomField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestCnstTire_tdwr_ind
{

    private string uomField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uom
    {
        get
        {
            return this.uomField;
        }
        set
        {
            this.uomField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestCnstTire
{

    private string tire_activity_byteField;

    private string tire_at_test_siteField;

    private string tire_status_coField;

    private object tire_status_machineField;

    private byte step_set_numberField;

    private byte tire_test_pref_noField;

    private decimal rim_widthField;

    private string rim_flangeField;

    private string tire_dispositionField;

    private byte tire_groupField;

    private string tire_spare_flagField;

    private byte tire_sequenceField;

    /// <remarks/>
    public string tire_activity_byte
    {
        get
        {
            return this.tire_activity_byteField;
        }
        set
        {
            this.tire_activity_byteField = value;
        }
    }

    /// <remarks/>
    public string tire_at_test_site
    {
        get
        {
            return this.tire_at_test_siteField;
        }
        set
        {
            this.tire_at_test_siteField = value;
        }
    }

    /// <remarks/>
    public string tire_status_co
    {
        get
        {
            return this.tire_status_coField;
        }
        set
        {
            this.tire_status_coField = value;
        }
    }

    /// <remarks/>
    public object tire_status_machine
    {
        get
        {
            return this.tire_status_machineField;
        }
        set
        {
            this.tire_status_machineField = value;
        }
    }

    /// <remarks/>
    public byte step_set_number
    {
        get
        {
            return this.step_set_numberField;
        }
        set
        {
            this.step_set_numberField = value;
        }
    }

    /// <remarks/>
    public byte tire_test_pref_no
    {
        get
        {
            return this.tire_test_pref_noField;
        }
        set
        {
            this.tire_test_pref_noField = value;
        }
    }

    /// <remarks/>
    public decimal rim_width
    {
        get
        {
            return this.rim_widthField;
        }
        set
        {
            this.rim_widthField = value;
        }
    }

    /// <remarks/>
    public string rim_flange
    {
        get
        {
            return this.rim_flangeField;
        }
        set
        {
            this.rim_flangeField = value;
        }
    }

    /// <remarks/>
    public string tire_disposition
    {
        get
        {
            return this.tire_dispositionField;
        }
        set
        {
            this.tire_dispositionField = value;
        }
    }

    /// <remarks/>
    public byte tire_group
    {
        get
        {
            return this.tire_groupField;
        }
        set
        {
            this.tire_groupField = value;
        }
    }

    /// <remarks/>
    public string tire_spare_flag
    {
        get
        {
            return this.tire_spare_flagField;
        }
        set
        {
            this.tire_spare_flagField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte tire_sequence
    {
        get
        {
            return this.tire_sequenceField;
        }
        set
        {
            this.tire_sequenceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestStep_sets
{

    private l2l1testreqTestsTestStep_setsStep_set step_setField;

    /// <remarks/>
    public l2l1testreqTestsTestStep_setsStep_set step_set
    {
        get
        {
            return this.step_setField;
        }
        set
        {
            this.step_setField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestStep_setsStep_set
{

    private l2l1testreqTestsTestStep_setsStep_setSteps stepsField;

    private byte step_set_numberField;

    /// <remarks/>
    public l2l1testreqTestsTestStep_setsStep_setSteps steps
    {
        get
        {
            return this.stepsField;
        }
        set
        {
            this.stepsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte step_set_number
    {
        get
        {
            return this.step_set_numberField;
        }
        set
        {
            this.step_set_numberField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestStep_setsStep_setSteps
{

    private l2l1testreqTestsTestStep_setsStep_setStepsStep stepField;

    /// <remarks/>
    public l2l1testreqTestsTestStep_setsStep_setStepsStep step
    {
        get
        {
            return this.stepField;
        }
        set
        {
            this.stepField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestStep_setsStep_setStepsStep
{

    private string test_step_numberField;

    private l2l1testreqTestsTestStep_setsStep_setStepsStepCond[] condsField;

    private byte step_sequenceField;

    /// <remarks/>
    public string test_step_number
    {
        get
        {
            return this.test_step_numberField;
        }
        set
        {
            this.test_step_numberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("cond", IsNullable = false)]
    public l2l1testreqTestsTestStep_setsStep_setStepsStepCond[] conds
    {
        get
        {
            return this.condsField;
        }
        set
        {
            this.condsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte step_sequence
    {
        get
        {
            return this.step_sequenceField;
        }
        set
        {
            this.step_sequenceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class l2l1testreqTestsTestStep_setsStep_setStepsStepCond
{

    private string nameField;

    private byte seqField;

    private string uomField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte seq
    {
        get
        {
            return this.seqField;
        }
        set
        {
            this.seqField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uom
    {
        get
        {
            return this.uomField;
        }
        set
        {
            this.uomField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

