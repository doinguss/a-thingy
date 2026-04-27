using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Timers;
using fluffy_windows_.Properties;

namespace fluffy_windows_
{
    public partial class Form1 : Form
    {
        private static Random rand;
        private static System.Windows.Forms.Timer timer;
        private static System.Windows.Forms.Timer subtimer;
        private static SoundPlayer player;
        private byte fox = 0;
        public Form1()
        {
            InitializeComponent();
            rand = new(DateTime.Now.Second);

            pictureBox1.Enabled = false;
            player = new SoundPlayer(@"fnaf-foxy-jumpscare.wav");
            
            timer = new();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(delegate (Object? o, EventArgs e) 
                { if (rand.Next(0, 1001) == 0) { foxxyevent(); } });
            
            subtimer = new();
            subtimer.Interval = 700; //exact length of gif
            subtimer.Tick += new EventHandler(delegate (Object? o, EventArgs e) 
                { pictureBox1.Hide();subtimer.Enabled = false; /**/player.Stop()/**/; pictureBox1.Enabled = false; });

            this.TopMost = true;

            //SetWindowPos(this.Handle, TopMost? new IntPtr(-1):new IntPtr(-2),0,0,0,0,(uint)0x0002|(uint)0x0001|(uint)0x0040);//straight up werid and unknowable

        }
        //[DllImport("user32.dll",SetLastError =true)]
        //private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,int x,int y,int cx, int cy,uint uflags);//evil fucked up magic



        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            player.Load();
            timer.Enabled = true;
        }
        private void foxxyevent()
        {
            player.Play();
            pictureBox1.Enabled = true;
            pictureBox1.Show();
            subtimer.Start();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData,fox)
            {
                case (Keys.F, 0):
                case (Keys.O, 1):
                case (Keys.X, 2):
                case (Keys.Y, 3):
                case (Keys.F | Keys.Shift, 0):
                case (Keys.O | Keys.Shift, 1):
                case (Keys.X | Keys.Shift, 2):
                case (Keys.Y | Keys.Shift, 3): 
                case (Keys.A, 5):
                case (Keys.P, 6):
                case (Keys.P, 7): 
                case (Keys.I, 8):
                case (Keys.E, 9):
                case (Keys.S, 10):
                case (Keys.T, 11):
                case (Keys.D, 12):
                case (Keys.A, 13):
                case (Keys.Y, 14):
                case (Keys.A|Keys.Shift, 5):
                case (Keys.P|Keys.Shift, 6):
                case (Keys.P|Keys.Shift, 7):
                case (Keys.I|Keys.Shift, 8):
                case (Keys.E|Keys.Shift, 9):
                case (Keys.S|Keys.Shift, 10):
                case (Keys.T|Keys.Shift, 11):
                case (Keys.D|Keys.Shift, 12):
                case (Keys.A|Keys.Shift, 13):
                case (Keys.Y|Keys.Shift, 14): 
                case (Keys.F | Keys.Control, 0):
                case (Keys.O | Keys.Control, 1):
                case (Keys.X | Keys.Control, 2):
                case (Keys.Y | Keys.Control, 3): fox++; break;

                case (Keys.Space, 0):
                case (Keys.Space, 1):
                case (Keys.Space, 2):
                case (Keys.Space, 3):
                case (Keys.Enter, 0):
                case (Keys.Enter, 1):
                case (Keys.Enter, 2):
                case (Keys.Enter, 3):
                case (Keys.Tab, 0):
                case (Keys.Tab, 1):
                case (Keys.Tab, 2):
                case (Keys.Tab, 3): break;

                case (Keys.H, 0):
                case (Keys.H|Keys.Shift, 0): fox = 5; break;

                default: fox = 0; break;
            }
            if (fox == 4) { fox = 0; foxxyevent(); }
            if (fox == 15) { this.Close(); }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
