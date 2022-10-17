using UnityEngine;

namespace Flight
{
    [RequireComponent(typeof(Rigidbody))]
    public class Wing : MonoBehaviour
    {
        //静态量
        public const float AirDensity = 1.2f;
        
        //基本数据
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
            rig.AddForce(GetLiftForce(rig.velocity));
        }
        //方法
        //获取升力
        private Vector3 GetLiftForce(Vector3 velovity)
        {
            Vector3 rv = transform.InverseTransformVector(velovity);
            float lengthwayAttackAngle = Vector3.SignedAngle(Vector3.forward, new Vector3(0, rv.y, rv.z), Vector3.right);
            float ly = rv.z * rv.z * AirDensity * Area * LengthwayLCBase * LengthwayAttackAngle_LCMultiplayer_Curve.Evaluate(lengthwayAttackAngle);
            float crosswisewayAttackAngle = Vector3.SignedAngle(Vector3.right, new Vector3(rv.x, rv.y), Vector3.forward);
            ly += rv.x * rv.z * AirDensity * Area * CrosswiseLCBase * CrosswiseAttackAngle_LCMultiplayer_Curve.Evaluate(crosswisewayAttackAngle);
            return transform.TransformVector(Vector3.up * ly);
        }
    }
}
