namespace Tekus.Providers.Application.Features.Providers.Queries.GetProviders
{
    public class PaginatedList<T> where T : class
    {
  
        public int ActualPage { get; set; }
    
        public int RecordsPerPage { get; set; }
      
        public int TotalRecords { get; set; }
       
        public int TotalPages { get; set; }
 
        public string CurrentSearch { get; set; } = string.Empty;
       
        public string CurrentOrder { get; set; } = string.Empty;
     
        public string CurrentOrderType { get; set; } = string.Empty;

        public IEnumerable<T> Result { get; set; } = Enumerable.Empty<T>();
    }
}
