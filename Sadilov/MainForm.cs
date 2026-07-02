using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sadilov
{
    public partial class MainForm : Form
    {
        private readonly ApiService _apiService;

        public MainForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // наполняем списки валютами
            string[] currencies = { "USD", "EUR", "RUB", "GBP", "JPY", "CAD" }; // доллар, евро, рубли, фунт стерлингов, йена, канадский доллар
            cmbFromCurrency.Items.AddRange(currencies);
            cmbToCurrency.Items.AddRange(currencies);

            // значения по умолчанию
            cmbFromCurrency.SelectedIndex = 0; // доллар
            cmbToCurrency.SelectedIndex = 2;   // рубли
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(txtAmount.Text, out double amount) || amount <= 0)
            {
                MessageBox.Show("пожалуйста, введите корректную сумму (число больше нуля).", "ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fromCurrency = cmbFromCurrency.SelectedItem.ToString();
            string toCurrency = cmbToCurrency.SelectedItem.ToString();

            lblStatus.Text = "связь с сервером API...";
            btnConvert.Enabled = false; 

            try
            {

                var response = await _apiService.GetLatestRatesAsync(fromCurrency);

                if (response != null && response.Rates != null && response.Rates.ContainsKey(toCurrency))
                {
                    double rate = response.Rates[toCurrency];
                    double convertedAmount = amount * rate;


                    lblResult.Text = $"{amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}";
                    lblStatus.Text = $"курс обновлен в {DateTime.Now.ToShortTimeString()}";
                }
                else
                {
                    lblStatus.Text = "не удалось получить курс для этой пары.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "ошибка сети.";
                MessageBox.Show(ex.Message, "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConvert.Enabled = true;
            }
        }

        private async void btnShowHistory_Click(object sender, EventArgs e)
        {
            string fromCurrency = cmbFromCurrency.SelectedItem.ToString();
            string toCurrency = cmbToCurrency.SelectedItem.ToString();

            DateTime selectedDate = dtpHistoryDate.Value;
            int year = selectedDate.Year;
            int month = selectedDate.Month;
            int day = selectedDate.Day;

            lblHistoryResult.Text = "загрузка данных из прошлого...";

            var apiService = new ApiService();
            var response = await apiService.GetHistoricalRatesAsync(fromCurrency, year, month, day);

            if (response != null && response.Rates != null)
            {
                if (response.Rates.TryGetValue(toCurrency, out double rate))
                {
                    if (double.TryParse(txtAmount.Text, out double amount))
                    {
                        double convertedValue = amount * rate;
                        lblHistoryResult.Text = $"{amount} {fromCurrency} на дату {selectedDate.ToShortDateString()} составляло {convertedValue:F2} {toCurrency} (Курс: {rate:F4})";
                    }
                    else
                    {
                        lblHistoryResult.Text = $"Курс на {selectedDate.ToShortDateString()}: 1 {fromCurrency} = {rate:F4} {toCurrency}";
                    }
                }
                else
                {
                    lblHistoryResult.Text = "выбранная валюта не найдена в исторических данных.";
                }
            }
            else
            {
                lblHistoryResult.Text = "не удалось получить исторические данные для этой даты.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
