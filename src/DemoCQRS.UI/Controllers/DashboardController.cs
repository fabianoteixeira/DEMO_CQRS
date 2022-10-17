using DemoCQRS.Application.Contracts;
using DemoCQRS.Application.Contracts.Write;
using DemoCQRS.UI.Helpers;
using DemoCQRS.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoCQRS.UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IPersonReadRepository _personReadRepository;
        private readonly IPersonWriteRepository _personWriteRepository;

        public DashboardController(IPersonReadRepository personReadRepository, IPersonWriteRepository personWriteRepository)
        {
            _personReadRepository = personReadRepository;
            _personWriteRepository = personWriteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardViewModel = new DashboardViewModel();

            var stopwathSqlServer = new StopWathHelper();
            stopwathSqlServer.Start();
            await _personReadRepository.ListAsync();
            dashboardViewModel.MongoDbTimer = stopwathSqlServer.StopeResult();


            var stopWatchMongo = new StopWathHelper();
            stopWatchMongo.Start();
            await _personWriteRepository.ListAsync();
            dashboardViewModel.SqlServerTimer = stopWatchMongo.StopeResult();

            return View(dashboardViewModel);
        }
    }
}
