using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Interfaces
{
    public interface ICategoryGroupService
    {
        ListCategoryGroupsForListVM GetListCategoryGroupForListVM();
        void addCategoryGroup(CategoryGroup categoryGroup);
        public ListOfferForListVM GetCategoryGroupsByCategoryId(int id);
        ListCategoryGroupsForListVM GetCategoryGroupsByLocation(string location);
        ListCategoryGroupsForListVM GetCategoryGroupsByName(string name);
        public List<Category> GetCategoryGroupsByOfferId(int id);
    }
}
