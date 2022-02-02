using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodecRover.Core.Environments
{
    public class SimpleGridWorld : IWorld
    {
        public int Width { get; private set; }
        public int Height { get; private set; }


        public SimpleGridWorld(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsValidPosition(int x, int y)
        {
            return x > 0 && y > 0 && x <= Width && y <= Height;
        }
    }
}
