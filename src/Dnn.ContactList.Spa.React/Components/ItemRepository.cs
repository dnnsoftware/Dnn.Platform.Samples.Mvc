using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Collections;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;

namespace Dnn.Modules.SPA_Module_React.Components
{
    public class ItemRepository : ServiceLocator<IItemRepository, ItemRepository>, IItemRepository
    {

        protected override Func<IItemRepository> GetFactory()
        {
            return () => new ItemRepository();
        }

        public int AddItem(Item t)
        {
            Requires.NotNull(t);
            Requires.PropertyNotNegative(t, "ModuleId");

            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Insert(t);
            }
            return t.ItemId;
        }

        public void DeleteItem(Item t)
        {
            Requires.NotNull(t);
            Requires.PropertyNotNegative(t, "ItemId");

            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Delete(t);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            Requires.NotNegative("itemId", itemId);
            Requires.NotNegative("moduleId", moduleId);

            var t = GetItem(itemId, moduleId);
            DeleteItem(t);
        }

        public Item GetItem(int itemId, int moduleId)
        {
            Requires.NotNegative("itemId", itemId);
            Requires.NotNegative("moduleId", moduleId);

            Item t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                t = rep.GetById(itemId, moduleId);
            }
            return t;
        }

        public IQueryable<Item> GetItems(int moduleId)
        {
            Requires.NotNegative("moduleId", moduleId);

            IQueryable<Item> t = null;

            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();

                t = rep.Get(moduleId).AsQueryable();
            }

            return t;
        }

        public IPagedList<Item> GetItems(string searchTerm, int moduleId, int pageIndex, int pageSize)
        {
            Requires.NotNegative("moduleId", moduleId);

            var t = GetItems(moduleId).Where(c => c.ItemName.Contains(searchTerm)
                                                || c.ItemDescription.Contains(searchTerm));


            return new PagedList<Item>(t, pageIndex, pageSize);
        }

        public void UpdateItem(Item t)
        {
            Requires.NotNull(t);
            Requires.PropertyNotNegative(t, "ItemId");

            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Update(t);
            }
        }
    }
}