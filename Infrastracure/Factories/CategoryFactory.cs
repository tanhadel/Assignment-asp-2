using Infrastracture.Entities;
using Infrastracture.Models;


namespace Infrastracture.Factories;

public class CategoryFactory
{

    public static CategoryEnitity Create(CategoryRegistrationFrom form)
    {

        try
        {
            return new CategoryEnitity
            {
                CategoryName = form.CategoryName,
            };

        }
        catch (Exception ex) { }
        return null!;
    }




    public static Category Create(CategoryEnitity  entity)
    {

        try
        {
            return new Category

            {

                Id = entity.Id,
                CategoryName = entity.CategoryName,
            };

        }
        catch (Exception ex) { }
        return null!;
    }

    public static IEnumerable <Category> Create(List<CategoryEnitity> entities)
    {

        var categories = new List<Category>();
        try
        {
         

              foreach (var enitity in entities) 
                categories.Add(Create(enitity));
           

        }
        catch (Exception ex) { }
        return categories;
    }
}
