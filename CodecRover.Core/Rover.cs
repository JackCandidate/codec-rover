using CodecRover.Core.Environments;

namespace CodecRover.Core
{
    /// <summary>
    /// A pretend Mars rover. It can move about a World based on commands
    /// </summary>
    public class Rover
    {
        Position m_Position;

        Position CurrentPosition { get { return m_Position; } }
        
        SimpleGridWorld m_World;

        

        CompassDirection CurrentDirection { get; private set; }
        public Rover(SimpleGridWorld world)
        {
            m_World = world;
            m_Position = new Position() { X = 1, Y = 1 };
        }

        public void Rotate(TurnDirection direction)
        {
            int directionChange = direction == TurnDirection.Left ? -1 : 1;
            CurrentDirection = (CompassDirection)4 - ((int)CurrentDirection + directionChange) % 4;
        }

        public void MoveForward()
        {
            Position desiredPosition = ProposeNewPosition(CurrentDirection);
            if(m_World.IsValidPosition(desiredPosition.X, desiredPosition.Y))
            {
                m_Position = desiredPosition;
            }
        }

       Position ProposeNewPosition(CompassDirection direction)
        {
            Position pos = new Position() { X = m_Position.X, Y = m_Position.Y };
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