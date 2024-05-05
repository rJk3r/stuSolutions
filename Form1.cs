using System.Security.Cryptography;

namespace Rgr
{
    public partial class Form1 : Form
    {
        int task = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e) // Событие при загрузке формы
        {

        }

        private void label1_Click(object sender, EventArgs e) // Событие при нажатии
        {

        }

        private void label1_Click_1(object sender, EventArgs e) // Событие при нажатии
        {

        }

        private void label2_Click(object sender, EventArgs e) // Событие при нажатии
        {

        }

        private void label3_Click(object sender, EventArgs e) // Событие при нажатии
        {

        }

        private void button1_Click(object sender, EventArgs e) // Событие при нажатии
        {

        }

        private void label6_Click(object sender, EventArgs e) // Событие при нажатии
        {

        }

        private void button4_Click(object sender, EventArgs e) // Событие при нажатии на кнопку "Выполнить"
        {
            switch (task)
            {
                case 0:
                    {
                        MessageBox.Show("Задание не выбрано!");
                        break;
                    }
                case 8:
                    {
                        MessageBox.Show("8");
                        break;
                    }
                case 9:
                    {
                        MessageBox.Show("9");
                        break;
                    }
                case 17:
                    {
                        MessageBox.Show("17");
                        break;
                    }
                case 32:
                    {
                        MessageBox.Show("32");
                        break;
                    }
                case 34:
                    {
                        MessageBox.Show("34");
                        break;
                    }
                default:
                    {
                        break;
                    }
            };
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) // Событие при изменении значения Radiobutton задание 8
        {
            //Приводим отправителя к элементу RadioButton
            RadioButton radioButton = (RadioButton)sender;

            // проверяем, нажата ли кнопка
            if (radioButton.Checked)
            {
                MessageBox.Show("Выбрано задание 8");
                task = 8;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // Событие при изменении значения Radiobutton задание 9
        {
            RadioButton radioButton = (RadioButton)sender;

            // проверяем, нажата ли кнопка
            if (radioButton.Checked)
            {
                MessageBox.Show("Выбрано задание 9");
                task = 9;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) // Событие при изменении значения Radiobutton задание 17
        {
            RadioButton radioButton = (RadioButton)sender;

            // проверяем, нажата ли кнопка
            if (radioButton.Checked)
            {
                MessageBox.Show("Выбрано задание 17");
                task = 17;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) // Событие при изменении значения Radiobutton задание 32
        {
            RadioButton radioButton = (RadioButton)sender;

            // проверяем, нажата ли кнопка
            if (radioButton.Checked)
            {
                MessageBox.Show("Выбрано задание 32");
                task = 32;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) // Событие при изменении значения Radiobutton задание 34
        {
            RadioButton radioButton = (RadioButton)sender;

            // проверяем, нажата ли кнопка
            if (radioButton.Checked)
            {
                MessageBox.Show("Выбрано задание 34");
                task = 34;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // Данная функция вызывается при вводе символа с клавиатуры в поле ввода
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) // Данная функция вызывается при вводе символа с клавиатуры в поле ввода
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) // Данная функция вызывается при вводе символа с клавиатуры в поле ввода
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                // Если нажатая клавиша не соответствует условиям, блокируем ее
                e.Handled = true;
            }

            // Проверка на наличие только одной десятичной точки или запятой
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Contains(","))
            {
                // Если в текстовом поле уже есть десятичная точка или запятая, блокируем вторую
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) // Данная функция вызывается при вводе символа с клавиатуры в поле ввода
        {
            // Проверяем, является ли нажатая клавиша цифрой, знаком десятичной точки или запятой
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                // Если нажатая клавиша не соответствует условиям, блокируем ее
                e.Handled = true;
            }

            // Проверка на наличие только одной десятичной точки или запятой
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Contains(","))
            {
                // Если в текстовом поле уже есть десятичная точка или запятая, блокируем вторую
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // Предотвращаем действие по умолчанию (вставку)
                MessageBox.Show("Вставка данных запрещена!");
                textBox1.Clear();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // Предотвращаем действие по умолчанию (вставку)
                MessageBox.Show("Вставка данных запрещена!");
                textBox2.Clear();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // Предотвращаем действие по умолчанию (вставку)
                MessageBox.Show("Вставка данных запрещена!");
                textBox3.Clear();
            }
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // Предотвращаем действие по умолчанию (вставку)
                MessageBox.Show("Вставка данных запрещена!");
                textBox5.Clear();
            }
        }


    }

}
