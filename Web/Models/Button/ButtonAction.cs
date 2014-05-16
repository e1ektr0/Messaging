using Web.Controllers.Admin;

namespace Web.Models
{
    public class ButtonAction
    {
        public string Title { get; set; }
        public string Action { get; set; }
        public ButtonTypes? Type { get; set; }
    }
}