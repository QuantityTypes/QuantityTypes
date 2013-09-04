namespace WpfExample
{
    using System;
    using System.Threading;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Console.WriteLine("CurrentUICulture: "+Thread.CurrentThread.CurrentUICulture);
            Console.WriteLine("CurrentCulture: " + Thread.CurrentThread.CurrentCulture);
            Console.WriteLine(0.13.ToString());
            InitializeComponent();

            DataContext = new ViewModel();
        }
    }
}
