namespace HK.Basic.Services
{
    /// <summary>
    /// 计算辅助类
    /// </summary>
    public class MathHelper
    {
        public bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public double Divide(int x, int y)
        {
            return x / y;
        }

        public double Multiply(int x, int y)
        {
            return x * y;
        }

        public double GetDiscount(int type)
        {
            switch (type)
            {
                case 1:
                {
                    return 0.95;
                }
                case 2:
                {
                    return 0.9;
                }
                case 3:
                {
                    return 0.8;
                }
                default:
                {
                    return 0.98;
                }
            }
        }
    }
}
