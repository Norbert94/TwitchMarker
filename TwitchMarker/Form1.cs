using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Timers;
using System.ServiceProcess;
using System.Data.Common;
using System.Diagnostics;
using System.IO;

namespace TwitchMarker
{
    public partial class Form1 : Form
    {
        private KeyHandler ghk;
        public bool cancelled = false;
        public string savedChannel;
        public Keys savedHotkey;
        private Stopwatch timer = new Stopwatch();
        UserInfo info;

        public Form1()
        {

            InitializeComponent();
            this.ShowInTaskbar = false;

            if (TwitchMarker.Properties.Settings.Default.hotkey != Keys.None)
            {
                //ghk = new KeyHandler(TwitchMarker.Properties.Settings.Default.hotkey, this);
                savedHotkey = TwitchMarker.Properties.Settings.Default.hotkey;
                setKey(TwitchMarker.Properties.Settings.Default.hotkey);
                ghk.Register();
            }
            else
            {
                ghk = new KeyHandler(Keys.F11, this);
                txt_hotkey.Text = "F11";
                ghk.Register();
            }
            if (TwitchMarker.Properties.Settings.Default.channel != "")
            {
                txt_Name.Text = TwitchMarker.Properties.Settings.Default.channel;
                savedChannel = txt_Name.Text;
                newThread();
            }
        }

        private void HandleHotkey()
        {
            if (info != null)
            {
                if (info.game != null)
                {
                    var time = TimeSpan.FromMilliseconds(timer.ElapsedMilliseconds);
                    string[] lines = { info.game.ToString(), info.title.ToString(), time.ToString(), DateTime.Now.ToString("M/d/yyyy"), "\n" };

                    File.AppendAllLines("highlights.txt", lines);
                }
                else
                {
                    MessageBox.Show("Stream is offline");
                }
            }
            else
            {
                MessageBox.Show("Please setup the stream. Go to the settings page.");
            }
        }

        public void Cancel()
        {
            cancelled = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ghk.Register();
            newThread();

            savedChannel = txt_Name.Text;
            savedHotkey = TwitchMarker.Properties.Settings.Default.hotkey;
            TwitchMarker.Properties.Settings.Default.channel = txt_Name.Text;
            TwitchMarker.Properties.Settings.Default.Save();
        }

        private void newThread()
        {
            new Thread(delegate()
            {
                while (!cancelled)
                {
                    try
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            if (txt_Name.Text != "")
                            {
                                var json = webClient.DownloadString("https://api.twitch.tv/kraken/streams/" + txt_Name.Text);
                                // Now parse with JSON.Net
                                info = new UserInfo(json);
                            }
                        }

                        if (info.streamLive() && !timer.IsRunning)
                        {
                            timer.Start();
                        }

                        if (!info.streamLive())
                        {
                            timer.Stop();
                        }
                    }

                    catch (System.Net.WebException ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }

                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }

                    Thread.Sleep(1000);
                }
            }).Start();
            this.Location = new Point(this.Location.X, this.Location.Y - 5000);
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (txt_hotkey.Text == "F11")
            {
                ghk = new KeyHandler(Keys.F11, this);
                txt_hotkey.Text = "F11";
                ghk.Register();
            }

            txt_Name.Text = savedChannel;
            setKey(savedHotkey);

            this.Location = new Point(this.Location.X, this.Location.Y - 5000);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            setKey(e.KeyData);
        }

        private void setKey(Keys e)
        {
            switch (e)
            {
                case Keys.F1:
                    ghk = new KeyHandler(Keys.F1, this);
                    txt_hotkey.Text = "F1";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F1;
                    break;
                case Keys.F2:
                    ghk = new KeyHandler(Keys.F2, this);
                    txt_hotkey.Text = "F2";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F2;
                    break;
                case Keys.F3:
                    ghk = new KeyHandler(Keys.F3, this);
                    txt_hotkey.Text = "F3";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F3;
                    break;
                case Keys.F4:
                    ghk = new KeyHandler(Keys.F4, this);
                    txt_hotkey.Text = "F4";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F4;
                    break;
                case Keys.F5:
                    ghk = new KeyHandler(Keys.F5, this);
                    txt_hotkey.Text = "F5";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F5;
                    break;
                case Keys.F6:
                    ghk = new KeyHandler(Keys.F6, this);
                    txt_hotkey.Text = "F6";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F6;
                    break;
                case Keys.F7:
                    ghk = new KeyHandler(Keys.F7, this);
                    txt_hotkey.Text = "F7";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F7;
                    break;
                case Keys.F8:
                    ghk = new KeyHandler(Keys.F8, this);
                    txt_hotkey.Text = "F8";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F8;
                    break;
                case Keys.F9:
                    ghk = new KeyHandler(Keys.F9, this);
                    txt_hotkey.Text = "F9";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F9;
                    break;
                case Keys.F10:
                    ghk = new KeyHandler(Keys.F10, this);
                    txt_hotkey.Text = "F10";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F10;
                    break;
                case Keys.F11:
                    ghk = new KeyHandler(Keys.F11, this);
                    txt_hotkey.Text = "F11";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F11;
                    break;
                case Keys.F12:
                    ghk = new KeyHandler(Keys.F12, this);
                    txt_hotkey.Text = "F12";
                    TwitchMarker.Properties.Settings.Default.hotkey = Keys.F12;
                    break;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            ghk.Unregiser();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TwitchMarker.Properties.Settings.Default.channel = txt_Name.Text;
            TwitchMarker.Properties.Settings.Default.Save();
        }
    }
}