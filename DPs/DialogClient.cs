using System;
namespace DPs
{
    public class DialogClient
    {
        public void Main()
        {
            ClientCode(new WindowsDialog());
            Console.WriteLine("");
            ClientCode(new WebDialog());
        }

        private void ClientCode(Dialog dialog)
        {
            Console.WriteLine("\nClient: I'm not aware of the creator's class, " +
                "but it still works."  );
            dialog.Render();

        }
    }
}
