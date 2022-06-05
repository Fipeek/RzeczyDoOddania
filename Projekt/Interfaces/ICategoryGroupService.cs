using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Interfaces
{
    public interface ICategoryGroupService
    {
        ListCategoryGroupsForListVM GetListCategoryGroupForListVM();
        void addCategoryGroup(CategoryGroup categoryGroup);

    }
}
