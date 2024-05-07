using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Rgr
{
    public partial class Form1 : Form
    {
        int task = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
        }

        static void FindLongestIncreasingSeq(double[,] matrix, int row, out int startIdx, out int length, int textBoxValue) // метод для поиска самой длинной последовательности
        {
            startIdx = 0;
            length = 1;
            int currLen = 1;
            int value = textBoxValue;


            for (int i = 1; i < value; i++)
            {
                if (matrix[row, i] > matrix[row, i - 1])
                {
                    currLen++;
                    if (currLen > length)
                    {
                        length = currLen;
                        startIdx = i - length + 1;
                    }
                }
                else
                {
                    currLen = 1;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e) // Событие при загрузке формы
        {

        }

        private void label1_Click(object sender, EventArgs e) // Событие при нажатии
        {

        }

        private void label1_Click_1(object sender, EventArgs e) // Событие при нажатии на текст "Кол-во строк"
        {
            MessageBox.Show("Укажите числом, сколько строк должно быть в матрице");
        }

        private void label2_Click(object sender, EventArgs e) // Событие при нажатии на текст "Количество столбцов"
        {
            MessageBox.Show("Укажите числом, сколько столбцов должно быть в матрице");
        }

        private void label3_Click(object sender, EventArgs e) // Событие при нажатии на текст "От:"
        {
            MessageBox.Show("Какое число - минимальное?");
        }

        private void button1_Click(object sender, EventArgs e) // Событие при нажатии кнопки "Создать массив"
        {
            if ((double.Parse(textBox3.Text, CultureInfo.InvariantCulture)) > (double.Parse(textBox5.Text, CultureInfo.InvariantCulture)))
            {
                MessageBox.Show("Минимальное не может быть больше максимального!");
            }
            else
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                if (textBox1 == null | textBox2 == null | textBox3 == null | textBox5 == null)
                { // вернуть ошибку если какой-то из textBox не заполнен
                    MessageBox.Show("Не все параметры указаны!");
                }
                int i = int.Parse(textBox1.Text); // количество строк
                int j = int.Parse(textBox2.Text); // количество столбцов

                double m = double.Parse(textBox3.Text, CultureInfo.InvariantCulture); // Минимальное значение числа в матрице
                double n = double.Parse(textBox5.Text, CultureInfo.InvariantCulture); // Максимальное значение числа в матрице

                double[,] matrix = new double[i, j]; // наша матрица (двумерный массив matrix)
                Random random = new Random(); // для случайных чисел

                // Заполнение матрицы случайными значениями
                for (int row = 0; row < i; row++) // перебирает сроки
                {
                    for (int col = 0; col < j; col++) // перебирает столбцы
                    {
                        matrix[row, col] = random.NextDouble() * (m - n) + n; // заполняем ячейку случайным значением
                    }
                }

                // Добавление столбцов в DataGridView
                for (int t = 0; t < matrix.GetLength(1); t++)
                {
                    dataGridView1.Columns.Add($"col{t}", $"Column {t}");
                }

                // Добавление строк в DataGridView с данными из матрицы
                for (int f = 0; f < matrix.GetLength(0); f++)
                {
                    dataGridView1.Rows.Add(); // добавить в  dataGridView столбец
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        dataGridView1.Rows[f].Cells[k].Value = matrix[f, k]; // заполнить его ячейки данными
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e) // Событие при нажатии на текст "Задания"
        {
            MessageBox.Show("Здесь выберите нужное задание");
        }

        private void button4_Click(object sender, EventArgs e) // Событие при нажатии на кнопку "Выполнить"
        {
            if (!(textBox1.Text.Length == 0 & textBox2.Text.Length == 0 & textBox3.Text.Length == 0 & textBox5.Text.Length == 0))
            { // вернуть ошибку если какой-то из textBox не заполнен
                switch (task)
                {
                    case 0:
                        {
                            MessageBox.Show("Задание не выбрано!");
                            break;
                        }
                    case 8:
                        {
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            int x = int.Parse(textBox1.Text); // количество строк
                            int y = int.Parse(textBox2.Text); // количество столбцов

                            double[,] matrix = new double[x, y]; // инициализируем матрицу
                            Random random = new Random(); // случайные числа

                            for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                    matrix[i, j] = random.NextDouble() * (random.Next(2) == 0 ? -1 : 1);
                                }
                            }

                            int maxLength = 0;
                            int rowNum = -1;

                            int globalNum = 0;
                            // Поиск строки с возрастающей последовательностью максимальной длины
                            for (int i = 0; i < x; i++)
                            {
                                int startIdx, length;
                                FindLongestIncreasingSeq(matrix, i, out startIdx, out length, x);

                                if (length > maxLength)
                                {
                                    maxLength = length;
                                    rowNum = i;
                                    globalNum = rowNum;
                                }
                            }

                            textBox4.Text += "\n================\n";
                            textBox4.Text += "Номер строки с возвращающей последовательностью макс. длины:\n";
                            textBox4.Text += (globalNum + "\n");
                            textBox4.Text += ("Сама последовательность:\n", globalNum);
                            for (int i = 0; i < maxLength; i++)
                            {
                                textBox4.Text += (matrix[rowNum, i] + " ");
                            }
                            textBox4.Text += "\n================\n";

                            break;
                        }
                    case 9:
                        {
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            int x = int.Parse(textBox1.Text); // количество строк
                            int y = int.Parse(textBox2.Text); // количество столбцов

                            double[,] matrix = new double[x, y]; // инициализируем матрицу
                            Random random = new Random(); // случайные числа

                            for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                    matrix[i, j] = random.NextDouble() * (random.Next(2) == 0 ? -1 : 1);
                                }
                            }

                            // Нахождение минимальных значений среди максимальных элементов каждой строки (p)
                            double p = double.MaxValue;
                            for (int i = 0; i < x; i++)
                            {
                                double maxInRow = double.MinValue;
                                for (int j = 0; j < y; j++)
                                {
                                    if (matrix[i, j] > maxInRow)
                                    {
                                        maxInRow = matrix[i, j];
                                    }
                                }
                                if (maxInRow < p)
                                {
                                    p = maxInRow;
                                }
                            }

                            // Нахождение максимальных значений среди минимальных элементов каждого столбца (q)
                            double q = double.MinValue;
                            for (int j = 0; j < x; j++)
                            {
                                double minInCol = double.MaxValue;
                                for (int i = 0; i < y; i++)
                                {
                                    if (matrix[i, j] < minInCol)
                                    {
                                        minInCol = matrix[i, j];
                                    }
                                }
                                if (minInCol > q)
                                {
                                    q = minInCol;
                                }
                            }
                            textBox4.Text += "\n================\n";
                            textBox4.Text += "Минимальное значение p: " + p + "\n";
                            textBox4.Text += "Максимальное значение q:" + q + "\n";
                            textBox4.Text += "Произведение p * q: " + p*q + "\n";
                            textBox4.Text += "================\n";
                            // Вычисление и вывод произведения p*q
                            double result = p * q;


                            break;
                        }
                    case 17:
                        {
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            int x = int.Parse(textBox1.Text); // количество строк
                            int y = int.Parse(textBox2.Text); // количество столбцов

                            double[,] matrix = new double[x, y]; // инициализируем матрицу
                            Random random = new Random(); // случайные числа

                            for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                    matrix[i, j] = random.NextDouble() * (random.Next(2) == 0 ? -1 : 1);
                                }
                            }

                            // Определение отношения максимального элемента всех четных строк к минимальному элементу нечетных столбцов
                            double evenRowsMax = double.MinValue;
                            double oddColsMin = double.MaxValue;
                            for (int i = 0; i < x; i += 2)
                            {
                                for (int j = 1; j < y; j += 2)
                                {
                                    if (matrix[i, j] < oddColsMin)
                                    {
                                        oddColsMin = matrix[i, j];
                                    }
                                }
                                if (matrix[i, i] > evenRowsMax)
                                {
                                    evenRowsMax = matrix[i, i];
                                }

                                double ratio = evenRowsMax / oddColsMin;

                                // Разделение элементов четных столбцов на полученное отношение
                                for (int b = 0; b < x; b++)
                                {
                                    if (i % 2 == 1) continue; // пропускаем нечетные столбцы
                                    for (int v = 0; v < y; v++)
                                    {
                                        matrix[v, b] /= ratio;
                                    }
                                }

                                // Добавление столбцов в DataGridView
                                for (int t = 0; t < matrix.GetLength(1); t++)
                                {
                                    dataGridView1.Columns.Add($"col{t}", $"Column {t}");
                                }

                                // Добавление строк в DataGridView с данными из матрицы
                                for (int f = 0; f < matrix.GetLength(0); f++)
                                {
                                    dataGridView1.Rows.Add(); // добавить в  dataGridView столбец
                                    for (int k = 0; k < matrix.GetLength(1); k++)
                                    {
                                        dataGridView1.Rows[f].Cells[k].Value = matrix[f, k]; // заполнить его ячейки данными
                                    }
                                }
                            }
                            break;
                        }
                    case 32:
                        {
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            // Генерация матрицы N x M с целыми числами от -2 до 2
                            Random rand = new Random();

                            int N = rand.Next(11, 25);
                            int M = rand.Next(11, 25);
                            int[,] matrix = new int[N, M];

                            for (int i = 0; i < N; i++)
                            {
                                for (int j = 0; j < M; j++)
                                {
                                    matrix[i, j] = rand.Next(-2, 3); // генерация чисел от -2 до 2
                                }
                            }

                            // Поиск количества нулевых значений в каждом столбце и формирование дополнительной строки
                            int[] zeroCounts = new int[M];
                            for (int j = 0; j < M; j++)
                            {
                                int count = 0;
                                for (int i = 0; i < N; i++)
                                {
                                    if (matrix[i, j] == 0)
                                    {
                                        count++;
                                    }
                                }
                                zeroCounts[j] = count;
                            }

                            // Создание дополнительной строки из количества нулевых значений в каждом столбце
                            int[] additionalRow = new int[M];
                            for (int j = 0; j < M; j++)
                            {
                                additionalRow[j] = zeroCounts[j];
                            }

                            textBox4.Clear();
                            textBox4.Text += "\n================\n";
                            textBox4.Text += "Дополнительная строка:\n";
                            foreach (var item in additionalRow)
                            {
                                textBox4.Text += (item + "\t");
                            }

                            textBox4.Text += "================\n";


                            break;
                        }
                    case 34:
                        {
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            int x = int.Parse(textBox1.Text); // количество строк
                            int y = int.Parse(textBox2.Text); // количество столбцов

                            double[,] matrix = new double[x, y]; // инициализируем матрицу
                            Random random = new Random(); // случайные числа

                            for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                    matrix[i, j] = random.NextDouble() * (random.Next(2) == 0 ? -1 : 1);
                                }
                            }

                            // Нахождение минимального значения в матрице
                            double min = matrix[0, 0];
                            foreach (double element in matrix)
                            {
                                if (element < min)
                                {
                                    min = element;
                                }
                            }

                            // Проверка, не является ли минимальное значение нулем
                            if (min == 0)
                            {
                                Console.WriteLine("Минимальное значение в матрице равно нулю.");
                                textBox4.Clear();
                                textBox4.Text += "\n================\n";
                                textBox4.Text += "Минимальное значение:\n";
                                textBox4.Text += "равно нулю\n";
                                textBox4.Text += "================\n";
                            }
                            else
                            {
                                // Деление всех элементов матрицы на минимальное значение
                                for (int i = 0; i < x; i++)
                                {
                                    for (int j = 0; j < y; j++)
                                    {
                                        matrix[i, j] /= min;
                                    }
                                }
                                textBox4.Clear();
                                textBox4.Text += "\n================\n";
                                textBox4.Text += "Минимальное значение:\n";
                                textBox4.Text += (min + "\n");
                                textBox4.Text += "================\n";

                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                // Предположим, что у вас есть DataGridView с именем dataGridView1

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые документы (*.txt)|*.txt";
                saveFileDialog.Title = "Сохранить файл";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Записываем данные из DataGridView в текстовый файл
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                sw.Write(cell.Value + "\t"); // Используем табуляцию для разделения значений
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("Данные успешно сохранены в текстовый файл.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            openFileDialog.Title = "Импортировать матрицу";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Очищаем существующие данные в DataGridView
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split('\t'); // Предполагаем, что значения разделены табуляцией

                        if (isFirstLine)
                        {
                            // Добавляем столбцы в DataGridView на основе первой строки файла
                            foreach (string value in values)
                            {
                                dataGridView1.Columns.Add("Column", value);
                            }
                            isFirstLine = false;
                        }
                        else
                        {
                            // Добавляем строки в DataGridView на основе остальных строк файла
                            dataGridView1.Rows.Add(values);
                        }
                    }
                }

                MessageBox.Show("Данные успешно загружены в программу.");
            }
        }

        private void label4_Click(object sender, EventArgs e) // при нажатии на текст "До:" выведем уведомление
        {
            MessageBox.Show("Какое число - максимальное?");
        }
    }
}
