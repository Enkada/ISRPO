using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elevator.ElevatorHandler;

namespace Elevator
{
    class ElevatorHandler
    {
        public enum State
        {
            Up, Down, Closed, Opened
        }

        public State state;
        private int currentfloor;
        int maxFloor;
        Queue<int> primaryQueue = new Queue<int>();
        Queue<int> secondaryQueue = new Queue<int>();

        public int Currentfloor { get => currentfloor; set => currentfloor = value; }

        public ElevatorHandler(int maxFloor, int floor = 1)
        {
            state = State.Closed;
            this.maxFloor = maxFloor;
            this.Currentfloor = floor;
        }

        // Вызов лифта на этаже
        public void Call(int callingFloor)
        {
            if (callingFloor > maxFloor || callingFloor < 1)
                throw new Exception("Incorrect floor number");

            secondaryQueue.Enqueue(callingFloor);
        }

        // Нажатие кнопки в самом лифте
        public void Go(int targetFloor)
        {
            if (targetFloor > maxFloor || targetFloor < 1)
                throw new Exception("Incorrect floor number");

            primaryQueue.Enqueue(targetFloor);
        }

        public int GetTargetFloor()
        {
            if (primaryQueue.Count == 0 && secondaryQueue.Count == 0)
                return 0;

            return primaryQueue.Count == 0 ? secondaryQueue.Peek() : primaryQueue.Peek();
        }

        public void Update()
        {
            if (primaryQueue.Count == 0 && secondaryQueue.Count == 0)
            {
                state = State.Closed;
                return;
            }

            int targetFloor = GetTargetFloor();            

            if (state != State.Opened)
            {
                if (targetFloor > currentfloor)
                {
                    state = State.Up;
                }
                else if (targetFloor < currentfloor)
                {
                    state = State.Down;
                }
                else
                {
                    state = State.Opened;
                    primaryQueue = new Queue<int>(primaryQueue.Where(floor => floor != targetFloor));
                    secondaryQueue = new Queue<int>(secondaryQueue.Where(floor => floor != targetFloor));
                    return;
                }
            }
            else
            {
                state = State.Closed;
            }

            switch (state)
            {
                case State.Up:
                    currentfloor++;
                    break;
                case State.Down:
                    currentfloor--;
                    break;
            }
        }
    }
}
