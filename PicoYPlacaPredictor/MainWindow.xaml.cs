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

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            var licensePlate = LicensePlateTextBox.Text;
            var date = DatePicker.SelectedDate; 
            var timeText = TimeTextBox.Text;

            if (string.IsNullOrWhiteSpace(licensePlate) || string.IsNullOrWhiteSpace(timeText))
            {
                ResultTextBlock.Text = "⚠️ Por favor ingresa la placa y la hora.";
                return;
            }

            if (!TimeSpan.TryParse(timeText, out var time))
            {
                ResultTextBlock.Text = "⚠️ Formato de hora inválido. Usa HH:mm (ej: 08:30)";
                return;
            }

            var vehicle = new Vehicle(licensePlate, date.Value, time);
            bool canCirculate = _validator.CanCirculate(vehicle);

            ResultTextBlock.Text = canCirculate
                ? "✅ Puede circular"
                : "🚫 No puede circular";
        }
    }
}