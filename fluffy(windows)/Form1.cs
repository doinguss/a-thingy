using System.ComponentModel;
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
        public Form1()
        {
            InitializeComponent();
            rand = new(DateTime.Now.Second);

            pictureBox1.Enabled = false;
            player = new SoundPlayer(@"fnaf-foxy-jumpscare.wav");
            
            timer = new();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(delegate (Object? o, EventArgs e) 
                { if (rand.Next(0, 10001) == 0) { foxxyevent(); } });
            
            subtimer = new();
            subtimer.Interval = 700; //exact length of gif
            subtimer.Tick += new EventHandler(delegate (Object? o, EventArgs e) 
                { pictureBox1.Hide();subtimer.Enabled = false; /*player.Stop()*/; pictureBox1.Enabled = false; });

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

    }
}
