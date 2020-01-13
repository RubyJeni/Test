using System;
namespace Rabobank.Training.ClassLibrary.Model
{
    public class FundOfMandates
    {
        private string instrumentCodeField;

        private string instrumentNameField;

        private decimal liquidityAllocationField;

        private Mandate[] mandatesField;

        /// <remarks/>
        public string InstrumentCode
        {
            get
            {
                return this.instrumentCodeField;
            }
            set
            {
                this.instrumentCodeField = value;
            }
        }

        /// <remarks/>
        public string InstrumentName
        {
            get
            {
                return this.instrumentNameField;
            }
            set
            {
                this.instrumentNameField = value;
            }
        }

        /// <remarks/>
        public decimal LiquidityAllocation
        {
            get
            {
                return this.liquidityAllocationField;
            }
            set
            {
                this.liquidityAllocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Mandate", IsNullable = false)]
        public Mandate[] Mandates
        {
            get
            {
                return this.mandatesField;
            }
            set
            {
                this.mandatesField = value;
            }
        }
    }
}
