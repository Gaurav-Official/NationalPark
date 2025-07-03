using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_NP.Models.ViewModels
{
    public class TrailVm
    {
        public Trail Trail { get; set; }
        public IEnumerable<SelectListItem> NationalParkList { get; set; }
    }
}
