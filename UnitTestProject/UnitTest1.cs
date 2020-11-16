using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        const float DEFAULT_TOLERANCE = 0.0001f;
        Matrix3 Transpose(Matrix3 mat)
        {
            return new Matrix3
                (
                    mat.m11, mat.m21, mat.m31,
                    mat.m12, mat.m22, mat.m32,
                    mat.m13, mat.m23, mat.m33
                );
        }

        Matrix4 Transpose(Matrix4 mat)
        {
            return new Matrix4
                (
                    mat.m11, mat.m21, mat.m31, mat.m41,
                    mat.m12, mat.m22, mat.m32, mat.m42,
                    mat.m13, mat.m23, mat.m33, mat.m43,
                    mat.m14, mat.m24, mat.m34, mat.m44
                );
        }

        bool compare(float a, float b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a - b) > tolerance)
                return false;
            return true;
        }

        bool compare(Vector3 a, Vector3 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.X - b.X) > tolerance ||
                Math.Abs(a.Y - b.Y) > tolerance ||
                Math.Abs(a.Z - b.Z) > tolerance)
                return false;
            return true;
        }

        bool compare(Vector4 a, Vector4 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.X - b.X  ) > tolerance ||
                Math.Abs(a.Y - b.Y) > tolerance ||
                Math.Abs(a.Z - b.Z) > tolerance ||
                Math.Abs(a.W - b.W) > tolerance)
                return false;
            return true;
        }

        bool compare(Matrix3 a, Matrix3 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.m11 - b.m11) > tolerance || Math.Abs(a.m12 - b.m12) > tolerance || Math.Abs(a.m13 - b.m13) > tolerance ||
                Math.Abs(a.m21 - b.m21) > tolerance || Math.Abs(a.m22 - b.m22) > tolerance || Math.Abs(a.m23 - b.m23) > tolerance ||
                Math.Abs(a.m31 - b.m31) > tolerance || Math.Abs(a.m32 - b.m32) > tolerance || Math.Abs(a.m33 - b.m33) > tolerance)
                return false;
            return true;
        }

        bool compare(Matrix4 a, Matrix4 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.m11 - b.m11) > tolerance || Math.Abs(a.m12 - b.m12) > tolerance || Math.Abs(a.m13 - b.m13) > tolerance || Math.Abs(a.m14 - b.m14) > tolerance ||
                Math.Abs(a.m21 - b.m21) > tolerance || Math.Abs(a.m22 - b.m22) > tolerance || Math.Abs(a.m23 - b.m23) > tolerance || Math.Abs(a.m24 - b.m24) > tolerance ||
                Math.Abs(a.m31 - b.m31) > tolerance || Math.Abs(a.m32 - b.m32) > tolerance || Math.Abs(a.m33 - b.m33) > tolerance || Math.Abs(a.m34 - b.m34) > tolerance ||
                Math.Abs(a.m41 - b.m41) > tolerance || Math.Abs(a.m42 - b.m42) > tolerance || Math.Abs(a.m43 - b.m43) > tolerance || Math.Abs(a.m44 - b.m44) > tolerance)
                return false;
            return true;
        }

        [TestMethod]
        public void Vector3Addition()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            Vector3 v3c = v3a + v3b;

            Assert.IsTrue(compare(new Vector3(18.5f, -44.24f, 850), v3c));
        }

        [TestMethod]
        public void Vector4Addition()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            Vector4 v4c = v4a + v4b;

            Assert.IsTrue(compare(new Vector4(18.5f, -44.24f, 850, 1), v4c));
        }

        [TestMethod]
        public void Vector3Subtraction()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            Vector3 v3c = v3a - v3b;

            Assert.IsTrue(compare(new Vector3(8.5f, -52.22f, 874), v3c));
        }

        [TestMethod]
        public void Vector4Subtraction()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            Vector4 v4c = v4a - v4b;

            Assert.IsTrue(compare(new Vector4(8.5f, -52.22f, 874, -1), v4c));
        }

        [TestMethod]
        public void Vector3PostScale()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3c = v3a * 0.256f;

            Assert.IsTrue(compare(new Vector3(3.45600008965f, -12.3468809128f, 220.672012329f), v3c));
        }

        [TestMethod]
        public void Vector4PostScale()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4c = v4a * 4.89f;

            Assert.IsTrue(compare(new Vector4(66.0149993896f, -235.844696045f, 4215.1796875f, 0), v4c));
        }

        [TestMethod]
        public void Vector3PreScale()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3c = 0.256f * v3a;

            Assert.IsTrue(compare(new Vector3(3.45600008965f, -12.3468809128f, 220.672012329f), v3c));
        }

        [TestMethod]
        public void Vector4PreScale()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4c = 4.89f * v4a;

            Assert.IsTrue(compare(new Vector4(66.0149993896f, -235.844696045f, 4215.1796875f, 0), v4c));
        }

        [TestMethod]
        public void Vector3Dot()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            float dot3 = Vector3.DotProduct(v3a, v3b);

            Assert.AreEqual(dot3, -10468.9375f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector4Dot()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            float dot4 = Vector4.DotProduct(v4a, v4b);

            Assert.AreEqual(dot4, -10468.9375f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector3Cross()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            Vector3 v3c = Vector3.CrossProduct(v3a, v3b);

            Assert.IsTrue(compare(v3c, new Vector3(-2860.62011719f, 4472.00000000f, 295.01498413f)));
        }

        [TestMethod]
        public void Vector4Cross()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = new Vector4(5, 3.99f, -12, 1);
            Vector4 v4c = Vector4.CrossProduct(v4a, v4b);

            Assert.IsTrue(compare(v4c, new Vector4(-2860.62011719f, 4472.00000000f, 295.01498413f, 0)));
        }

        [TestMethod]
        public void Vector3Magnitude()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            float mag3 = v3a.Magnitude;

            Assert.AreEqual(mag3, 863.453735352f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector4Magnitude()
        {
            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            float mag4 = v4a.Magnitude;

            Assert.AreEqual(mag4, 863.453735352f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector3Normalise()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            v3a = Vector3.Normalize(v3a);

            Assert.IsTrue(compare(v3a, new Vector3(0.0156349f, -0.0558571f, 0.998316f)));
        }

        [TestMethod]
        public void Vector4Normalise()
        {
            Vector4 v4a = new Vector4(243, -48.23f, 862, 0);
            v4a = Vector4.Normalize(v4a);

            Assert.IsTrue(compare(v4a, new Vector4(0.270935f, -0.0537745f, 0.961094f, 0)));
        }

        [TestMethod]
        public void Matrix4SetRotateX()
        {
            Matrix4 m4a = new Matrix4();
            m4a = Transpose(Matrix4.CreateRotationX(4.5f));

            Assert.IsTrue(compare(m4a,
                new Matrix4(1, 0, 0, 0, 0, -0.210796f, -0.97753f, 0, 0, 0.97753f, -0.210796f, 0, 0, 0, 0, 1)));
        }

        [TestMethod]
        public void Matrix4SetRotateY()
        {
            Matrix4 m4b = new Matrix4();
            m4b = Transpose(Matrix4.CreateRotationY(-2.6f));

            Assert.IsTrue(compare(m4b,
                new Matrix4(-0.856889f, 0, 0.515501f, 0, 0, 1, 0, 0, -0.515501f, 0, -0.856889f, 0, 0, 0, 0, 1)));
        }

        [TestMethod]
        public void Matrix3SetRotate()
        {
            Matrix3 m3c = new Matrix3();
            m3c = Matrix3.CreateRotation(9.62f);

            Assert.IsTrue(compare(m3c,
                new Matrix3(-0.981005f, -0.193984f, 0, 0.193984f, -0.981005f, 0, 0, 0, 1)));
        }

        [TestMethod]
        public void Matrix4SetRotateZ()
        {
            Matrix4 m4c = new Matrix4();
            m4c = Transpose(Matrix4.CreateRotationZ(0.72f));

            Assert.IsTrue(compare(m4c,
                new Matrix4(0.751806f, 0.659385f, 0, 0, -0.659385f, 0.751806f, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)));
        }

        [TestMethod]
        public void Vector3MatrixTransform2()
        {
            Matrix3 m3c = new Matrix3();
            m3c = Transpose(Matrix3.CreateRotation(9.62f));

            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3c = m3c * v3a;

            Assert.IsTrue(compare(v3c,
                new Vector3(-22.5994224548f, 44.6950683594f, 862)));
        }

        [TestMethod]
        public void Vector4MatrixTransform()
        {
            Matrix4 m4b = new Matrix4();
            m4b = Matrix4.CreateRotationY(-2.6f);

            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = m4b * v4a;

            Assert.IsTrue(compare(v4b,
                new Vector4(-455.930236816f, -48.2299995422f, -731.678771973f, 0)));
        }

        [TestMethod]
        public void Vector4MatrixTransform2()
        {
            Matrix4 m4c = new Matrix4();
            m4c = Matrix4.CreateRotationZ(0.72f);

            Vector4 v4a = new Vector4(13.5f, -48.23f, 862, 0);
            Vector4 v4b = m4c * v4a;

            Assert.IsTrue(compare(v4b,
                new Vector4(41.951499939f, -27.3578968048f, 862, 0)));
        }

        [TestMethod]
        public void Matrix3Multiply()
        {
            Matrix3 m3b = new Matrix3();
            m3b = Matrix3.CreateTranslation(new Vector2(2,3));

            Matrix3 m3c = new Matrix3();
            m3c = Matrix3.CreateTranslation(new Vector2(3, 15));

            Matrix3 m4d = Transpose(m3b * m3c);

            Assert.IsTrue(compare(m4d,
                new Matrix3(1, 0, 0, 0, 1, 0, 5, 18, 1)));
        }

        [TestMethod]
        public void Matrix4Multiply()
        {
            Matrix4 m4b = new Matrix4();
            m4b = Matrix4.CreateRotationY(-2.6f);

            Matrix4 m4c = new Matrix4();
            m4c = Matrix4.CreateRotationZ(0.72f);

            Matrix4 m4d = Transpose(m4c * m4b);

            Assert.IsTrue(compare(m4d,
                new Matrix4(-0.644213855267f, -0.565019249916f, 0.515501439571f, 0, -0.659384667873f, 0.751805722713f, 0, 0, -0.387556940317f, -0.339913755655f, -0.856888711452f, 0, 0, 0, 0, 1)));
        }                   //m11              m21                m31           m41    m12             m22             m32 m42 m13               m23                 m33          m34 m14 m24 m34 m44                 

        [TestMethod]
        public void Vector3MatrixTranslation()
        {
            // homogeneous point translation
            Matrix3 m3b = Transpose(new Matrix3(1, 0, 0,
                                      0, 1, 0,
                                      55, 44, 1));

            Vector3 v3a = new Vector3(13.5f, -48.23f, 1);

            Vector3 v3b = m3b * v3a;

            Assert.IsTrue(compare(v3b, new Vector3(68.5f, -4.23f, 1)));
        }


        [TestMethod]
        public void Vector4MatrixTranslation()
        {
            // homogeneous point translation
            Matrix4 m4b = Transpose(new Matrix4(1, 0, 0, 0,
                                      0, 1, 0, 0,
                                      0, 0, 1, 0,
                                      55, 44, 99, 1));
            
            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 1);

            Vector4 v4c = m4b * v4a;
            Assert.IsTrue(compare(v4c, new Vector4(68.5f, -4.23f, 45, 1)));
        }

        [TestMethod]
        public void Vector4MatrixTranslation2()
        {
            // homogeneous point translation
            Matrix4 m4c = new Matrix4();
            m4c = Matrix4.CreateRotationZ(2.2f);
            m4c.m14 = 55; m4c.m24 = 44; m4c.m34 = 99; m4c.m44 = 1;

            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 1);

            Vector4 v4c = m4c * v4a;
            Assert.IsTrue(compare(v4c, new Vector4(86.0490112305f, 83.2981109619f, 45, 1)));
        }
        
        [TestMethod]
        public void Vector3MatrixTranslation3()
        {
            // homogeneous point translation
            Matrix3 m3b = Transpose(new Matrix3(1, 0, 0,
                                      0, 1, 0,
                                      55, 44, 1));

            Vector3 v3a = new Vector3(13.5f, -48.23f, 0);

            Vector3 v3b = m3b * v3a;

            Assert.IsTrue(compare(v3b, new Vector3(13.5f, -48.23f, 0)));
        }

        [TestMethod]
        public void Vector4MatrixTranslation3()
        {
            // homogeneous point translation
            Matrix4 m4b = Transpose(new Matrix4(1, 0, 0, 0,
                                      0, 1, 0, 0,
                                      0, 0, 1, 0,
                                      55, 44, 99, 1));

            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 0);

            Vector4 v4c = m4b * v4a;
            Assert.IsTrue(compare(v4c, new Vector4(13.5f, -48.23f, -54, 0)));
        }

        [TestMethod]
        public void Vector4MatrixTranslation4()
        {
            // homogeneous point translation
            Matrix4 m4c = new Matrix4();
            m4c = Matrix4.CreateRotationZ(2.2f);
            m4c.m14 = 55; m4c.m24 = 44; m4c.m34 = 99; m4c.m44 = 1;

            Vector4 v4a = new Vector4(13.5f, -48.23f, -54, 0);

            Vector4 v4c = m4c * v4a;
            Assert.IsTrue(compare(v4c, new Vector4(31.0490131378f, 39.2981109619f, -54, 0)));
        }

        
    }
}
