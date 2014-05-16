namespace Web.Models.ViewModel.Tables
{
    /// <summary>
    /// Объект пуйджинг
    /// </summary>
    public class Paging
    {
        private readonly int _pageSize;
        private const int WindowsSize = 5;

        /// <summary>
        /// Расчитывает с какой страницы показывать и общее колличество страниц
        /// </summary>
        public Paging(int totalCount, int pageSize, int skip)
        {
            _pageSize = pageSize;
            var totalPagesDouble = (double)totalCount / pageSize;
            var totalPage = (int)totalPagesDouble;
            if (totalPagesDouble - (int)totalPagesDouble > 0)
            {
                totalPage += 1;
            }
            CurrentPage = skip / pageSize;
            TotalPages = totalPage;

            //Расчитываем с какого по какой номер необходимо показывать(в рамках окна)
            if (CurrentPage > WindowsSize)
                Start = CurrentPage - WindowsSize / 2;
            else
                Start = 0;
            if (totalPage - CurrentPage - 1 > WindowsSize)
                End = CurrentPage + WindowsSize / 2;
            else
                End = totalPage - 1;
        }

        /// <summary>
        /// Общее колличесво страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Страница с которой показывать пейджинг
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Страница до которой показывать пейджинг
        /// </summary>
        public int End { get; set; }

        /// <summary>
        /// Текущая отображаемая страница
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Конвертирует номер страницы в колличесво объектов которые необходимо пропустить
        /// </summary>
        public int SkipConvert(int page)
        {
            return page * _pageSize;
        }
    }
}