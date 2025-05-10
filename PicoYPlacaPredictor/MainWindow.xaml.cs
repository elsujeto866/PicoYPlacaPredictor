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
            var selectedDate = DatePicker.SelectedDate;
            var timeText = TimeTextBox.Text;

            if (!ValidateInputs(out var plate, out var dateValue, out var time))
                return;

            var vehicle = new Vehicle(licensePlate, selectedDate.Value, time);
            bool canCirculate = _validator.CanCirculate(vehicle);

            ResultTextBlock.Text = canCirculate
                ? "✅ Puede circular"
                : "🚫 No puede circular";
        }

        #region Validation Methods

        private void LicensePlateTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
            int originalCaretIndex = LicensePlateTextBox.SelectionStart;

            var raw = LicensePlateTextBox.Text.ToUpper().Replace("-", "").Trim();
            var letters = "";
            var digits = "";

            foreach (char c in raw)
            {
                if (letters.Length < 3 && char.IsLetter(c))
                {
                    letters += c;
                }
                else if (letters.Length == 3 && digits.Length < 4 && char.IsDigit(c))
                {
                    digits += c;
                }
            }

            
            if (raw.Length >= 3 && letters.Length < 3)
            {
                LicensePlateError.Text = "⚠️ Los 3 primeros deben ser letras.";
            }
            else if (digits.Length < 3)
            {
                LicensePlateError.Text = "⚠️ Los 3 primeros deben ser letras e ingrese entre 3 y 4 dígitos después del guion.";
            }
            else
            {
                LicensePlateError.Text = "";
            }

            string formatted = letters;
            if (letters.Length == 3)
                formatted += "-" + digits;

            
            if (LicensePlateTextBox.Text != formatted)
            {
                LicensePlateTextBox.Text = formatted;
                LicensePlateTextBox.SelectionStart = Math.Min(formatted.Length, formatted.Length); 
            }
        }

        private void ClearErrors()
        {
            LicensePlateError.Text = "";
            DateError.Text = "";
            TimeError.Text = "";
            ResultTextBlock.Text = "";
        }

        private bool ValidateInputs(out string licensePlate, out DateTime? date, out TimeSpan time)
        {
            ClearErrors();
            bool isValid = true;

            licensePlate = LicensePlateTextBox.Text;
            var selectedDate = DatePicker.SelectedDate;
            var timeText = TimeTextBox.Text;
            date = default;
            time = default;

            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                LicensePlateError.Text = "⚠️ Ingrese una placa. Ej: ABC-1234";
                isValid = false;
            }

            if (selectedDate == null)
            {
                DateError.Text = "⚠️ Seleccione una fecha.";
                isValid = false;
            }
            else
            {
                date = selectedDate.Value;
            }

            if (!TimeSpan.TryParse(timeText, out time))
            {
                TimeError.Text = "⚠️ Ingrese hora válida (HH:mm). Ej: 08:30";
                isValid = false;
            }

            return isValid;
        }

        #endregion
    }
}