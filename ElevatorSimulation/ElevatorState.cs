using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSimulation
{
    interface IElevatorState
    {
        void Handle(Elevator elevator);
    }

    class Elevator
    {
        public IElevatorState CurrentState;

        public void SetState(IElevatorState state)
        {
            CurrentState = state;
        }

        public void PerformAction()
        {
            CurrentState.Handle(this);
        }
    }

    class IdleState : IElevatorState
    {
        public void Handle(Elevator elevator)
        {
            // Elevator is waiting for a request
        }
    }

    class MovingState : IElevatorState
    {
        public void Handle(Elevator elevator)
        {
            // Elevator is moving between floors
        }
    }

    class DoorOpenState : IElevatorState
    {
        public void Handle(Elevator elevator)
        {
            // Elevator door is open
        }
    }
}
