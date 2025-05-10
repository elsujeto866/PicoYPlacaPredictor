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
        #region Botones
        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            var licensePlate = LicensePlateTextBox.Text;
            var selectedDate = DatePicker.SelectedDate;
            var timeText = TimeTextBox.Text;

            if (!ValidateInputs(out var plate, out var dateValue, out var time))
                return;

            var vehicle = new Vehicle(licensePlate, selectedDate.Value, time);
            bool canCirculate = _validator.CanCirculate(vehicle);

            ResultTextBlock.Foreground = canCirculate
                ? new SolidColorBrush(Color.FromRgb(57, 255, 20)) 
                : new SolidColorBrush(Color.FromRgb(255, 0, 0));


            ResultTextBlock.Text = canCirculate
                ? "✅ Can Circulate"
                : "🚫 Can't Circulate";

            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        #region Validation Methods
        /// <summary>
        /// Clears all input fields, error messages, and result display.
        /// </summary>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFiels();
        }

        private void ClearFiels()
        {
            LicensePlateTextBox.Text = "";
            DatePicker.SelectedDate = null;
            TimeTextBox.Text = "";

            LicensePlateError.Text = "";
            DateError.Text = "";
            TimeError.Text = "";
            ResultTextBlock.Text = "";
        }

        private void TimeTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string raw = new string(TimeTextBox.Text.Where(char.IsDigit).ToArray());

            if (raw.Length > 4)
                raw = raw.Substring(0, 4);

            string formatted = raw;

            if (raw.Length >= 2)
            {
                formatted = raw.Insert(2, ":");
            }

           
            if (TimeTextBox.Text != formatted)
            {
                int cursor = TimeTextBox.SelectionStart;
                TimeTextBox.Text = formatted;
                TimeTextBox.SelectionStart = Math.Min(formatted.Length, cursor + 1);
            }

          
            if (formatted.Length == 5 && TimeSpan.TryParse(formatted, out _))
            {
                TimeError.Text = ""; 
            }
            else
            {
                TimeError.Text = "⚠️ Enter valid time in HH:mm format.";
            }
        }

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
                LicensePlateError.Text = "⚠️ The first 3 must be letters.";
            }
            else if (digits.Length < 3)
            {
                LicensePlateError.Text = "⚠️ The first 3 must be letters and enter 3-4 digits after the hyphen.";
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