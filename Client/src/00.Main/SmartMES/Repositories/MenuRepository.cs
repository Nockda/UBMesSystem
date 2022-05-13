using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Micube.Framework;
using Micube.Framework.Net;

namespace SmartMES.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private DataTable _menuTable;
        private System.Windows.Forms.Form _mdiParent;

        public DataTable GetMenuTable()
        {
            return _menuTable;
        }

       
        public void InitMenu(System.Windows.Forms.Form mdiParent)
        {
            _menuTable = SqlExecuter.Query("GetMenuList", "00001");
            _mdiParent = mdiParent;
        }

        #region 메뉴 오픈

        public MenuInfo ToMenuInfo(string menuId)
        {
            //DataRow menuRow = _menuList[UserInfo.Current.Uiid].Select("MENUID = '" + menuId + "'").FirstOrDefault();
            DataRow menuRow = _menuTable.Select("MENUID = '" + menuId + "'").FirstOrDefault();
            if (menuRow == null)
            {
                throw MessageException.Create($"MENUID = {menuId}는 찾을수 없습니다");
                //MSGBox.Show(MessageBoxType.Error, "SmartEES", $"MENUID = {menuId}는 찾을 수 없습니다.");
                //return null;
            }

            MenuType menuType = MenuType.Folder;
            if (!Enum.TryParse(menuRow["MENUTYPE"].ToString(), true, out menuType)) menuType = MenuType.Folder;

            return new MenuInfo()
            {
                MenuId = menuRow["MENUID"].ToString(),
                MenuType = menuType,
                Caption = menuRow["MENUNAME"].ToString(),
                ProgramId = menuRow["PROGRAMID"].ToString()
            };

        }

   
        public void OpenMenu(string menuId, string parameterKey, object parameter)
        {
            this.OpenMenu(menuId, new Dictionary<string, object>() { { parameterKey, parameter } });
        }

        public void OpenMenu(string menuId, Dictionary<string, object> parameters)
        {
            this.OpenMenu(this.ToMenuInfo(menuId), parameters);
        }
        public void OpenMenu(string menuId, Dictionary<string, object> parameters, string serviceId, string parentMenuId)
        {
           // this.OpenMenu(this.ToMenuInfo(menuId), parameters, serviceId, parentMenuId);
        }

        public event OpenedMenuHandler OpenedMenuEvent;

        public void OpenMenu(MenuInfo menu, Dictionary<string, object> parameters)
        {
            //OpenMenu(menu, parameters, UserInfo.Current.Uiid);

            if (menu.MenuType != MenuType.Screen) throw new Exception("MenuType.Folder는 열수 없는 형식입니다.");

            OpenedMenuEvent?.Invoke(menu);

            var form = FormCreator.CreateForm(menu.MenuId, menu.Caption, menu.ProgramId, parameters);
            form.MdiParent = _mdiParent;
            form.Show();
        }

        #endregion

    }

    public delegate void OpenedMenuHandler(MenuInfo menu);
        

}
