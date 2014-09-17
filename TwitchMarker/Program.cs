using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TwitchMarker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyCustomApplicationContext());
        }

        public class MyCustomApplicationContext : ApplicationContext
        {
            Form1 settings = new Form1();
            private NotifyIcon trayIcon = new NotifyIcon();

            public MyCustomApplicationContext()
            {
                // Initialize Tray Icon
                MenuItem Settings = new MenuItem("Settings", new EventHandler(ShowSettings));
                MenuItem ExitMenu = new MenuItem("Exit", new EventHandler(Exit));

                trayIcon.Icon = TwitchMarker.Properties.Resources.TMIcon;
                trayIcon.ContextMenu = new ContextMenu(new MenuItem[] { Settings, ExitMenu });
                trayIcon.Visible = true;
            }

            void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Icon = null;
                trayIcon.Visible = false;

                Application.Exit();
            }

            void ShowSettings(object sender, EventArgs e)
            {

                if (settings.Visible)
                {
                    settings.Focus();
                    settings.Location = new Point(Screen.PrimaryScreen.Bounds.Bottom/16, Screen.PrimaryScreen.Bounds.Right/16);
                }
                else
                    settings.ShowDialog();
            }
        }
    }
}