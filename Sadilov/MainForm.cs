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
            // Наполняем списки валютами при старте программы
            string[] currencies = { "USD", "EUR", "RUB", "GBP", "JPY", "CAD" };
            cmbFromCurrency.Items.AddRange(currencies);
            cmbToCurrency.Items.AddRange(currencies);

            // Устанавливаем значения по умолчанию
            cmbFromCurrency.SelectedIndex = 0; // USD
            cmbToCurrency.SelectedIndex = 2;   // RUB
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            // Проверяем, корректно ли введена сумма
            if (!double.TryParse(txtAmount.Text, out double amount) || amount <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму (число больше нуля).", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fromCurrency = cmbFromCurrency.SelectedItem.ToString();
            string toCurrency = cmbToCurrency.SelectedItem.ToString();

            lblStatus.Text = "Связь с сервером API...";
            btnConvert.Enabled = false; // Блокируем кнопку на время запроса

            try
            {
                // Вызываем метод нашего сервиса, который обращается к эндпоинту
                var response = await _apiService.GetLatestRatesAsync(fromCurrency);

                if (response != null && response.Rates != null && response.Rates.ContainsKey(toCurrency))
                {
                    double rate = response.Rates[toCurrency];
                    double convertedAmount = amount * rate;

                    // Выводим результат на экран
                    lblResult.Text = $"{amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}";
                    lblStatus.Text = $"Курс обновлен в {DateTime.Now.ToShortTimeString()}";
                }
                else
                {
                    lblStatus.Text = "Не удалось получить курс для этой пары.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Ошибка сети.";
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConvert.Enabled = true; // Разблокируем кнопку
            }
        }
    }
}
