using System;

namespace DPs
{
    public interface IButton
    {
        void OnClick();
    }

    public class WindowsButton : IButton
    {
        public void OnClick() {
            Console.WriteLine("Clicked the button in windows");
        }
        
    }

    public class WebButton : IButton
    {
        public void OnClick()
        {
            Console.WriteLine("Clicked the button on the web");
        }
        
    }
}