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
        private System.Windows.Forms.Button btnContains;
        private System.Windows.Forms.Button btnMakeMutable;
        private System.Windows.Forms.Button btnMultiplyByTwo;
        private System.Windows.Forms.Button btnFindAllEven;
        private System.Windows.Forms.Button btnFindLastEven;
        private System.Windows.Forms.TextBox txtContains;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Text = "Работа со стеком";

            // Инициализация всех элементов управления
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.radioArrayStack = new System.Windows.Forms.RadioButton();
            this.radioLinkedStack = new System.Windows.Forms.RadioButton();

            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.radioInt = new System.Windows.Forms.RadioButton();
            this.radioString = new System.Windows.Forms.RadioButton();
            this.radioPoint = new System.Windows.Forms.RadioButton();

            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnPop = new System.Windows.Forms.Button();
            this.btnPeek = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBoxStack = new System.Windows.Forms.ListBox();
            this.btnMakeUnmutable = new System.Windows.Forms.Button();
            this.btnContains = new System.Windows.Forms.Button();
            this.txtContains = new System.Windows.Forms.TextBox();
            this.btnMakeMutable = new System.Windows.Forms.Button();
            this.btnMultiplyByTwo = new System.Windows.Forms.Button();
            this.btnFindAllEven = new System.Windows.Forms.Button();
            this.btnFindLastEven = new System.Windows.Forms.Button();

            this.stackToolTip = new System.Windows.Forms.ToolTip(this.components);

            // Настройка groupBoxType
            this.groupBoxType.SuspendLayout();
            this.groupBoxType.Location = new System.Drawing.Point(12, 12);
            this.groupBoxType.Size = new System.Drawing.Size(150, 80);
            this.groupBoxType.Text = "Тип стека";

            // Настройка radioArrayStack
            this.radioArrayStack.Location = new System.Drawing.Point(6, 19);
            this.radioArrayStack.Text = "ArrayStack";
            this.radioArrayStack.Checked = true;
            this.radioArrayStack.Size = new System.Drawing.Size(90, 17);

            // Настройка radioLinkedStack
            this.radioLinkedStack.Location = new System.Drawing.Point(6, 42);
            this.radioLinkedStack.Text = "LinkedStack";
            this.radioLinkedStack.Size = new System.Drawing.Size(90, 17);

            // Добавление radioButton'ов в groupBoxType
            this.groupBoxType.Controls.Add(this.radioArrayStack);
            this.groupBoxType.Controls.Add(this.radioLinkedStack);

            // Настройка groupBoxData
            this.groupBoxData.SuspendLayout();
            this.groupBoxData.Location = new System.Drawing.Point(168, 12);
            this.groupBoxData.Size = new System.Drawing.Size(150, 100);
            this.groupBoxData.Text = "Тип данных";

            // Настройка radioInt
            this.radioInt.Location = new System.Drawing.Point(6, 19);
            this.radioInt.Text = "int";
            this.radioInt.Checked = true;
            this.radioInt.Size = new System.Drawing.Size(45, 17);

            // Настройка radioString
            this.radioString.Location = new System.Drawing.Point(6, 42);
            this.radioString.Text = "string";
            this.radioString.Size = new System.Drawing.Size(55, 17);

            // Настройка radioPoint
            this.radioPoint.Location = new System.Drawing.Point(6, 65);
            this.radioPoint.Text = "Point";
            this.radioPoint.Size = new System.Drawing.Size(50, 17);

            // Добавление radioButton'ов в groupBoxData
            this.groupBoxData.Controls.Add(this.radioInt);
            this.groupBoxData.Controls.Add(this.radioString);
            this.groupBoxData.Controls.Add(this.radioPoint);

            // Настройка txtInput
            this.txtInput.Location = new System.Drawing.Point(12, 118);
            this.txtInput.Size = new System.Drawing.Size(150, 20);

            // Настройка кнопок
            int rightColumnX = 350;
            int buttonY = 120;
            int buttonStep = 35;

            this.btnPush.Location = new System.Drawing.Point(12, 144);
            this.btnPush.Text = "Push";
            this.btnPush.Size = new System.Drawing.Size(75, 30);

            this.btnPop.Location = new System.Drawing.Point(93, 144);
            this.btnPop.Text = "Pop";
            this.btnPop.Size = new System.Drawing.Size(75, 30);

            this.btnPeek.Location = new System.Drawing.Point(174, 144);
            this.btnPeek.Text = "Peek";
            this.btnPeek.Size = new System.Drawing.Size(75, 30);

            this.btnClear.Location = new System.Drawing.Point(255, 144);
            this.btnClear.Text = "Clear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);

            this.btnMakeUnmutable.Location = new System.Drawing.Point(12, 180);
            this.btnMakeUnmutable.Text = "Сделать неизменяемым";
            this.btnMakeUnmutable.Size = new System.Drawing.Size(150, 30);

            this.btnMakeMutable.Location = new System.Drawing.Point(168, 180);
            this.btnMakeMutable.Text = "Сделать изменяемым";
            this.btnMakeMutable.Size = new System.Drawing.Size(150, 30);

            this.btnMultiplyByTwo.Location = new System.Drawing.Point(12, 216);
            this.btnMultiplyByTwo.Text = "Умножить на 2";
            this.btnMultiplyByTwo.Size = new System.Drawing.Size(120, 30);

            this.btnFindAllEven.Location = new System.Drawing.Point(138, 216);
            this.btnFindAllEven.Text = "Найти все четные";
            this.btnFindAllEven.Size = new System.Drawing.Size(120, 30);

            this.btnFindLastEven.Location = new System.Drawing.Point(264, 216);
            this.btnFindLastEven.Text = "Найти последний четный";
            this.btnFindLastEven.Size = new System.Drawing.Size(150, 30);

            this.txtContains.Location = new System.Drawing.Point(12, 252);
            this.txtContains.Size = new System.Drawing.Size(150, 20);

            this.btnContains.Location = new System.Drawing.Point(168, 252);
            this.btnContains.Text = "Содержит";
            this.btnContains.Size = new System.Drawing.Size(100, 30);

            // Настройка listBoxStack
            this.listBoxStack.Location = new System.Drawing.Point(12, 288);
            this.listBoxStack.Size = new System.Drawing.Size(400, 200);

            // Добавление всех элементов на форму
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnPop);
            this.Controls.Add(this.btnPeek);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listBoxStack);
            this.Controls.Add(this.btnMakeUnmutable);
            this.Controls.Add(this.btnContains);
            this.Controls.Add(this.txtContains);
            this.Controls.Add(this.btnMakeMutable);
            this.Controls.Add(this.btnMultiplyByTwo);
            this.Controls.Add(this.btnFindAllEven);
            this.Controls.Add(this.btnFindLastEven);

            // Подписка на события
            this.radioArrayStack.CheckedChanged += new System.EventHandler(this.RadioStackType_CheckedChanged);
            this.radioLinkedStack.CheckedChanged += new System.EventHandler(this.RadioStackType_CheckedChanged);
            this.radioInt.CheckedChanged += new System.EventHandler(this.RadioDataType_CheckedChanged);
            this.radioString.CheckedChanged += new System.EventHandler(this.RadioDataType_CheckedChanged);
            this.radioPoint.CheckedChanged += new System.EventHandler(this.RadioDataType_CheckedChanged);

            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            this.btnPop.Click += new System.EventHandler(this.btnPop_Click);
            this.btnPeek.Click += new System.EventHandler(this.btnPeek_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnMakeUnmutable.Click += new System.EventHandler(this.btnMakeUnmutable_Click);
            this.btnContains.Click += new System.EventHandler(this.btnContains_Click);
            this.btnMakeMutable.Click += new System.EventHandler(this.btnMakeMutable_Click);
            this.btnMultiplyByTwo.Click += new System.EventHandler(this.btnMultiplyByTwo_Click);
            this.btnFindAllEven.Click += new System.EventHandler(this.btnFindAllEven_Click);
            this.btnFindLastEven.Click += new System.EventHandler(this.btnFindLastEven_Click);

            this.groupBoxType.ResumeLayout(false);
            this.groupBoxData.ResumeLayout(false);
        }
    }
}