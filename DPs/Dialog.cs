using System;
namespace DPs
{
    public abstract class Dialog
    {
        public abstract IButton CreateButton();
        
        public void Render()
        {
            var okButton = CreateButton();
            okButton.OnClick();
            Console.WriteLine("");
        }


    }
    public class WindowsDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new WindowsButton();
        }

    }

    public class WebDialog : Dialog
    {
        public override IButton CreateButton()
        {
            return new WebButton();
        }

    }
}
