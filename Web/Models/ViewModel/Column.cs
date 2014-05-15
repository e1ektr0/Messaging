namespace Web.Models.ViewModel
{
    public class Column
    {
        public Column(string key, string displayName)
        {
            Key = key;
            Title = displayName;
        }

        public string Key { get; set; }
        public string Title { get; set; }
        public bool IsFiltered { get; set; }
    }
}