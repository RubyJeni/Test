using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Rabobank.Training.ClassLibrary;
using Rabobank.Training.ClassLibrary.ViewModel;

namespace Rabobank.Training.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolio portfolioProcessor = null;
        private readonly IConfiguration config;
        private readonly ILoggerFactory loggerFactory;

        public PortfolioController(IPortfolio processor, IConfiguration config, ILoggerFactory loggerfactory)
        {
            portfolioProcessor = processor;
            this.config = config;
            this.loggerFactory = loggerfactory;
        }
        [HttpGet]
        public PositionVM[] Get()
        {
            PositionVM[] positions = null;
            try
            {
                var fundsFilePath = config["FundsOfMandatesFile"];
                var portfolioViewModel = portfolioProcessor.GetUpdatedPortfolio(fundsFilePath);

                if (portfolioViewModel == null)
                {
                    throw new ArgumentException("Necessary Portfolio is not available to display");
                }
                if (portfolioViewModel.Positions == null || portfolioViewModel.Positions.Count == 0)
                {
                    throw new Exception("No Valid Positions found under portfolio.");
                }

                positions = portfolioViewModel.Positions.ToArray();
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger("Generic Logger");
                logger.LogError(e, "Error occered while retrieving Positions from Portfolio", null);
                throw e;
            }

            return positions;
        }
    }
}
