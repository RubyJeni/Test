using System;
using Rabobank.Training.ClassLibrary.ViewModel;
namespace Rabobank.Training.ClassLibrary
{
    public interface IPortfolio
    {
        PortfolioVM GetUpdatedPortfolio(string fileName);
    }
}
