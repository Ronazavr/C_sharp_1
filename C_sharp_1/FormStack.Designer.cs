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
        private System.Windows.Forms.ToolTip toolTip;
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
            this.SuspendLayout();
            // 
            // FormStack
            // 
            this.ClientSize = new System.Drawing.Size(995, 721);
            this.Name = "FormStack";
            this.Load += new System.EventHandler(this.FormStack_Load);
            this.ResumeLayout(false);

        }
    }
}