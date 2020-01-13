using System;
namespace Rabobank.Training.ClassLibrary.Model
{
    public class FundsOfMandatesData
    {
        private FundOfMandates[] fundsOfMandatesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("FundOfMandates", IsNullable = false)]
        public FundOfMandates[] FundsOfMandates
        {
            get
            {
                return this.fundsOfMandatesField;
            }
            set
            {
                this.fundsOfMandatesField = value;
            }
        }
    }
}
