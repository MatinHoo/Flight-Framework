using System;
using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    ///<summary>
    ///
    ///</summary>
    public class ValueControlData
    {
        //静态量

        //基本数据
        private float _value;
        public float Value => _value;
        public float ValueChangeRate = 3f / 50f;
        public bool AutoRecover = true;
        public bool Pause;
        public KeyCode RiseKey;
        public KeyCode ReduceKey;
        public event Action<float> ValueChangedEvent;
        public RangeFloat Range;
        //组件

        //构造函数
        public ValueControlData(KeyCode riseKey, KeyCode reduceKey, float minValue, float maxValue)
        {
            RiseKey = riseKey;
            ReduceKey = reduceKey;
            Range = new RangeFloat(minValue, maxValue);
        }

        //公开方法
        public void Monitor()
        {
            if (!Pause)
            {
                if (Input.GetKey(RiseKey))
                {
                    SetValue(Value + ValueChangeRate);
                }
                else if(Input.GetKey(ReduceKey))
                {
                    SetValue(Value - ValueChangeRate);
                }
                else 
                {
                    if(AutoRecover)
                    {
                        if(Mathf.Abs(Value)>ValueChangeRate)
                        {
                            if (Value > 0)
                                SetValue(Value - ValueChangeRate);
                            else
                                SetValue(Value + ValueChangeRate);
                        }
                        else
                        {
                            SetValue(0);
                        }
                    }
                }
            }
        }
        public void SetValue(float value)
        {
            value = Range.Clamp(value);
            if (Value == value)
                return;
            _value = value;
            ValueChangedEvent?.Invoke(Value);
        }
        //私有工具方法

        //实现接口
    }
}
