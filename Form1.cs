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


        private void Form1_Load(object sender, EventArgs e) // ������� ��� �������� �����
        {

        }

        private void label1_Click(object sender, EventArgs e) // ������� ��� �������
        {

        }

        private void label1_Click_1(object sender, EventArgs e) // ������� ��� �������
        {

        }

        private void label2_Click(object sender, EventArgs e) // ������� ��� �������
        {

        }

        private void label3_Click(object sender, EventArgs e) // ������� ��� �������
        {

        }

        private void button1_Click(object sender, EventArgs e) // ������� ��� �������
        {

        }

        private void label6_Click(object sender, EventArgs e) // ������� ��� �������
        {

        }

        private void button4_Click(object sender, EventArgs e) // ������� ��� ������� �� ������ "���������"
        {
            switch (task)
            {
                case 0:
                    {
                        MessageBox.Show("������� �� �������!");
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


    }

}
