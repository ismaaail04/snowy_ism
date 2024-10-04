using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snowy_ism
{
    public class Snow
    {
        // Параметры снежинки
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int Speed { get; set; }

        public Snow(int x, int y, int size, int speed)
        {
            X = x;
            Y = y;
            Size = size;
            Speed = speed;
        }
    }
}
