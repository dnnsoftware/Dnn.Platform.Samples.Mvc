using System.Linq;
using DotNetNuke.Collections;

namespace Dnn.Modules.SPA_Module_React.Components
{
    public interface IItemRepository
    {

        int AddItem(Item t);

        void DeleteItem(int itemId, int moduleId);

        void DeleteItem(Item t);

        Item GetItem(int itemId, int moduleId);

        IQueryable<Item> GetItems(int moduleId);

        IPagedList<Item> GetItems(string searchTerm, int moduleId, int pageIndex, int pageSize);

        void UpdateItem(Item t);
    }
}