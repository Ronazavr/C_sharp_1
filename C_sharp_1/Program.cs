using lab1;
using System;
using System.Windows.Forms; // Добавьте это!

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormStack());
    }
}