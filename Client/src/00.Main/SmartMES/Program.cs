using System;
using System.Configuration;
using System.Windows.Forms;
using Ninject;
using DevExpress.XtraEditors;
using Micube.Framework.Log;

namespace SmartMES
{
    class Program : Micube.Framework.Modules.NinjectProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// MenuId=CodeClassManagement&ProgramId=Micube.SmartEES.SystemManagement.CodeClassManagement&Caption=코드그룹관리
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Kernel = new StandardKernel();
            Kernel.Load(new Modules.InjectModule());
            Kernel.Load(new Micube.Framework.SmartControls.Modules.InjectModule());
            //Kernel.Load(new Micube.SmartEES.Fdc.Modules.InjectModule());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Mangul Gothic", 10F);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            //DialogManager.ShowStartSplashScreen();


            //MainForm mainForm = new MainForm();
            //Form mainForm = Kernel.Get<Micube.Framework.SmartControls.Interface.IOpenMenu>() as Form;
            LoginForm loginForm = new LoginForm();
#if DEBUG
            loginForm.CallMenu = GetFirstFormName();
#endif

            Application.Run(loginForm);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            Micube.Framework.SmartControls.Helpers.UIHelper.ShowError(e.ExceptionObject as Exception);
            Logger.Error((e.ExceptionObject as Exception).Message);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Micube.Framework.SmartControls.Helpers.UIHelper.ShowError(e.Exception);
            Logger.Error(e.Exception.Message);
        }

#if DEBUG

        static MenuInfo GetFirstFormName()
        {
            string startUp = ConfigurationManager.AppSettings["StartUp"];
            MenuInfo result = null;

            if (string.IsNullOrEmpty(startUp))
                return result;

             //var commandLines = Micube.Framework.SmartControls.Helpers.StringHelper.GetParameter(startUp);
            var commandLines = Helpers.DebugHelper.GetParameter(startUp);
            if (commandLines != null)
            {
                //MenuId=CodeClassManagement;ProgramId=Micube.SmartEES.SystemManagement.CodeClassManagement;Caption=코드그룹관리
                if (commandLines.ContainsKey("MenuId") && commandLines.ContainsKey("ProgramId"))
                {
                    result = new MenuInfo();
                    result.MenuId = commandLines["MenuId"];
                    result.ProgramId = commandLines["ProgramId"];
                    if (commandLines.ContainsKey("Caption")) result.Caption = commandLines["Caption"];
                }
            }

            return result;
        }

#endif
    }
}
