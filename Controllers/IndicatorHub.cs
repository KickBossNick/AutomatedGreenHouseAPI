using CoursProject.BLL.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace CourseProject_AutomatedGreenHouse.Controllers
{
    public class IndicatorHub : Hub
    {
        private readonly IIndicatorService indicatorService;

        public IndicatorHub(IIndicatorService service)
        {
            indicatorService = service;
        }

        public async Task SendValue(string id, string value)
        {
            await indicatorService.UpdateIndicatorValue(new()
            {
                Id = Guid.Parse(id),
                Value = value
            });

            await this.Clients.Others.SendAsync("receive", id, value);
        }
    }
}
