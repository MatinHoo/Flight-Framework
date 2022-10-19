using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    public abstract class ControllablePart : MonoBehaviour
    {
        //静态量

        //基本数据
        [SerializeField]
        protected ControlResponse _response;
        public ControlResponse Response => _response;
        [SerializeField][Range(-1,1)]
        protected float value;
        //组件

        //生命周期
        protected virtual void Start()
        {
            switch (Response)
            {
                case ControlResponse.NoResponse:
                    break;
                case ControlResponse.Throttle:
                    Control.Throttle.ValueChangedEvent += SetValue;
                    break;
                case ControlResponse.Pitch:
                    Control.Pitch.ValueChangedEvent += SetValue;
                    break;
                case ControlResponse.Pitch_Inverse:
                    Control.Pitch.ValueChangedEvent += SetValueInverse;
                    break;
                case ControlResponse.Roll:
                    Control.Roll.ValueChangedEvent += SetValue;
                    break;
                case ControlResponse.Roll_Inverse:
                    Control.Roll.ValueChangedEvent += SetValueInverse;
                    break;
                case ControlResponse.Yaw:
                    Control.Yaw.ValueChangedEvent += SetValue;
                    break;
                case ControlResponse.Yaw_Inverse:
                    Control.Yaw.ValueChangedEvent += SetValueInverse;
                    break;
                default:
                    break;
            }
        }
        //公开方法
        public virtual void SetValue(float value)
        {
            this.value = value;
        }
        
        //私有工具方法
        protected virtual void SetValueInverse(float value)
        {
            this.value = -value;
        }
        //实现接口
    }
}
