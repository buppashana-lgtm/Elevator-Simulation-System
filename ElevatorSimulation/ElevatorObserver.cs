using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ElevatorSimulation
{
    interface IElevatorObserver
    {
        void Update(string elevatorName, string status);
    }

    class ElevatorDisplay : IElevatorObserver
    {
        private Label displayLabel;

        public ElevatorDisplay(Label label)
        {
            displayLabel = label;
        }

        public void Update(string elevatorName, string status)
        {
            displayLabel.Text = elevatorName + " : " + status;
        }
    }

    class ElevatorSubject
    {
        private List<IElevatorObserver> observers =
            new List<IElevatorObserver>();

        public void AddObserver(IElevatorObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify(string elevatorName, string status)
        {
            foreach (IElevatorObserver observer in observers)
            {
                observer.Update(elevatorName, status);
            }
        }
    }
}
