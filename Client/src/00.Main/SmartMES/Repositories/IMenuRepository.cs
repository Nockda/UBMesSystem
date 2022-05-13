using System;
using System.Collections.Generic;
using System.Data;
using Micube.Framework.SmartControls.Interface;

namespace SmartMES.Repositories
{
    public interface IMenuRepository : IOpenMenu
    {
        void OpenMenu(MenuInfo menuId, Dictionary<string, object> parameters);

        void InitMenu(System.Windows.Forms.Form mdiParent);

        DataTable GetMenuTable();

        MenuInfo ToMenuInfo(string menuId);
    }
}
