
using Hospital.BusinessLogical;
using Ninject;

namespace Hospital.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();

            using var kernel = new StandardKernel(
                new SimpleConfigModule());

            var logic = kernel.Get<Logic>();

            Application.Run(new Form1(logic));
        }
    }
}
