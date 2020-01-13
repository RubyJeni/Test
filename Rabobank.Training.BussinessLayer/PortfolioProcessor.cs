using System;
using System.Collections.Generic;
using Rabobank.Training.ClassLibrary;
using Rabobank.Training.ClassLibrary.Model;
using Rabobank.Training.ClassLibrary.ViewModel;
namespace Rabobank.Training.BussinessLayer
{
    public class PortfolioProcessor : IPortfolio
    {
        public PortfolioProcessor(IFund fundsProcessor)
        {
            FundsProcessor = fundsProcessor;
        }

        public IFund FundsProcessor { get; set; }

        public PortfolioVM GetUpdatedPortfolio(string fileName)
        {
            PortfolioVM portfolioVM = null;
            List<FundOfMandates> mandates = null;
            // IFundsProcessor fundProcessor = new FundProcessor(); //dependency injection is possible in these kind of cases

            portfolioVM = FundsProcessor.GetPortfolio();
            mandates = FundsProcessor.ReadFundOfMandatesFile(fileName);

            portfolioVM.Positions.ForEach(position =>
            {
                mandates.ForEach(fundofmandate =>
                {
                    position = FundsProcessor.GetCalculatedMandates(position, fundofmandate);
                });
            });

            return portfolioVM;
        }
    }
}