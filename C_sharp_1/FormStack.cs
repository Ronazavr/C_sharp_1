using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab1
{
    public partial class FormStack : Form
    {
        private IStack<object> currentStack;
        private Type currentDataType = typeof(int);
        private bool isUnmutable = false;
        private bool suppressTypeChangeEvent = false;
        private bool stackTypeLocked = false; // Новое поле для блокировки выбора типа стека

        public FormStack()
        {
            InitializeComponent();
            currentStack = new ArrayStack<object>();
            UpdateStackTypeControls(); // Обновляем состояние элементов управления
        }

        // Обновление состояния элементов управления типом стека
        private void UpdateStackTypeControls()
        {
            radioArrayStack.Enabled = !stackTypeLocked;
            radioLinkedStack.Enabled = !stackTypeLocked;

            // Визуальная обратная связь
            groupBoxType.ForeColor = stackTypeLocked ? Color.Gray : SystemColors.ControlText;
            if (stackTypeLocked)
            {
                toolTip.SetToolTip(groupBoxType, "Тип стека заблокирован. Очистите стек для изменения.");
            }
            else
            {
                toolTip.RemoveAll();
            }
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
            if (stackTypeLocked)
            {
                // Восстанавливаем предыдущий выбор
                suppressTypeChangeEvent = true;
                if (currentStack is ArrayStack<object>)
                    radioArrayStack.Checked = true;
                else
                    radioLinkedStack.Checked = true;
                suppressTypeChangeEvent = false;

                MessageBox.Show("Невозможно изменить тип стека после добавления элементов. Очистите стек, чтобы изменить тип.");
                return;
            }

            if (suppressTypeChangeEvent) return;

            // Сохраняем текущие данные
            var tempList = new List<object>();
            foreach (var item in currentStack)
                tempList.Add(item);

            // Создаем новый стек
            if (radioArrayStack.Checked)
                currentStack = new ArrayStack<object>();
            else
                currentStack = new LinkedStack<object>();

            // Восстанавливаем данные (в обратном порядке)
            for (int i = tempList.Count - 1; i >= 0; i--)
                currentStack.Push(tempList[i]);

            UpdateListBox();
        }

        // Обработчик изменения типа данных
        private void RadioDataType_CheckedChanged(object sender, EventArgs e)
        {
            if (suppressTypeChangeEvent) return;

            if (radioInt.Checked)
                ChangeDataType(typeof(int));
            else if (radioString.Checked)
                ChangeDataType(typeof(string));
            else if (radioPoint.Checked)
                ChangeDataType(typeof(Point));
        }

        // Изменение типа данных с очисткой стека
        private void ChangeDataType(Type newType)
        {
            if (currentStack.Count > 0)
            {
                var result = MessageBox.Show("При изменении типа данных стек будет очищен. Продолжить?",
                                           "Внимание", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    suppressTypeChangeEvent = true;

                    // Возвращаем предыдущий выбор
                    if (currentDataType == typeof(int)) radioInt.Checked = true;
                    else if (currentDataType == typeof(string)) radioString.Checked = true;
                    else if (currentDataType == typeof(Point)) radioPoint.Checked = true;

                    suppressTypeChangeEvent = false;
                    return;
                }
            }

            currentDataType = newType;
            currentStack.Clear();

            // Разблокируем выбор типа стека при изменении типа данных
            stackTypeLocked = false;
            UpdateStackTypeControls();

            UpdateListBox();
        }

        // Push с проверкой типа
        private void btnPush_Click(object sender, EventArgs e)
        {
            if (isUnmutable)
            {
                MessageBox.Show("Стек неизменяемый!");
                return;
            }

            try
            {
                object value = ConvertToType(txtInput.Text, currentDataType);
                currentStack.Push(value);

                // Блокируем выбор типа стека после добавления первого элемента
                if (!stackTypeLocked && currentStack.Count > 0)
                {
                    stackTypeLocked = true;
                    UpdateStackTypeControls();
                }

                UpdateListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Преобразование строки в нужный тип
        private object ConvertToType(string input, Type targetType)
        {
            if (targetType == typeof(int))
            {
                return int.Parse(input);
            }
            else if (targetType == typeof(string))
            {
                return input;
            }
            else if (targetType == typeof(Point))
            {
                var parts = input.Split(',');
                if (parts.Length != 2)
                    throw new FormatException("Точка должна быть в формате X,Y");

                return new Point(int.Parse(parts[0]), int.Parse(parts[1]));
            }

            throw new NotSupportedException($"Тип {targetType.Name} не поддерживается");
        }

        // Pop
        private void btnPop_Click(object sender, EventArgs e)
        {
            try
            {
                currentStack.Pop();

                // Разблокируем выбор типа стека, если стек пуст
                if (stackTypeLocked && currentStack.Count == 0)
                {
                    stackTypeLocked = false;
                    UpdateStackTypeControls();
                }

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

            // Разблокируем выбор типа стека при очистке
            if (stackTypeLocked)
            {
                stackTypeLocked = false;
                UpdateStackTypeControls();
            }

            UpdateListBox();
        }

        // Создание неизменяемого стека
        private void btnMakeUnmutable_Click(object sender, EventArgs e)
        {
            currentStack = new UnmutableStack<object>(currentStack);
            isUnmutable = true;

            // Блокируем выбор типа стека для неизменяемого стека
            stackTypeLocked = true;
            UpdateStackTypeControls();

            MessageBox.Show("Стек теперь неизменяемый!");
        }

        // Конвертация элементов (пример: int -> string)
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем новый стек
                var convertedStack = new ArrayStack<object>();

                // Преобразуем каждый элемент текущего стека в строку
                foreach (var item in currentStack)
                {
                    convertedStack.Push(item.ToString());
                }

                // Меняем тип данных и стек
                suppressTypeChangeEvent = true;
                radioString.Checked = true;
                suppressTypeChangeEvent = false;

                currentDataType = typeof(string);
                currentStack = convertedStack;

                // Сохраняем состояние блокировки типа стека
                UpdateStackTypeControls();

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
                object value = ConvertToType(txtContains.Text, currentDataType);
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

                // Восстанавливаем состояние блокировки типа стека
                stackTypeLocked = currentStack.Count > 0;
                UpdateStackTypeControls();

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
                if (currentDataType != typeof(int) && currentDataType != typeof(Point))
                    throw new InvalidOperationException("Операция поддерживается только для int и Point");

                var tempStack = new ArrayStack<object>();
                foreach (var item in currentStack)
                {
                    if (currentDataType == typeof(int))
                        tempStack.Push((int)item * 2);
                    else if (currentDataType == typeof(Point))
                    {
                        var point = (Point)item;
                        tempStack.Push(new Point(point.X * 2, point.Y * 2));
                    }
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
                if (currentDataType == typeof(int))
                    isEven = (int)item % 2 == 0;
                else if (currentDataType == typeof(Point))
                {
                    var point = (Point)item;
                    isEven = point.X % 2 == 0 && point.Y % 2 == 0;
                }
                else if (currentDataType == typeof(string))
                    isEven = ((string)item).Length % 2 == 0;

                if (isEven)
                    evenStack.Push(item);
            }
            currentStack = evenStack;

            // Обновляем состояние блокировки типа стека
            stackTypeLocked = currentStack.Count > 0;
            UpdateStackTypeControls();

            UpdateListBox();
        }

        // Найти последний четный элемент
        private void btnFindLastEven_Click(object sender, EventArgs e)
        {
            object lastEven = null;
            foreach (var item in currentStack)
            {
                bool isEven = false;
                if (currentDataType == typeof(int))
                    isEven = (int)item % 2 == 0;
                else if (currentDataType == typeof(Point))
                {
                    var point = (Point)item;
                    isEven = point.X % 2 == 0 && point.Y % 2 == 0;
                }
                else if (currentDataType == typeof(string))
                    isEven = ((string)item).Length % 2 == 0;

                if (isEven)
                    lastEven = item;
            }
            MessageBox.Show(lastEven != null ? $"Последний четный: {lastEven}" : "Четных элементов нет");
        }

        private void FormStack_Load(object sender, EventArgs e)
        {

        }
    }
}