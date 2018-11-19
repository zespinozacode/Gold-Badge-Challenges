using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class CafeMenuRepository
    {
        List<Menu> _menuList = new List<Menu>();

        public void AddItemsToMenu(Menu content)
        {
            _menuList.Add(content);
        }

        public void RemoveItemsFromMenu(Menu content)
        {
            _menuList.Remove(content);
        }

        public List<Menu> GetMenus()
        {
            return _menuList;
        }
    }
}
