using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Rabobank.Training.ClassLibrary;
using Rabobank.Training.ClassLibrary.Model;
using Rabobank.Training.ClassLibrary.ViewModel;

namespace Rabobank.Training.BussinessLayer
{
    public class FundProcessor : IFund
    {
        public PositionVM GetCalculatedMandates(PositionVM position, FundOfMandates fundOfmandates)
        {
            if (position.Code == fundOfmandates.InstrumentCode && fundOfmandates.Mandates != null && fundOfmandates.Mandates.Length > 0)
            {
                position.Mandates = new List<MandateVM>();
                position.Mandates.AddRange
                 (
                            fundOfmandates.Mandates.ToList().Select(x => new MandateVM
                            {
                                name = x.MandateName,
                                Value = Math.Round((position.Value ) / 100),
                                Allocation = x.Allocation / 100
                            })
                 );

                if (fundOfmandates.LiquidityAllocation > 0)
                {
                    var newMandate = new MandateVM
                    {
                        name = "Liquidity",
                        Value = Math.Round((position.Value ) / 100),
                        Allocation = fundOfmandates.LiquidityAllocation / 100
                    };

                    position.Mandates.Add(newMandate);
                }
            }
           

            return position;

        }

       
        public PortfolioVM GetPortfolio()
        {
            PortfolioVM portfolio = null;
            try
            {
                portfolio = new PortfolioVM
                {
                    Positions = new List<PositionVM> {

                     new PositionVM { Code="NL0000287100", Name="Henekens", Value=12345 },
                     new PositionVM { Code="NL000029332", Name="Optimix", Value=23456 },
                     new PositionVM { Code="NL0000440584", Name="DP Global", Value=34567 },
                     new PositionVM { Code="NL0000440588", Name="Rabobank core", Value=45678 },
                     new PositionVM { Code="inc005", Name="Morgan Stanley", Value=56789 }
                    }
                };

            }
            catch (Exception e)
            {
               
                throw e;
            }

            return portfolio;
        }

       
        
        public List<FundOfMandates> ReadFundOfMandatesFile(string fileName)
        {
            try
            {
                List<FundOfMandates> funds = null;
                StreamReader reader = null;
                FundsOfMandatesData fundsOfMandatesData = null;
                XmlSerializer serealizer = new XmlSerializer(typeof(FundsOfMandatesData));

                using (reader = new StreamReader(fileName))
                {
                    fundsOfMandatesData = (FundsOfMandatesData)serealizer.Deserialize(reader);
                }

              

                if (fundsOfMandatesData == null)
                {
                    //Log error
                    throw new Exception("UnExpected Error. Please check that file contains data correctly.");

                }
                else if (fundsOfMandatesData != null && fundsOfMandatesData.FundsOfMandates.Length == 0)
                {
                    //Log error
                    throw new Exception("Unable to Read blank FundOfMandatesFile. Please check the file.");
                }
                else
                {
                    funds = fundsOfMandatesData.FundsOfMandates.ToList();
                }

                return funds;
            }
            catch (InvalidOperationException inv)
            {
                //Log err
                throw inv;
            }
        }

     
    }
}
