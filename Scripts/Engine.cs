using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    public class Engine : MonoBehaviour
    {
        //基本数据
        public float PitchTorque;
        public float RollTorque;
        public Rigidbody attachedBody;
        public float Force;
        //组件

        //生命周期
        private void Awake()
        {
            if(!attachedBody)
            {
                Debug.Log("No attachedBody");
            }
        }
        private void FixedUpdate()
        {
            attachedBody.AddForce(attachedBody.transform.forward * Force);
        }
        private void Update()
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                Force += 50;
            }
            else if(Input.GetKey(KeyCode.LeftControl))
            {
                Force -= 50;
            }
        }
        //公开方法

        //私有工具方法

        //实现接口
    }
}
