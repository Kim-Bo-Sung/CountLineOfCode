using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySplash
{
    public partial class SplashScreenForm : Form
    {
        private static bool _showSplash;
        private static SplashScreenForm? _splashScreen;

        // SplashScreen 폼의 컴포넌트들을 초기화해주는 메소드.
        public SplashScreenForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        // SplashScreen 폼을 화면에 표시해주는 메소드.
        public static void SetSplashScreen(Form form)
        {
            _showSplash = true;
            _splashScreen = new SplashScreenForm();

            ResizeSplash(form);
            _splashScreen.Visible = true;
            _splashScreen.TopMost = true;

            System.Windows.Forms.Timer _timer = new();
            _timer.Tick += (sender, e) =>
            {
                _splashScreen.Visible = false;
                _timer.Enabled = false;
                _showSplash = false;
                form.Visible = true;
                form.ShowInTaskbar = true;
            };
            _timer.Interval = 2000;
            _timer.Enabled = true;
        }

        // SplashScreen 폼의 크기와 위치를 설정해주는 메소드.
        private static void ResizeSplash(Form form)
        {
            if (_showSplash)
            {
                if (_splashScreen != null)
                {
                    //_splashScreen.ClientSize = new Size((int)(form.Width * 1.02), (int)(form.Width * 0.75));
                    //_splashScreen.ClientSize = new Size(1100, 800);
                    var centerXMain = (form.Location.X + form.Width) / 2.0;
                    var LocationXSplash = Math.Max(0, centerXMain - (_splashScreen.Width / 2.0));

                    var centerYMain = (form.Location.Y + form.Height) / 2.0;
                    var LocationYSplash = Math.Max(0, centerYMain - (_splashScreen.Height / 2.0));

                    _splashScreen.Location = new Point((int)Math.Round(LocationXSplash), (int)Math.Round(LocationYSplash));
                }
            }
        }
    }
}
