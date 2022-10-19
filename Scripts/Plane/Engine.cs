using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    public class Engine : MonoBehaviour
    {
        //静态量

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
            if(Input.GetKey(KeyCode.W))
            {
                attachedBody.AddTorque(attachedBody.transform.right * PitchTorque);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                attachedBody.AddTorque(-attachedBody.transform.right * PitchTorque);
            }
            if (Input.GetKey(KeyCode.A))
            {
                attachedBody.AddTorque(attachedBody.transform.forward * RollTorque);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                attachedBody.AddTorque(-attachedBody.transform.forward * RollTorque);
            }
        }
        //公开方法

        //私有工具方法

        //实现接口
    }
}
