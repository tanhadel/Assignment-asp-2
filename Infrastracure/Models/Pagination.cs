

namespace Infrastracure.Models;

public class Pagination
{
     public int CurrentPage { get; set; }
    public int Totalepages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public void UpdateTotalPage()
    {
        Totalepages = (int)Math.Ceiling((double)TotalCount / Totalepages);
    }





}
