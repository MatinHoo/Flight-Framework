using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    [RequireComponent(typeof(Rigidbody))]
    public class Wing : MonoBehaviour
    {
        //静态量

        //基本数据
        public bool debug;
        [Header("机翼面积")]
        public float Area;
        [Header("纵向升力系数基础值")]
        public float LengthwayLCBase;
        [Header("纵向攻角-升力系数乘数关系曲线")]
        public AnimationCurve LengthwayAttackAngle_LCMultiplayer_Curve;
        [Header("横向升力系数基础值")]
        public float CrosswiseLCBase;
        [Header("横向攻角-升力系数乘数关系曲线")]
        public AnimationCurve CrosswiseAttackAngle_LCMultiplayer_Curve;


        //组件
        private Rigidbody rig;
        //生命周期
        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            rig.AddForce(GetLiftForce());
        }
        //公开方法

        //私有工具方法
        private Vector3 GetLiftForce()
        {
            Vector3 rv = transform.InverseTransformVector(rig.velocity);
            float lengthwayAttackAngle = Vector3.SignedAngle(Vector3.forward, new Vector3(0, rv.y, rv.z), Vector3.right);
            float ly = 0.5f * rv.z * rv.z * AirPhysics.AirDensity * Area * LengthwayLCBase * LengthwayAttackAngle_LCMultiplayer_Curve.Evaluate(lengthwayAttackAngle);
            float crosswisewayAttackAngle = Vector3.SignedAngle(Vector3.right, new Vector3(rv.x, rv.y), Vector3.forward);
            ly += 0.5f * rv.x * rv.z * AirPhysics.AirDensity * Area * CrosswiseLCBase * CrosswiseAttackAngle_LCMultiplayer_Curve.Evaluate(crosswisewayAttackAngle);
            if(debug)
            {
                Debug.Log(name + $"'s LiftForce {ly}");
            }
            return transform.TransformVector(Vector3.up * ly);
        }
        //实现接口
    }
}
