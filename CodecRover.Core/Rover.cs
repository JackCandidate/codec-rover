using CodecRover.Core.Environments;

namespace CodecRover.Core
{
    /// <summary>
    /// A pretend Mars rover. It can move about a World based on commands
    /// </summary>
    public class Rover
    {
        public Position CurrentPosition { get; private set; }
        public CompassDirection CurrentDirection { get; private set; } = CompassDirection.North;

        IWorld m_World;
        public Rover(IWorld world)
        {
            m_World = world;
            CurrentPosition = new Position() { X = 1, Y = 1 };
        }

        public void Rotate(TurnDirection direction)
        {
            int directionChange = direction == TurnDirection.Left ? -1 : 1;
            int newDirection = ((int)(CurrentDirection + directionChange) % 4);
            if(newDirection < 0 )
            {
                newDirection += 4;
            }
            CurrentDirection = (CompassDirection)newDirection;
        }

        public void MoveForward()
        {
            Position desiredPosition = ProposeNewPosition(CurrentDirection);
            if(m_World.IsValidPosition(desiredPosition.X, desiredPosition.Y))
            {
                CurrentPosition = desiredPosition;
            }
        }

       Position ProposeNewPosition(CompassDirection direction)
        {
            Position pos = new Position() { X = CurrentPosition.X, Y = CurrentPosition.Y };
            switch (direction)
            {
                case CompassDirection.North:
                    pos.Y++;
                    break;
                case CompassDirection.East:
                    pos.X++;
                    break;
                case CompassDirection.South:
                    pos.Y--;
                    break;
                case CompassDirection.West:
                    pos.X--;
                    break;
                default:
                    break;
            }
            return pos;
        }
    }

    public enum TurnDirection { Left, Right };
    public enum CompassDirection { North, East, South, West };
    public enum Command { TurnLeft, TurnRight, Advance }
}