using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HisPatch
{
    public class CExamPerson
    {
        [Browsable(false)]
        public Guid ID { get; set; }
        [Category("个人信息登记")]
        [DisplayName("登记时间"),ReadOnly(true)]
        public DateTime RegDate { get; set; }

        [Category("个人信息登记")]
        [DisplayName("登记序号"),ReadOnly(true)]
        public string Serail { get; set; }

        [Category("个人信息登记")]
        [DisplayName("身份证号码")]
        public string PSN { get; set; }

        [Category("个人信息登记")]
        [DisplayName("姓名")]
        public string Name { get; set; }
        [TypeConverter(typeof(SexConvert)),DisplayName("性别")]
        [Category("个人信息登记")]
        public string Sex { get; set; }
        [DisplayName("年龄")]
        [Category("个人信息登记")]
        public string Age { get; set; }
        [TypeConverter(typeof(NationsConvert)),DisplayName("民族")]
        [Category("个人信息登记")]
        public string Nation { get; set; }
        [TypeConverter(typeof(WorkTypeConvert)),DisplayName("工种")]
        [Category("个人信息登记")]
        public string WorkType { get; set; }
        [DisplayName("检查结论")]
        [Category("个人信息登记")]
        public string Conclusion { get; set; }
        [Browsable(false)]
        public Image Avatar { get; set; }
        [Browsable(false)]
        public bool IsLocked { get; set; }

        [DisplayName("合格证号"),ReadOnly(true)]
        public string SignNumber { get; set; }
        public CExamPerson()
        {
            RegDate = DateTime.Now;
            ID = Guid.NewGuid();
            IsLocked = false;
        }
    }
    public class SexConvert : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] {"男","女" });
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    public class NationsConvert : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "汉族", "回族","藏族","维吾尔族" });
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    public class WorkTypeConvert : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "食品药品生产经营", "化妆品生产", "公共场所服务", "饮用水供（管）水", "消毒产品生产", "水质处理器（材料）生产", "其他" });
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
