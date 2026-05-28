using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RadioButtonSample
{

    public partial class MainPage : ContentPage
    {
        private PaymentModel _viewModel;
        public MainPage()
        {
            InitializeComponent();

            _viewModel = new PaymentModel
            {
                // ✅ This controls which radio is checked
                //SelectedOption = "DebitCard"
            };
            BindingContext = _viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _viewModel.SelectedOption = "DebitCard";
            popup.Show();
        }
    }


    public class PaymentModel : INotifyPropertyChanged
    {
        private string selectedOption;

        public string SelectedOption
        {
            get => selectedOption;
            set
            {
                if (selectedOption != value)
                {
                    selectedOption = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
