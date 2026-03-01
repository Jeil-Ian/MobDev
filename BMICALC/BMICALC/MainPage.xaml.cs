namespace BMICALC
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }






        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(heightEntry.Text) ||
                string.IsNullOrWhiteSpace(weightEntry.Text))
            {
                resultLabel.Text = "Please enter height and weight.";
                return;
            }

            if (!double.TryParse(heightEntry.Text, out double height) ||
                !double.TryParse(weightEntry.Text, out double weight))
            {
                resultLabel.Text = "Invalid number format.";
                return;
            }

            if (height <= 0 || weight <= 0)
            {
                resultLabel.Text = "Values must be greater than zero.";
                return;
            }

            double bmi = weight / (height * height);

            string category;

            if (bmi < 18.5)
                category = "Underweight";
            else if (bmi < 25)
                category = "Normal";
            else if (bmi < 30)
                category = "Overweight";
            else
                category = "Obese";

            resultLabel.Text = $"BMI: {bmi:F2} ({category})";
        }
    }
}
