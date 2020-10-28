using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    class Matrix3
    {
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;
    }

    public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
    {
        return new Matrix3
        {
            lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13,
            lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23,
            lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33,
        };

    }


}
