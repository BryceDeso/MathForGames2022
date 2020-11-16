using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames3D
{
    class Actor
    {
        enum Shape
        { 
            SPHERE,
            CUBE,
        }

        public static Matrix4 CreateRotationZ(float radian)
        {
            return new Matrix4
                (
                    (float)Math.Cos(radian), (float)Math.Sin(radian), 0, 0,
                    (float)-Math.Sin(radian), (float)Math.Cos(radian), 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1
                );
        }

        public static Matrix4 CreateRotationY(float radian)
        {
            return new Matrix4
                (
                    (float)Math.Cos(radian), 0, (float)-Math.Sin(radian), 0,
                    0, 0, 1, 0,
                    (float)Math.Sin(radian), 0, (float)Math.Cos(radian), 0,
                    0, 0, 0, 1
                );
        }

        public static Matrix4 CreateRotationX(float radian)
        {
            return new Matrix4
                (
                    1, 0, 0, 0,
                    0, (float)Math.Cos(radian), (float)Math.Sin(radian), 0,
                    0, (float)-Math.Sin(radian), (float)Math.Cos(radian), 0,
                    0, 0, 0, 1
                );
        }
    }
}
