using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace ProductivityTimer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer; //timer para el reloj
        private TimeSpan _time; // tiempo que se muestra en el reloj
        private bool _isRunning; //controla si el timer esta corriendo o no
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            _time = TimeSpan.FromMinutes(25);
            TimeDisplay.Text = _time.ToString(@"mm\:ss");

            _isRunning = false; //controla si el timer esta corriendo o no
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(_time.TotalSeconds> 0)
            {
                _time = _time.Add(TimeSpan.FromSeconds(-1)); //resta un segundo al tiempo
                TimeDisplay.Text = _time.ToString(@"mm\:ss");
            }
            else
            {
                _timer.Stop();
                _isRunning = false;
                MessageBox.Show("Temporizador acabado");

            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if(!_isRunning)
            {
                _timer.Start();
                _isRunning = true;
            }


        }
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if(!_isRunning)
            {
                _timer.Stop();
                _isRunning = false;
            }
            else
            {
                _timer.Start();
                _isRunning = true;
            }


        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _time = TimeSpan.FromMinutes(25);
            TimeDisplay.Text = _time.ToString(@"mm\:ss");
            _isRunning = false;
        }
    }
}
