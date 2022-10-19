using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    public class Control : MonoBehaviour
    {
        //静态量

        //基本数据
        public static ValueControlData Throttle = new ValueControlData(KeyCode.LeftShift, KeyCode.LeftControl, 0, 1);
        public static ValueControlData Pitch = new ValueControlData(KeyCode.W, KeyCode.S, -1, 1);
        public static ValueControlData Roll = new ValueControlData(KeyCode.D, KeyCode.A, -1, 1);
        public static ValueControlData Yaw = new ValueControlData(KeyCode.E, KeyCode.Q, -1, 1);
        //组件

        //生命周期

        //公开方法
        private void FixedUpdate()
        {
            Throttle.Monitor();
            Pitch.Monitor();
            Roll.Monitor();
            Yaw.Monitor();
        }
        //私有工具方法

        //实现接口
    }
}
