using System;

namespace lab1
{
    partial class FormStack
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton radioArrayStack;
        private System.Windows.Forms.RadioButton radioLinkedStack;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.RadioButton radioInt;
        private System.Windows.Forms.RadioButton radioString;
        private System.Windows.Forms.RadioButton radioPoint;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnPop;
        private System.Windows.Forms.Button btnPeek;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox listBoxStack;
        private System.Windows.Forms.Button btnMakeUnmutable;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnContains;
        private System.Windows.Forms.Button btnMakeUMutable;
        private System.Windows.Forms.Button btnMultiplyByTwo;
        private System.Windows.Forms.Button findAllEven;
        private System.Windows.Forms.Button findLastEven;
        private System.Windows.Forms.TextBox txtContains;
        private System.Windows.Forms.Button btnMakeMutable;
        private System.Windows.Forms.Button btnFindAllEven;
        private System.Windows.Forms.Button btnFindLastEven;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        int rightColumnX = 350; // Пример значения
        int buttonY = 120;      // Начальная координата Y
        int buttonStep = 35;    // Шаг между кнопками

        private void InitializeComponent()
        {
            // 1. Инициализируйте все элементы управления перед их использованием
            this.btnPop = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnPeek = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMakeUnmutable = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnContains = new System.Windows.Forms.Button();
            this.btnContains = new System.Windows.Forms.Button();
            this.txtContains = new System.Windows.Forms.TextBox();
            this.btnMakeMutable = new System.Windows.Forms.Button();
            this.btnMultiplyByTwo = new System.Windows.Forms.Button();
            this.btnFindAllEven = new System.Windows.Forms.Button();
            this.btnFindLastEven = new System.Windows.Forms.Button();

            // Увеличиваем размер формы
            this.ClientSize = new System.Drawing.Size(600, 500);
            // Настройка ListBox
            this.listBoxStack = new System.Windows.Forms.ListBox();
            this.listBoxStack.Location = new System.Drawing.Point(12, 200);
            this.listBoxStack.Size = new System.Drawing.Size(300, 250);

            // Координаты для правого столбца
            int rightColumnX = 350;
            int buttonY = 120;
            int buttonStep = 20;

            // Перераспределение кнопок
            this.btnPush.Location = new System.Drawing.Point(rightColumnX, buttonY);
            this.btnPop.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnPeek.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnClear.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnMakeUnmutable.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnConvert.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnContains.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnMakeMutable.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnMultiplyByTwo.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnFindAllEven.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.btnFindLastEven.Location = new System.Drawing.Point(rightColumnX, buttonY += buttonStep);
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.radioArrayStack = new System.Windows.Forms.RadioButton();
            this.radioLinkedStack = new System.Windows.Forms.RadioButton();
            this.radioInt = new System.Windows.Forms.RadioButton();
            this.radioString = new System.Windows.Forms.RadioButton();
            this.radioPoint = new System.Windows.Forms.RadioButton();
            this.txtInput = new System.Windows.Forms.TextBox();

            // Текстовое поле для "Содержит"
            this.txtContains.Location = new System.Drawing.Point(rightColumnX, buttonY += 30);
            this.txtContains.Size = new System.Drawing.Size(200, 20);

            // Устанавливаем размеры кнопок
            var buttonSize = new System.Drawing.Size(200, 30);
            this.btnPush.Size = buttonSize;
            this.btnPop.Size = buttonSize;
            this.btnPeek.Size = buttonSize;
            this.btnClear.Size = buttonSize;
            this.btnMakeUnmutable.Size = buttonSize;
            this.btnConvert.Size = buttonSize;
            this.btnContains.Size = buttonSize;
            this.btnMakeMutable.Size = buttonSize;
            this.btnMultiplyByTwo.Size = buttonSize;
            this.btnFindAllEven.Size = buttonSize;
            this.btnFindLastEven.Size = buttonSize;

            // Добавляем элементы в Controls
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.groupBoxType,
                this.groupBoxData,
                this.txtInput,
                this.btnPush,
                this.btnPop,
                this.btnPeek,
                this.btnClear,
                this.listBoxStack,
                this.btnMakeUnmutable,
                this.btnConvert,
                this.btnContains,
                this.txtContains,
                this.btnMakeMutable,
                this.btnMultiplyByTwo,
                this.btnFindAllEven,
                this.btnFindLastEven
    });
            this.radioInt = new System.Windows.Forms.RadioButton();
            this.radioString = new System.Windows.Forms.RadioButton();
            this.radioPoint = new System.Windows.Forms.RadioButton();

            // Настройка RadioButton
            this.radioInt.Text = "int";
            this.radioString.Text = "string";
            this.radioPoint.Text = "Point";

            // Настройка groupBoxType
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.groupBoxType.Controls.Add(this.radioLinkedStack);
            this.groupBoxType.Controls.Add(this.radioArrayStack);
            this.groupBoxType.Location = new System.Drawing.Point(12, 12);
            this.groupBoxType.Size = new System.Drawing.Size(200, 100);
            this.groupBoxType.Text = "Тип стека";

            // Настройка radioArrayStack
            this.radioArrayStack.Location = new System.Drawing.Point(6, 19);
            this.radioArrayStack.Text = "ArrayStack";
            this.radioArrayStack.CheckedChanged += new System.EventHandler(this.RadioStackType_CheckedChanged);

            // Настройка radioLinkedStack
            this.radioLinkedStack.Location = new System.Drawing.Point(6, 40);
            this.radioLinkedStack.Text = "LinkedStack";
            this.radioLinkedStack.CheckedChanged += new System.EventHandler(this.RadioStackType_CheckedChanged);

            // Настройка groupBoxData
            this.groupBoxData.Controls.Add(this.radioPoint);
            this.groupBoxData.Controls.Add(this.radioString);
            this.groupBoxData.Controls.Add(this.radioInt);
            this.groupBoxData.Location = new System.Drawing.Point(218, 12);
            this.groupBoxData.Size = new System.Drawing.Size(200, 100);
            this.groupBoxData.Text = "Тип данных";

            // Настройка radioInt
            this.radioInt.Location = new System.Drawing.Point(6, 19);
            this.radioInt.Text = "int";
            this.radioInt.CheckedChanged += new System.EventHandler(this.RadioDataType_CheckedChanged);

            // Настройка radioString
            this.radioString.Location = new System.Drawing.Point(6, 44);
            this.radioString.Text = "string";
            this.radioString.CheckedChanged += new System.EventHandler(this.RadioDataType_CheckedChanged);

            // Настройка radioPoint
            this.radioPoint.Location = new System.Drawing.Point(6, 69);
            this.radioPoint.Text = "Point";
            this.radioPoint.CheckedChanged += new System.EventHandler(this.RadioDataType_CheckedChanged);

            // Настройка txtInput
            this.txtInput.Location = new System.Drawing.Point(12, 118);
            this.txtInput.Size = new System.Drawing.Size(200, 20);

            // Настройка btnPush
            this.btnPush.Location = new System.Drawing.Point(rightColumnX, 116);
            this.btnPush.Text = "Push";
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);

            // Настройка btnPop
            this.btnPop.Location = new System.Drawing.Point(rightColumnX, 144);
            this.btnPop.Text = "Pop";
            this.btnPop.Click += new System.EventHandler(this.btnPop_Click);

            // Настройка btnPeek
            this.btnPeek.Location = new System.Drawing.Point(rightColumnX, 172);
            this.btnPeek.Text = "Peek";
            this.btnPeek.Click += new System.EventHandler(this.btnPeek_Click);

            // Настройка btnClear
            this.btnClear.Location = new System.Drawing.Point(rightColumnX, 200);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // Настройка listBoxStack
            this.listBoxStack.FormattingEnabled = true;
            this.listBoxStack.Location = new System.Drawing.Point(12, 200);
            this.listBoxStack.Size = new System.Drawing.Size(300, 160); // Было 406


            // Настройка btnMakeUnmutable
            this.btnMakeUnmutable.Location = new System.Drawing.Point(rightColumnX, 228);
            this.btnMakeUnmutable.Size = new System.Drawing.Size(180, 30);
            this.btnMakeUnmutable.Text = "Сделать неизменяемым";
            this.btnMakeUnmutable.Click += new System.EventHandler(this.btnMakeUnmutable_Click);

            // Настройка btnConvert
            this.btnConvert.Location = new System.Drawing.Point(rightColumnX, 256);
            this.btnConvert.Size = new System.Drawing.Size(140, 30);
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // Кнопка "Содержит элемент"
            this.btnContains.Location = new System.Drawing.Point(rightColumnX, 284);
            this.txtContains.Location = new System.Drawing.Point(rightColumnX, 310);

            // Кнопка "Сделать изменяемым"
            this.btnMakeMutable.Location = new System.Drawing.Point(rightColumnX, 338);

            // Кнопка "Умножить на 2"
            this.btnMultiplyByTwo.Location = new System.Drawing.Point(rightColumnX, 366);

            // Кнопка "Найти все четные"
            this.btnFindAllEven.Location = new System.Drawing.Point(rightColumnX, 394);

            // Кнопка "Найти последний четный"
            this.btnFindLastEven.Location = new System.Drawing.Point(rightColumnX, 422);

            // Настройка btnContains
            // 2. Настройка координат и свойств элементов
            this.btnContains.Location = new System.Drawing.Point(350, 284);
            this.btnContains.Size = new System.Drawing.Size(200, 30);
            this.btnContains.Text = "Содержит";
            this.btnContains.Click += new System.EventHandler(this.btnContains_Click);

            // Настройка txtContains
            this.txtContains.Location = new System.Drawing.Point(rightColumnX, 310);
            this.txtContains.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(this.txtContains);

            // Настройка btnMakeMutable
            this.btnMakeMutable.Location = new System.Drawing.Point(350, 338);
            this.btnMakeMutable.Size = new System.Drawing.Size(200, 30);
            this.btnMakeMutable.Text = "Сделать изменяемым";
            this.btnMakeMutable.Click += new System.EventHandler(this.btnMakeMutable_Click);
            this.Controls.Add(this.btnMakeMutable);

            // Настройка btnMultiplyByTwo
            this.btnMultiplyByTwo.Location = new System.Drawing.Point(rightColumnX, 366);
            this.btnMultiplyByTwo.Size = new System.Drawing.Size(120, 30);
            this.btnMultiplyByTwo.Text = "Умножить на 2";
            this.btnMultiplyByTwo.Click += new System.EventHandler(this.btnMultiplyByTwo_Click);
            this.Controls.Add(this.btnMultiplyByTwo);

            // Настройка btnFindAllEven
            this.btnFindAllEven.Location = new System.Drawing.Point(rightColumnX, 394);
            this.btnFindAllEven.Size = new System.Drawing.Size(120, 30);
            this.btnFindAllEven.Text = "Найти все четные";
            this.btnFindAllEven.Click += new System.EventHandler(this.btnFindAllEven_Click);
            this.Controls.Add(this.btnFindAllEven);

            // Настройка btnFindLastEven
            this.btnFindLastEven.Location = new System.Drawing.Point(rightColumnX, 422);
            this.btnFindLastEven.Size = new System.Drawing.Size(120, 30);
            this.btnFindLastEven.Text = "Найти последний четный";
            this.btnFindLastEven.Click += new System.EventHandler(this.btnFindLastEven_Click);
            this.Controls.Add(this.btnFindLastEven);

            // Настройка формы
            this.ClientSize = new System.Drawing.Size(600, 370); // Было 430
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnPop);
            this.Controls.Add(this.btnPeek);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listBoxStack);
            this.Controls.Add(this.btnMakeUnmutable);
            this.Controls.Add(this.btnConvert);
            this.Text = "Работа со стеком";
        }
    }
}