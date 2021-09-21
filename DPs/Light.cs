using System;
namespace DPs
{

    public interface ILightCommand{
        void Execute();
    }
    class LightOnCommand : ILightCommand
    {
        Light Light ;

        public LightOnCommand(Light light)
        {
            this.Light = light;
        }

        public void Execute()
        {
            this.Light.On();

        }
    }

    class LightOffCommand : ILightCommand
    {
        Light Light;

        public LightOffCommand(Light light)
        {
            this.Light = light;
        }

        public void Execute()
        {
            this.Light.Off();

        }
    }

    internal class Light
    {
        public Light()
        {
        }

        public void On() {
            Console.WriteLine("Switched On");
        }
        public void Off()
        {
            Console.WriteLine("Switched Off");
        }
    }

    public class SimpleRemoteControl
    {
        ILightCommand LightCommand;
        public SimpleRemoteControl()
        {
        }
        public void SetLightCommand(ILightCommand lightCommand)
        {
            this.LightCommand = lightCommand;
        }

        public void PressButton()
        {
            this.LightCommand.Execute();
        }
    }
}