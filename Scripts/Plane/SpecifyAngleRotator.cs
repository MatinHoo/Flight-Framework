using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    [RequireComponent(typeof(ConfigurableJoint))]
    public class SpecifyAngleRotator : ControllablePart
    {
        //静态量

        //基本数据
        private float jointAngle => -Vector3.SignedAngle(transform.parent.forward, transform.forward, transform.right);
        private float targetAngle => MaxAngle * value;
        [Header("最大角度")]
        public float MaxAngle;
        [Header("旋转角速度")]
        public float Speed;
        [Header("是否软的")]
        public bool Floopy;
        //组件
        private Rigidbody rig;
        private Rigidbody AttachedBody => joint.connectedBody;
        private ConfigurableJoint joint;
        //生命周期
        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
            joint = GetComponent<ConfigurableJoint>();
        }
        protected override void Start()
        {
            base.Start();
        }
        protected void FixedUpdate()
        {
            if (!Floopy)
            {
                if (Mathf.Abs(jointAngle - targetAngle) < Speed * Time.fixedDeltaTime)
                {
                    joint.targetRotation = Quaternion.Euler(targetAngle, 0, 0);
                }
                else
                {
                    if (jointAngle - targetAngle < 0)
                    {
                        joint.targetRotation = Quaternion.Euler(jointAngle + Speed * Time.fixedDeltaTime, 0, 0);
                    }
                    else
                    {
                        joint.targetRotation = Quaternion.Euler(jointAngle - Speed * Time.fixedDeltaTime, 0, 0);
                    }
                }
            }
        }
        private void OnJointBreak(float breakForce)
        {
            enabled = false;
        }
        //公开方法

        //私有工具方法

        //实现接口
    }
}
