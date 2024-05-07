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

        static void FindLongestIncreasingSeq(double[,] matrix, int row, out int startIdx, out int length, int textBoxValue) // ����� ��� ������ ����� ������� ������������������
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
        private void Form1_Load(object sender, EventArgs e) // ������� ��� �������� �����
        {

        }

        private void label1_Click(object sender, EventArgs e) // ������� ��� �������
        {

        }

        private void label1_Click_1(object sender, EventArgs e) // ������� ��� ������� �� ����� "���-�� �����"
        {
            MessageBox.Show("������� ������, ������� ����� ������ ���� � �������");
        }

        private void label2_Click(object sender, EventArgs e) // ������� ��� ������� �� ����� "���������� ��������"
        {
            MessageBox.Show("������� ������, ������� �������� ������ ���� � �������");
        }

        private void label3_Click(object sender, EventArgs e) // ������� ��� ������� �� ����� "��:"
        {
            MessageBox.Show("����� ����� - �����������?");
        }

        private void button1_Click(object sender, EventArgs e) // ������� ��� ������� ������ "������� ������"
        {
            if ((double.Parse(textBox3.Text, CultureInfo.InvariantCulture)) > (double.Parse(textBox5.Text, CultureInfo.InvariantCulture)))
            {
                MessageBox.Show("����������� �� ����� ���� ������ �������������!");
            }
            else
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                if (textBox1 == null | textBox2 == null | textBox3 == null | textBox5 == null)
                { // ������� ������ ���� �����-�� �� textBox �� ��������
                    MessageBox.Show("�� ��� ��������� �������!");
                }
                int i = int.Parse(textBox1.Text); // ���������� �����
                int j = int.Parse(textBox2.Text); // ���������� ��������

                double m = double.Parse(textBox3.Text, CultureInfo.InvariantCulture); // ����������� �������� ����� � �������
                double n = double.Parse(textBox5.Text, CultureInfo.InvariantCulture); // ������������ �������� ����� � �������

                double[,] matrix = new double[i, j]; // ���� ������� (��������� ������ matrix)
                Random random = new Random(); // ��� ��������� �����

                // ���������� ������� ���������� ����������
                for (int row = 0; row < i; row++) // ���������� �����
                {
                    for (int col = 0; col < j; col++) // ���������� �������
                    {
                        matrix[row, col] = random.NextDouble() * (m - n) + n; // ��������� ������ ��������� ���������
                    }
                }

                // ���������� �������� � DataGridView
                for (int t = 0; t < matrix.GetLength(1); t++)
                {
                    dataGridView1.Columns.Add($"col{t}", $"Column {t}");
                }

                // ���������� ����� � DataGridView � ������� �� �������
                for (int f = 0; f < matrix.GetLength(0); f++)
                {
                    dataGridView1.Rows.Add(); // �������� �  dataGridView �������
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        dataGridView1.Rows[f].Cells[k].Value = matrix[f, k]; // ��������� ��� ������ �������
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e) // ������� ��� ������� �� ����� "�������"
        {
            MessageBox.Show("����� �������� ������ �������");
        }

        private void button4_Click(object sender, EventArgs e) // ������� ��� ������� �� ������ "���������"
        {
            if (!(textBox1.Text.Length == 0 & textBox2.Text.Length == 0 & textBox3.Text.Length == 0 & textBox5.Text.Length == 0))
            { // ������� ������ ���� �����-�� �� textBox �� ��������
                switch (task)
                {
                    case 0:
                        {
                            MessageBox.Show("������� �� �������!");
                            break;
                        }
                    case 8:
                        {
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            int x = int.Parse(textBox1.Text); // ���������� �����
                            int y = int.Parse(textBox2.Text); // ���������� ��������

                            double[,] matrix = new double[x, y]; // �������������� �������
                            Random random = new Random(); // ��������� �����

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
                            // ����� ������ � ������������ ������������������� ������������ �����
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
                            textBox4.Text += "����� ������ � ������������ ������������������� ����. �����:\n";
                            textBox4.Text += (globalNum + "\n");
                            textBox4.Text += ("���� ������������������:\n", globalNum);
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

                            int x = int.Parse(textBox1.Text); // ���������� �����
                            int y = int.Parse(textBox2.Text); // ���������� ��������

                            double[,] matrix = new double[x, y]; // �������������� �������
                            Random random = new Random(); // ��������� �����

                            for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                    matrix[i, j] = random.NextDouble() * (random.Next(2) == 0 ? -1 : 1);
                                }
                            }

                            // ���������� ����������� �������� ����� ������������ ��������� ������ ������ (p)
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

                            // ���������� ������������ �������� ����� ����������� ��������� ������� ������� (q)
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
                            textBox4.Text += "����������� �������� p: " + p + "\n";
                            textBox4.Text += "������������ �������� q:" + q + "\n";
                            textBox4.Text += "������������ p * q: " + p*q + "\n";
                            textBox4.Text += "================\n";
                            // ���������� � ����� ������������ p*q
                            double result = p * q;


                            break;
                        }
                    case 17:
                        {
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            int x = int.Parse(textBox1.Text); // ���������� �����
                            int y = int.Parse(textBox2.Text); // ���������� ��������

                            double[,] matrix = new double[x, y]; // �������������� �������
                            Random random = new Random(); // ��������� �����

                            for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                    matrix[i, j] = random.NextDouble() * (random.Next(2) == 0 ? -1 : 1);
                                }
                            }

                            // ����������� ��������� ������������� �������� ���� ������ ����� � ������������ �������� �������� ��������
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

                                // ���������� ��������� ������ �������� �� ���������� ���������
                                for (int b = 0; b < x; b++)
                                {
                                    if (i % 2 == 1) continue; // ���������� �������� �������
                                    for (int v = 0; v < y; v++)
                                    {
                                        matrix[v, b] /= ratio;
                                    }
                                }

                                // ���������� �������� � DataGridView
                                for (int t = 0; t < matrix.GetLength(1); t++)
                                {
                                    dataGridView1.Columns.Add($"col{t}", $"Column {t}");
                                }

                                // ���������� ����� � DataGridView � ������� �� �������
                                for (int f = 0; f < matrix.GetLength(0); f++)
                                {
                                    dataGridView1.Rows.Add(); // �������� �  dataGridView �������
                                    for (int k = 0; k < matrix.GetLength(1); k++)
                                    {
                                        dataGridView1.Rows[f].Cells[k].Value = matrix[f, k]; // ��������� ��� ������ �������
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

                            // ��������� ������� N x M � ������ ������� �� -2 �� 2
                            Random rand = new Random();

                            int N = rand.Next(11, 25);
                            int M = rand.Next(11, 25);
                            int[,] matrix = new int[N, M];

                            for (int i = 0; i < N; i++)
                            {
                                for (int j = 0; j < M; j++)
                                {
                                    matrix[i, j] = rand.Next(-2, 3); // ��������� ����� �� -2 �� 2
                                }
                            }

                            // ����� ���������� ������� �������� � ������ ������� � ������������ �������������� ������
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

                            // �������� �������������� ������ �� ���������� ������� �������� � ������ �������
                            int[] additionalRow = new int[M];
                            for (int j = 0; j < M; j++)
                            {
                                additionalRow[j] = zeroCounts[j];
                            }

                            textBox4.Clear();
                            textBox4.Text += "\n================\n";
                            textBox4.Text += "�������������� ������:\n";
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

                            int x = int.Parse(textBox1.Text); // ���������� �����
                            int y = int.Parse(textBox2.Text); // ���������� ��������

                            double[,] matrix = new double[x, y]; // �������������� �������
                            Random random = new Random(); // ��������� �����

                            for (int i = 0; i < x; i++)
                            {
                                for (int j = 0; j < y; j++)
                                {
                                    matrix[i, j] = random.NextDouble() * (random.Next(2) == 0 ? -1 : 1);
                                }
                            }

                            // ���������� ������������ �������� � �������
                            double min = matrix[0, 0];
                            foreach (double element in matrix)
                            {
                                if (element < min)
                                {
                                    min = element;
                                }
                            }

                            // ��������, �� �������� �� ����������� �������� �����
                            if (min == 0)
                            {
                                Console.WriteLine("����������� �������� � ������� ����� ����.");
                                textBox4.Clear();
                                textBox4.Text += "\n================\n";
                                textBox4.Text += "����������� ��������:\n";
                                textBox4.Text += "����� ����\n";
                                textBox4.Text += "================\n";
                            }
                            else
                            {
                                // ������� ���� ��������� ������� �� ����������� ��������
                                for (int i = 0; i < x; i++)
                                {
                                    for (int j = 0; j < y; j++)
                                    {
                                        matrix[i, j] /= min;
                                    }
                                }
                                textBox4.Clear();
                                textBox4.Text += "\n================\n";
                                textBox4.Text += "����������� ��������:\n";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e) // ������� ��� ��������� �������� Radiobutton ������� 8
        {
            //�������� ����������� � �������� RadioButton
            RadioButton radioButton = (RadioButton)sender;

            // ���������, ������ �� ������
            if (radioButton.Checked)
            {
                MessageBox.Show("������� ������� 8");
                task = 8;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // ������� ��� ��������� �������� Radiobutton ������� 9
        {
            RadioButton radioButton = (RadioButton)sender;

            // ���������, ������ �� ������
            if (radioButton.Checked)
            {
                MessageBox.Show("������� ������� 9");
                task = 9;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) // ������� ��� ��������� �������� Radiobutton ������� 17
        {
            RadioButton radioButton = (RadioButton)sender;

            // ���������, ������ �� ������
            if (radioButton.Checked)
            {
                MessageBox.Show("������� ������� 17");
                task = 17;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) // ������� ��� ��������� �������� Radiobutton ������� 32
        {
            RadioButton radioButton = (RadioButton)sender;

            // ���������, ������ �� ������
            if (radioButton.Checked)
            {
                MessageBox.Show("������� ������� 32");
                task = 32;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) // ������� ��� ��������� �������� Radiobutton ������� 34
        {
            RadioButton radioButton = (RadioButton)sender;

            // ���������, ������ �� ������
            if (radioButton.Checked)
            {
                MessageBox.Show("������� ������� 34");
                task = 34;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // ������ ������� ���������� ��� ����� ������� � ���������� � ���� �����
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) // ������ ������� ���������� ��� ����� ������� � ���������� � ���� �����
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) // ������ ������� ���������� ��� ����� ������� � ���������� � ���� �����
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                // ���� ������� ������� �� ������������� ��������, ��������� ��
                e.Handled = true;
            }

            // �������� �� ������� ������ ����� ���������� ����� ��� �������
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Contains(","))
            {
                // ���� � ��������� ���� ��� ���� ���������� ����� ��� �������, ��������� ������
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) // ������ ������� ���������� ��� ����� ������� � ���������� � ���� �����
        {
            // ���������, �������� �� ������� ������� ������, ������ ���������� ����� ��� �������
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                // ���� ������� ������� �� ������������� ��������, ��������� ��
                e.Handled = true;
            }

            // �������� �� ������� ������ ����� ���������� ����� ��� �������
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Contains(","))
            {
                // ���� � ��������� ���� ��� ���� ���������� ����� ��� �������, ��������� ������
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // ������������� �������� �� ��������� (�������)
                MessageBox.Show("������� ������ ���������!");
                textBox1.Clear();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // ������������� �������� �� ��������� (�������)
                MessageBox.Show("������� ������ ���������!");
                textBox2.Clear();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // ������������� �������� �� ��������� (�������)
                MessageBox.Show("������� ������ ���������!");
                textBox3.Clear();
            }
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                e.Handled = true; // ������������� �������� �� ��������� (�������)
                MessageBox.Show("������� ������ ���������!");
                textBox5.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                // �����������, ��� � ��� ���� DataGridView � ������ dataGridView1

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "��������� ��������� (*.txt)|*.txt";
                saveFileDialog.Title = "��������� ����";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // ���������� ������ �� DataGridView � ��������� ����
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                sw.Write(cell.Value + "\t"); // ���������� ��������� ��� ���������� ��������
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("������ ������� ��������� � ��������� ����.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "��������� ����� (*.txt)|*.txt";
            openFileDialog.Title = "������������� �������";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ������� ������������ ������ � DataGridView
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split('\t'); // ������������, ��� �������� ��������� ����������

                        if (isFirstLine)
                        {
                            // ��������� ������� � DataGridView �� ������ ������ ������ �����
                            foreach (string value in values)
                            {
                                dataGridView1.Columns.Add("Column", value);
                            }
                            isFirstLine = false;
                        }
                        else
                        {
                            // ��������� ������ � DataGridView �� ������ ��������� ����� �����
                            dataGridView1.Rows.Add(values);
                        }
                    }
                }

                MessageBox.Show("������ ������� ��������� � ���������.");
            }
        }

        private void label4_Click(object sender, EventArgs e) // ��� ������� �� ����� "��:" ������� �����������
        {
            MessageBox.Show("����� ����� - ������������?");
        }
    }
}
