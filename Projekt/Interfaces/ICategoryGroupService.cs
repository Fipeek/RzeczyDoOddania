using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Interfaces
{
    public interface ICategoryGroupService
    {
        ListCategoryGroupsForListVM GetListCategoryGroupForListVM();
        void addCategoryGroup(CategoryGroup categoryGroup);
        ListCategoryGroupsForListVM GetCategoryGroupsByCategoryId(int id);
        ListCategoryGroupsForListVM GetCategoryGroupsByLocation(string location);
        ListCategoryGroupsForListVM GetCategoryGroupsByName(string name);
    }
}
