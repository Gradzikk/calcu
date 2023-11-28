using System;
using System.Diagnostics.CodeAnalysis;

namespace calcu;
public partial class MainPage : ContentPage
{
    private double currentNumber;
    private double previousNumber;
    private string currentOperator;
    private List<string> history = new List<string>();

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnNumberButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var number = button.Text;
        displayLabel.Text += number;
        currentNumber = double.Parse(displayLabel.Text);
    }

    private void OnOperatorButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        currentOperator = button.Text;
        previousNumber = currentNumber;
        displayLabel.Text = "";
    }

    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        switch (currentOperator)
        {
            case "+":
                currentNumber = previousNumber + currentNumber;
                break;
            case "-":
                currentNumber = previousNumber - currentNumber;
                break;
            case "*":
                currentNumber = previousNumber * currentNumber;
                break;
            case "/":
                currentNumber = previousNumber / currentNumber;
                break;
            case "^":
                currentNumber = Math.Pow(previousNumber, currentNumber);
                break;
        }
        history.Add($"{previousNumber} {currentOperator} {currentNumber} = {currentNumber}");
        displayLabel.Text = currentNumber.ToString();
    }

    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        currentNumber = 0;
        previousNumber = 0;
        currentOperator = null;
        displayLabel.Text = "";
    }

    private void OnHistoryButtonClicked(object sender, EventArgs e)
    {
        
            DisplayAlert("Historia", string.Join(Environment.NewLine, history), "OK");
        
    }
}
