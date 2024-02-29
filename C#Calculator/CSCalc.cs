namespace C_Calculator
{
    public partial class CalculatorForm : Form
    {

        #region Variables

        //store the operations in a string list
        string[] _operatorList = new string[] { "+", "-", "*", "/" };

        //reservednumber1 is before the operator is entered, 2 will be set after =        
        double? _reservedNumber1 = null, _reservedNumber2 = null;

        //i need to konw which operator has been selected

        string _operator = null;

        //the label updates with the value but the previous value remains in the text box, we need the text box to clear after the =

        bool _clearTextBox = false;

        #endregion


        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //all buttons will be handled here
        {
            var text = ((Button)sender).Text;

            txtInput.Text += text;

            //if the button is an operator we need to store the first value

            var isOperator = _operatorList.Any(p => p == text);
            if(isOperator)
            {
                if(double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber1 = temp;
                    txtInput.Clear();
                    lblResult.Text = $"{_reservedNumber1} {text}";
                    _operator = text;
                }
            }else 
            if(text == "=")
            {
                if(double.TryParse(txtInput.Text, out double temp))
                {
                    _reservedNumber2 = temp;
                }
                Calculate();
                _clearTextBox = true;
            }
            else
            {
                if (_clearTextBox)
                {
                    txtInput.Text = text;

                    // only will be cleared once, then the rest will be the same flow.
                    _clearTextBox = false;
                }
                else
                {
                    txtInput.Text += text;
                }
            }
        }

        private void Calculate()
        {
            double? result = null;
            switch (_operator)
            {
                case "+":
                    result = _reservedNumber1 + _reservedNumber2;
                    break;
                case "-":
                    result = _reservedNumber1 - _reservedNumber2;
                    break;
                case "*":
                    result = _reservedNumber1 * _reservedNumber2;
                    break;
                case "/":
                    result = _reservedNumber1 / _reservedNumber2;
                    break;
                default:
                    break;
            }
            lblResult.Text = result.ToString();
        }

        private void button16_Click(object sender, EventArgs e) //equals button
        {
            txtInput.Clear();
            lblResult.Text = String.Empty;
        }
    }
}
