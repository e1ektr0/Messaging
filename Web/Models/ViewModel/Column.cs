namespace Web.Models.ViewModel
{
    public class Column
    {
        public Column(string displayName)
        {
            Title = displayName;
        }

        public string Title { get; set; }
    }
}