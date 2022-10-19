using System;
using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    ///<summary>
    ///
    ///</summary>
    public struct RangeFloat : IEquatable<RangeFloat>
    {

        //静态量
        public static readonly RangeFloat Zero2One = new RangeFloat(0, 1);
        //基本数据

        /// <summary>
        /// 大值
        /// </summary>
        public float Max { get; private set; }

        /// <summary>
        /// 小值
        /// </summary>
        public float Min { get; private set; }

        /// <summary>
        /// 范围
        /// </summary>
        public float Range => Max - Min;

        //构造函数
        public RangeFloat(float num1, float num2)
        {
            Max = Mathf.Max(num1, num2);
            Min = Mathf.Min(num1, num2);
        }

        //公开方法
        public bool InRange(float value)
        {
            if (value >= Min && value <= Max)
                return true;
            return false;
        }
        public float Clamp(float value)
        {
            if (InRange(value))
                return value;
            return value > Max ? Max : Min;
        }
        //实现接口
        public override bool Equals(object obj)
        {
            return obj is RangeFloat @float && Equals(@float);
        }

        public bool Equals(RangeFloat other)
        {
            return Max == other.Max &&
                   Min == other.Min;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Max, Min);
        }

        public static bool operator ==(RangeFloat left, RangeFloat right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RangeFloat left, RangeFloat right)
        {
            return !(left == right);
        }
    }
}
