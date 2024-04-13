


using Infrastracture.Models;

namespace Infrastracure.Models;

public class CoursesResult
{

    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<Course>? Courses { get; set; }
}
