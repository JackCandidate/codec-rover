namespace CodecRover.Core.Environments
{
    public interface IWorld
    {
        int Height { get; }
        int Width { get; }

        bool IsValidPosition(int x, int y);
    }
}