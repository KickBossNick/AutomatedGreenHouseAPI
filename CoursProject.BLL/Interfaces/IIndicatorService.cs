using CoursProject.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursProject.BLL.Interfaces
{
    public interface IIndicatorService
    {
        Task<Guid> CreateIndicator(IndicatorModel model);
        Task<List<IndicatorModel>> GetIndicators();
        Task DeleteIndicator(Guid id);
        Task UpdateIndicatorValue(UpdateIndicatorValueModel model);
    }
}
