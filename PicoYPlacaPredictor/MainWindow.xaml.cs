using PicoYPlacaPredictor.Business.Validators;
using PicoYPlacaPredictor.Entities;
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

namespace PicoYPlacaPredictor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CompositeCirculationValidator _validator;

        public MainWindow()
        {
            InitializeComponent();
            _validator = new CompositeCirculationValidator(); 
        }

        
    }
}