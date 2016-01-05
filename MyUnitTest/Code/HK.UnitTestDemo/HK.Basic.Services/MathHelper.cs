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
    }
}
