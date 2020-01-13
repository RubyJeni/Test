using System;
namespace Rabobank.Training.ClassLibrary.Model
{
    public class Mandate
    {
        private string mandateIdField;

        private string mandateNameField;

        private decimal allocationField;

        /// <remarks/>
        public string MandateId
        {
            get
            {
                return this.mandateIdField;
            }
            set
            {
                this.mandateIdField = value;
            }
        }

        /// <remarks/>
        public string MandateName
        {
            get
            {
                return this.mandateNameField;
            }
            set
            {
                this.mandateNameField = value;
            }
        }

        /// <remarks/>
        public decimal Allocation
        {
            get
            {
                return this.allocationField;
            }
            set
            {
                this.allocationField = value;
            }
        }
    }
}
