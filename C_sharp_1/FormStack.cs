using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab1
{
    public partial class FormStack : Form
    {
        private IStack<object> currentStack;
        private Type dataType = typeof(int);
        private bool isUnmutable = false;
        public FormStack()
        {
            InitializeComponent();
            // Инициализация стека по умолчанию
            currentStack = new ArrayStack<object>();

        }

        // Обновление ListBox
        private void UpdateListBox()
        {
            listBoxStack.Items.Clear();
            foreach (var item in currentStack)
                listBoxStack.Items.Add(item);
        }

        // Обработчик изменения типа стека
        private void RadioStackType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioArrayStack.Checked)
                currentStack = new ArrayStack<object>();
            else if (radioLinkedStack.Checked)
                currentStack = new LinkedStack<object>();
            UpdateListBox();
        }

        // Обработчик изменения типа данных
        private void RadioDataType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioInt.Checked) dataType = typeof(int);
            else if (radioString.Checked) dataType = typeof(string);
            else if (radioPoint.Checked) dataType = typeof(Point);
        }

        // Push
        private void btnPush_Click(object sender, EventArgs e)
        {
            if (isUnmutable)
            {
                MessageBox.Show("Стек неизменяемый!");
                return;
            }

            try
            {
                object value = Convert.ChangeType(txtInput.Text, dataType);
                currentStack.Push(value);
                UpdateListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Pop
        private void btnPop_Click(object sender, EventArgs e)
        {
            try
            {
                currentStack.Pop();
                UpdateListBox();
            }
            catch (StackException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Peek
        private void btnPeek_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Вершина стека: {currentStack.Peek()}");
            }
            catch (StackException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            currentStack.Clear();
            UpdateListBox();
        }

        // Создание неизменяемого стека
        private void btnMakeUnmutable_Click(object sender, EventArgs e)
        {
            currentStack = new UnmutableStack<object>(currentStack);
            isUnmutable = true;
            MessageBox.Show("Стек теперь неизменяемый!");
        }

        // Конвертация элементов (пример: int -> string)
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем новый стек с типом object
                var convertedStack = new ArrayStack<object>();

                // Преобразуем каждый элемент текущего стека в строку
                foreach (var item in currentStack)
                {
                    convertedStack.Push(item.ToString());
                }

                // Заменяем текущий стек на новый
                currentStack = convertedStack;
                dataType = typeof(string);
                UpdateListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка конвертации: {ex.Message}");
            }
        }
        // Проверка наличия элемента
        private void btnContains_Click(object sender, EventArgs e)
        {
            try
            {
                object value = Convert.ChangeType(txtContains.Text, dataType);
                bool exists = false;
                foreach (var item in currentStack)
                {
                    if (item.Equals(value))
                    {
                        exists = true;
                        break;
                    }
                }
                MessageBox.Show(exists ? "Элемент найден" : "Элемент не найден");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Сделать стек изменяемым
        private void btnMakeMutable_Click(object sender, EventArgs e)
        {
            if (currentStack is UnmutableStack<object> unmutableStack)
            {
                currentStack = unmutableStack.GetOriginalStack();
                isUnmutable = false;
                MessageBox.Show("Стек теперь изменяемый!");
            }
            else
            {
                MessageBox.Show("Стек уже изменяемый");
            }
        }

        // Умножить все значения на 2
        private void btnMultiplyByTwo_Click(object sender, EventArgs e)
        {
            if (isUnmutable)
            {
                MessageBox.Show("Стек неизменяемый!");
                return;
            }

            try
            {
                var tempStack = new ArrayStack<object>();
                foreach (var item in currentStack)
                {
                    if (dataType == typeof(int))
                        tempStack.Push((int)item * 2);
                    else if (dataType == typeof(Point))
                        tempStack.Push(new Point(((Point)item).X * 2, ((Point)item).Y * 2));
                    else
                        throw new InvalidOperationException("Операция не поддерживается для этого типа");
                }
                currentStack = tempStack;
                UpdateListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Найти все четные элементы
        private void btnFindAllEven_Click(object sender, EventArgs e)
        {
            var evenStack = new ArrayStack<object>();
            foreach (var item in currentStack)
            {
                bool isEven = false;
                if (dataType == typeof(int))
                    isEven = (int)item % 2 == 0;
                else if (dataType == typeof(Point))
                    isEven = ((Point)item).X % 2 == 0 && ((Point)item).Y % 2 == 0;
                else if (dataType == typeof(string))
                    isEven = ((string)item).Length % 2 == 0;

                if (isEven)
                    evenStack.Push(item);
            }
            currentStack = evenStack;
            UpdateListBox();
        }

        // Найти последний четный элемент
        private void btnFindLastEven_Click(object sender, EventArgs e)
        {
            object lastEven = null;
            foreach (var item in currentStack)
            {
                bool isEven = false;
                if (dataType == typeof(int))
                    isEven = (int)item % 2 == 0;
                else if (dataType == typeof(Point))
                    isEven = ((Point)item).X % 2 == 0 && ((Point)item).Y % 2 == 0;
                else if (dataType == typeof(string))
                    isEven = ((string)item).Length % 2 == 0;

                if (isEven)
                    lastEven = item;
            }
            MessageBox.Show(lastEven != null ? $"Последний четный: {lastEven}" : "Четных элементов нет");
        }
    }
}