using System;
using System.Collections.Generic;
using Rabobank.Training.ClassLibrary.ViewModel;
using Rabobank.Training.ClassLibrary.Model;
namespace Rabobank.Training.ClassLibrary
{
    public interface IFund
    {
        List<FundOfMandates> ReadFundOfMandatesFile(string fileName);
        PortfolioVM GetPortfolio();
        PositionVM GetCalculatedMandates(PositionVM position, FundOfMandates fundOfmandates);
    }
}
