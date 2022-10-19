using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    [RequireComponent(typeof(Rigidbody))]
    public class AirDragPart : MonoBehaviour
    {
        //静态量

        //基本数据
        public bool debug;
        [Header("Z轴截面积")]
        public float ZSectionalArea;
        [Header("Z轴空气阻力系数")]
        public float ZAirDragCoefficient;
        [Header("X轴截面积")]
        public float XSectionalArea;
        [Header("X轴空气阻力系数")]
        public float XAirDragCoefficient;
        [Header("Y轴截面积")]
        public float YSectionalArea;
        [Header("Y轴空气阻力系数")]
        public float YAirDragCoefficient;
        //组件
        private Rigidbody rig;
        //生命周期
        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            rig.AddForce(GetFriction());
        }
        //公开方法
        private Vector3 GetFriction()
        {
           
            Vector3 rv = rig.transform.InverseTransformVector(rig.velocity);
            float fx = -0.5f * XAirDragCoefficient * XSectionalArea * rv.x * rv.x;
            float fy = -0.5f * YAirDragCoefficient * YSectionalArea * rv.y * rv.y;
            float fz = -0.5f * ZAirDragCoefficient * ZSectionalArea * rv.z * rv.z;
            if (debug)
                Debug.Log(name + $"'s Friction {fx},{fy},{fz}");
            return rig.transform.TransformVector(new Vector3(fx, fy, fz));
            
        }
        //私有工具方法

        //实现接口
    }
}
