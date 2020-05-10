using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Domain.Commands;
using Domain.Entities;

namespace Application.Dtos
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "batchsheet")]
    //[Serializable, XmlRoot("batchsheet")]
    public partial class BatchsheetDto
    {

        private batchsheetWorder worderField;

        /// <remarks/>
        public batchsheetWorder worder
        {
            get
            {
                return this.worderField;
            }
            set
            {
                this.worderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorder
    {

        private string woidField;

        private string wonbrField;

        private string wopartField;

        private string wodescField;

        private string woarticleField;

        private List<string> mfgcmmtField;

        private List<string> bbcmmtField;

        private List<string> edcmmtField;

        private string qtyreqField;

        private List<string> packdateField;

        private string packsizeField;

        private string qcsampleField;

        private batchsheetWorderBulkitem bulkitemField;

        private batchsheetWorderPreprint preprintField;

        private List<batchsheetWorderPackdet> packagingField;

        private batchsheetWorderGroupa groupaField;

        private batchsheetWorderGroupb groupbField;

        private batchsheetWorderGroupc groupcField;

        private batchsheetWorderGroupd groupdField;

        private batchsheetWorderGroupe groupeField;

        private batchsheetWorderGroup100 group100Field;

        private batchsheetWorderGroup101 group101Field;

        private batchsheetWorderGroup170 group170Field;

        private batchsheetWorderGroup171 group171Field;

        private batchsheetWorderGroup161 group161Field;

        private string useremailField;

        private string prtdateField;

        /// <remarks/>
        public string woid
        {
            get
            {
                return this.woidField;
            }
            set
            {
                this.woidField = value;
            }
        }

        /// <remarks/>
        public string wonbr
        {
            get
            {
                return this.wonbrField;
            }
            set
            {
                this.wonbrField = value;
            }
        }

        /// <remarks/>
        public string wopart
        {
            get
            {
                return this.wopartField;
            }
            set
            {
                this.wopartField = value;
            }
        }

        /// <remarks/>
        public string wodesc
        {
            get
            {
                return this.wodescField;
            }
            set
            {
                this.wodescField = value;
            }
        }

        /// <remarks/>
        public string woarticle
        {
            get
            {
                return this.woarticleField;
            }
            set
            {
                this.woarticleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> mfgcmmt
        {
            get
            {
                return this.mfgcmmtField;
            }
            set
            {
                this.mfgcmmtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> bbcmmt
        {
            get
            {
                return this.bbcmmtField;
            }
            set
            {
                this.bbcmmtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> edcmmt
        {
            get
            {
                return this.edcmmtField;
            }
            set
            {
                this.edcmmtField = value;
            }
        }

        /// <remarks/>
        public string qtyreq
        {
            get
            {
                return this.qtyreqField;
            }
            set
            {
                this.qtyreqField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment")]
        public List<string> packdate
        {
            get
            {
                return this.packdateField;
            }
            set
            {
                this.packdateField = value;
            }
        }

        /// <remarks/>
        public string packsize
        {
            get
            {
                return this.packsizeField;
            }
            set
            {
                this.packsizeField = value;
            }
        }

        /// <remarks/>
        public string qcsample
        {
            get
            {
                return this.qcsampleField;
            }
            set
            {
                this.qcsampleField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderBulkitem bulkitem
        {
            get
            {
                return this.bulkitemField;
            }
            set
            {
                this.bulkitemField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderPreprint preprint
        {
            get
            {
                return this.preprintField;
            }
            set
            {
                this.preprintField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("packdet", IsNullable = false)]
        public List<batchsheetWorderPackdet> packaging
        {
            get
            {
                return this.packagingField;
            }
            set
            {
                this.packagingField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroupa groupa
        {
            get
            {
                return this.groupaField;
            }
            set
            {
                this.groupaField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroupb groupb
        {
            get
            {
                return this.groupbField;
            }
            set
            {
                this.groupbField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroupc groupc
        {
            get
            {
                return this.groupcField;
            }
            set
            {
                this.groupcField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroupd groupd
        {
            get
            {
                return this.groupdField;
            }
            set
            {
                this.groupdField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroupe groupe
        {
            get
            {
                return this.groupeField;
            }
            set
            {
                this.groupeField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroup100 group100
        {
            get
            {
                return this.group100Field;
            }
            set
            {
                this.group100Field = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroup101 group101
        {
            get
            {
                return this.group101Field;
            }
            set
            {
                this.group101Field = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroup170 group170
        {
            get
            {
                return this.group170Field;
            }
            set
            {
                this.group170Field = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroup171 group171
        {
            get
            {
                return this.group171Field;
            }
            set
            {
                this.group171Field = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroup161 group161
        {
            get
            {
                return this.group161Field;
            }
            set
            {
                this.group161Field = value;
            }
        }

        /// <remarks/>
        public string useremail
        {
            get
            {
                return this.useremailField;
            }
            set
            {
                this.useremailField = value;
            }
        }

        /// <remarks/>
        public string prtdate
        {
            get
            {
                return this.prtdateField;
            }
            set
            {
                this.prtdateField = value;
            }
        }
    }



    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderEdcmmt
    {

        private string commentField;

        /// <remarks/>
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderBulkitem
    {

        private batchsheetWorderBulkitemBulkdet bulkdetField;

        /// <remarks/>
        public batchsheetWorderBulkitemBulkdet bulkdet
        {
            get
            {
                return this.bulkdetField;
            }
            set
            {
                this.bulkdetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderBulkitemBulkdet
    {

        private string partField;

        private string descField;

        /// <remarks/>
        public string part
        {
            get
            {
                return this.partField;
            }
            set
            {
                this.partField = value;
            }
        }

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderPreprint
    {

        private batchsheetWorderPreprintPpdet ppdetField;

        /// <remarks/>
        public batchsheetWorderPreprintPpdet ppdet
        {
            get
            {
                return this.ppdetField;
            }
            set
            {
                this.ppdetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderPreprintPpdet
    {

        private string partField;

        private string descField;

        /// <remarks/>
        public string part
        {
            get
            {
                return this.partField;
            }
            set
            {
                this.partField = value;
            }
        }

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderPackdet
    {

        private string partField;

        private string descField;

        /// <remarks/>
        public string part
        {
            get
            {
                return this.partField;
            }
            set
            {
                this.partField = value;
            }
        }

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroupa
    {
        private List<groupAItem> groupAItemsField;

        public List<groupAItem> groupAItems
        {
            get
            {
                return this.groupAItemsField;
            }
            set
            {
                this.groupAItemsField = value;
            }
        }
        //private object[] itemsField;

        //private ItemsChoiceType[] itemsElementNameField;

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("grpacmt", typeof(batchsheetWorderGroupaGrpacmt))]
        //[System.Xml.Serialization.XmlElementAttribute("leftdesc", typeof(string))]
        //[System.Xml.Serialization.XmlElementAttribute("rightdesc", typeof(string))]
        //[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        //public object[] Items
        //{
        //    get
        //    {
        //        return this.itemsField;
        //    }
        //    set
        //    {
        //        this.itemsField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public ItemsChoiceType[] ItemsElementName
        //{
        //    get
        //    {
        //        return this.itemsElementNameField;
        //    }
        //    set
        //    {
        //        this.itemsElementNameField = value;
        //    }
        //}
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class groupAItem
    {

        private string leftdescField;
        private string rightdescField;

        private batchsheetWorderGroupaGrpacmt grpacmtField;

        /// <remarks/>
        public string leftdesc
        {
            get
            {
                return this.leftdescField;
            }
            set
            {
                this.leftdescField = value;
            }
        }
        public string rightdesc
        {
            get
            {
                return this.rightdescField;
            }
            set
            {
                this.rightdescField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroupaGrpacmt grpacmt
        {
            get
            {
                return this.grpacmtField;
            }
            set
            {
                this.grpacmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroupaGrpacmt
    {

        private string commentField;

        /// <remarks/>
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        grpacmt,

        /// <remarks/>
        leftdesc,

        /// <remarks/>
        rightdesc,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroupb
    {

        private List<string> grpbcmtField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> grpbcmt
        {
            get
            {
                return this.grpbcmtField;
            }
            set
            {
                this.grpbcmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroupd
    {

        private List<string> grpdcmtField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> grpdcmt
        {
            get
            {
                return this.grpdcmtField;
            }
            set
            {
                this.grpdcmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroupc
    {

        private List<string> grpccmtField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> grpccmt
        {
            get
            {
                return this.grpccmtField;
            }
            set
            {
                this.grpccmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroupe
    {

        private List<string> grpecmtField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> grpecmt
        {
            get
            {
                return this.grpecmtField;
            }
            set
            {
                this.grpecmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroup100
    {

        private string descField;

        private List<string> grp100cmtField;

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> grp100cmt
        {
            get
            {
                return this.grp100cmtField;
            }
            set
            {
                this.grp100cmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroup101
    {

        private string descField;

        private object grp101cmtField;

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }

        /// <remarks/>
        public object grp101cmt
        {
            get
            {
                return this.grp101cmtField;
            }
            set
            {
                this.grp101cmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroup170
    {

        private string descField;

        private batchsheetWorderGroup170Grp170cmt grp170cmtField;

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }

        /// <remarks/>
        public batchsheetWorderGroup170Grp170cmt grp170cmt
        {
            get
            {
                return this.grp170cmtField;
            }
            set
            {
                this.grp170cmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroup170Grp170cmt
    {

        private string commentField;

        /// <remarks/>
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroup171
    {

        private string descField;

        private object grp171cmtField;

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }

        /// <remarks/>
        public object grp171cmt
        {
            get
            {
                return this.grp171cmtField;
            }
            set
            {
                this.grp171cmtField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class batchsheetWorderGroup161
    {

        private string descField;

        private List<string> grp161cmtField;

        /// <remarks/>
        public string desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("comment", IsNullable = false)]
        public List<string> grp161cmt
        {
            get
            {
                return this.grp161cmtField;
            }
            set
            {
                this.grp161cmtField = value;
            }
        }
    }


    


}
