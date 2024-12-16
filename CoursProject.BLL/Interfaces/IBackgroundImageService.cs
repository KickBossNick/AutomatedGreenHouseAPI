using CoursProject.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursProject.BLL.Interfaces
{
    public interface IBackgroundImageService
    {
        Task<ImageModel> GetBackgroundImageAsync(int id);
        Task UploadImageAsync(MemoryStream stream);
    }
}
