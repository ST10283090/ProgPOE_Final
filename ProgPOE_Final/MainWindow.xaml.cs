using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProgPOE_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += new EventHandler(dt_Method);
            dt.Interval = TimeSpan.FromMilliseconds(30);
            dt.Start();
        }

        int loadingPerc = 0;

        private void dt_Method(object sender, EventArgs e)
        {
            loadingPerc += 1; 
            progressBar.Value = loadingPerc;

            if (loadingPerc >= 100)
            {
                dt.Stop(); 
                menu menuScreen = new menu();
                menuScreen.Show();
                this.Close(); 
            }
        }
    }
}