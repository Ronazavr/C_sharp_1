using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab1
{
    public partial class FormStack : Form
    {
        // Три отдельных стека с конкретными типами
        private IStack<int> intStack = new ArrayStack<int>();
        private IStack<string> stringStack = new ArrayStack<string>();
        private IStack<Point> pointStack = new ArrayStack<Point>();

        private Type currentDataType = typeof(int);
        private bool isUnmutable = false;
        private bool suppressTypeChangeEvent = false;
        private bool stackTypeLocked = false;
        private ToolTip stackToolTip;

        public FormStack()
        {
            InitializeComponent();
            stackToolTip = new ToolTip();
            stackToolTip.AutoPopDelay = 5000;
            stackToolTip.InitialDelay = 500;
            stackToolTip.ReshowDelay = 100;

            UpdateStackTypeControls();
        }

        // Обновление состояния элементов управления типом стека
        private void UpdateStackTypeControls()
        {
            if (radioArrayStack != null && radioLinkedStack != null && groupBoxType != null)
            {
                radioArrayStack.Enabled = !stackTypeLocked;
                radioLinkedStack.Enabled = !stackTypeLocked;
                groupBoxType.ForeColor = stackTypeLocked ? Color.Gray : SystemColors.ControlText;

                if (stackTypeLocked)
                {
                    stackToolTip.SetToolTip(groupBoxType, "Тип стека заблокирован. Очистите стек для изменения.");
                }
                else
                {
                    stackToolTip.RemoveAll();
                }
            }
        }

        // Вспомогательные методы для работы с текущим стеком
        private int GetCurrentStackCount()
        {
            if (currentDataType == typeof(int)) return intStack.Count;
            if (currentDataType == typeof(string)) return stringStack.Count;
            if (currentDataType == typeof(Point)) return pointStack.Count;
            return 0;
        }

        private void ClearCurrentStack()
        {
            if (currentDataType == typeof(int)) intStack.Clear();
            else if (currentDataType == typeof(string)) stringStack.Clear();
            else if (currentDataType == typeof(Point)) pointStack.Clear();
        }

        private void PushToCurrentStack(object value)
        {
            if (currentDataType == typeof(int)) intStack.Push((int)value);
            else if (currentDataType == typeof(string)) stringStack.Push((string)value);
            else if (currentDataType == typeof(Point)) pointStack.Push((Point)value);
        }

        private void PopFromCurrentStack()
        {
            if (currentDataType == typeof(int)) intStack.Pop();
            else if (currentDataType == typeof(string)) stringStack.Pop();
            else if (currentDataType == typeof(Point)) pointStack.Pop();
        }

        private object PeekFromCurrentStack()
        {
            if (currentDataType == typeof(int)) return intStack.Peek();
            if (currentDataType == typeof(string)) return stringStack.Peek();
            if (currentDataType == typeof(Point)) return pointStack.Peek();
            return null;
        }

        private bool IsCurrentStackEmpty()
        {
            if (currentDataType == typeof(int)) return intStack.IsEmpty;
            if (currentDataType == typeof(string)) return stringStack.IsEmpty;
            if (currentDataType == typeof(Point)) return pointStack.IsEmpty;
            return true;
        }

        private IEnumerable<object> GetCurrentStackEnumerable()
        {
            if (currentDataType == typeof(int))
            {
                foreach (var item in intStack) yield return item;
            }
            else if (currentDataType == typeof(string))
            {
                foreach (var item in stringStack) yield return item;
            }
            else if (currentDataType == typeof(Point))
            {
                foreach (var item in pointStack) yield return item;
            }
        }

        // Обновление ListBox
        private void UpdateListBox()
        {
            listBoxStack.Items.Clear();
            foreach (var item in GetCurrentStackEnumerable())
                listBoxStack.Items.Add(item);
        }

        // Обработчик изменения типа стека
        private void RadioStackType_CheckedChanged(object sender, EventArgs e)
        {
            if (stackTypeLocked)
            {
                suppressTypeChangeEvent = true;

                // Восстанавливаем предыдущий выбор
                if ((currentDataType == typeof(int) && intStack is ArrayStack<int>) ||
                    (currentDataType == typeof(string) && stringStack is ArrayStack<string>) ||
                    (currentDataType == typeof(Point) && pointStack is ArrayStack<Point>))
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
            foreach (var item in GetCurrentStackEnumerable())
                tempList.Add(item);

            // Создаем новый стек
            if (radioArrayStack.Checked)
            {
                if (currentDataType == typeof(int)) intStack = new ArrayStack<int>();
                else if (currentDataType == typeof(string)) stringStack = new ArrayStack<string>();
                else if (currentDataType == typeof(Point)) pointStack = new ArrayStack<Point>();
            }
            else
            {
                if (currentDataType == typeof(int)) intStack = new LinkedStack<int>();
                else if (currentDataType == typeof(string)) stringStack = new LinkedStack<string>();
                else if (currentDataType == typeof(Point)) pointStack = new LinkedStack<Point>();
            }

            // Восстанавливаем данные (в обратном порядке)
            for (int i = tempList.Count - 1; i >= 0; i--)
                PushToCurrentStack(tempList[i]);

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
            if (GetCurrentStackCount() > 0)
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
            ClearCurrentStack();

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
                PushToCurrentStack(value);

                // Блокируем выбор типа стека после добавления первого элемента
                if (!stackTypeLocked && GetCurrentStackCount() > 0)
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
                PopFromCurrentStack();

                // Разблокируем выбор типа стека, если стек пуст
                if (stackTypeLocked && IsCurrentStackEmpty())
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
                MessageBox.Show($"Вершина стека: {PeekFromCurrentStack()}");
            }
            catch (StackException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCurrentStack();

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
            if (currentDataType == typeof(int))
                intStack = new UnmutableStack<int>(intStack);
            else if (currentDataType == typeof(string))
                stringStack = new UnmutableStack<string>(stringStack);
            else if (currentDataType == typeof(Point))
                pointStack = new UnmutableStack<Point>(pointStack);

            isUnmutable = true;

            // Блокируем выбор типа стека для неизменяемого стека
            stackTypeLocked = true;
            UpdateStackTypeControls();

            MessageBox.Show("Стек теперь неизменяемый!");
        }

        // Проверка наличия элемента
        private void btnContains_Click(object sender, EventArgs e)
        {
            try
            {
                object value = ConvertToType(txtContains.Text, currentDataType);
                bool exists = false;

                foreach (var item in GetCurrentStackEnumerable())
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
            if (currentDataType == typeof(int) && intStack is UnmutableStack<int> unmutableIntStack)
            {
                intStack = unmutableIntStack.GetOriginalStack();
                isUnmutable = false;
            }
            else if (currentDataType == typeof(string) && stringStack is UnmutableStack<string> unmutableStringStack)
            {
                stringStack = unmutableStringStack.GetOriginalStack();
                isUnmutable = false;
            }
            else if (currentDataType == typeof(Point) && pointStack is UnmutableStack<Point> unmutablePointStack)
            {
                pointStack = unmutablePointStack.GetOriginalStack();
                isUnmutable = false;
            }
            else
            {
                MessageBox.Show("Стек уже изменяемый");
                return;
            }

            // Восстанавливаем состояние блокировки типа стека
            stackTypeLocked = GetCurrentStackCount() > 0;
            UpdateStackTypeControls();

            MessageBox.Show("Стек теперь изменяемый!");
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

                if (currentDataType == typeof(int))
                {
                    var tempStack = new ArrayStack<int>();
                    foreach (int item in intStack)
                        tempStack.Push(item * 2);
                    intStack = tempStack;
                }
                else if (currentDataType == typeof(Point))
                {
                    var tempStack = new ArrayStack<Point>();
                    foreach (Point item in pointStack)
                        tempStack.Push(new Point(item.X * 2, item.Y * 2));
                    pointStack = tempStack;
                }

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
            if (currentDataType == typeof(int))
            {
                var evenStack = new ArrayStack<int>();
                foreach (int item in intStack)
                    if (item % 2 == 0)
                        evenStack.Push(item);
                intStack = evenStack;
            }
            else if (currentDataType == typeof(Point))
            {
                var evenStack = new ArrayStack<Point>();
                foreach (Point item in pointStack)
                    if (item.X % 2 == 0 && item.Y % 2 == 0)
                        evenStack.Push(item);
                pointStack = evenStack;
            }
            else if (currentDataType == typeof(string))
            {
                var evenStack = new ArrayStack<string>();
                foreach (string item in stringStack)
                    if (item.Length % 2 == 0)
                        evenStack.Push(item);
                stringStack = evenStack;
            }

            // Обновляем состояние блокировки типа стека
            stackTypeLocked = GetCurrentStackCount() > 0;
            UpdateStackTypeControls();

            UpdateListBox();
        }

        // Найти последний четный элемент
        private void btnFindLastEven_Click(object sender, EventArgs e)
        {
            object lastEven = null;

            if (currentDataType == typeof(int))
            {
                foreach (int item in intStack)
                    if (item % 2 == 0)
                        lastEven = item;
            }
            else if (currentDataType == typeof(Point))
            {
                foreach (Point item in pointStack)
                    if (item.X % 2 == 0 && item.Y % 2 == 0)
                        lastEven = item;
            }
            else if (currentDataType == typeof(string))
            {
                foreach (string item in stringStack)
                    if (item.Length % 2 == 0)
                        lastEven = item;
            }

            MessageBox.Show(lastEven != null ? $"Последний четный: {lastEven}" : "Четных элементов нет");
        }

        private void FormStack_Load(object sender, EventArgs e)
        {
            // Пустая реализация
        }
    }
}