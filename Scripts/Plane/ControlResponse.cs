using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    public enum ControlResponse
    {
        /// <summary>
        /// ����Ӧ
        /// </summary>
        NoResponse,
        /// <summary>
        /// ����������
        /// </summary>
        Throttle,
        /// <summary>
        /// �ھ�
        /// </summary>
        Pitch,
        /// <summary>
        /// �ھ෴��
        /// </summary>
        Pitch_Inverse,
        /// <summary>
        /// ��ת
        /// </summary>
        Roll,
        /// <summary>
        /// ��ת����
        /// </summary>
        Roll_Inverse,
        /// <summary>
        /// ƫ��
        /// </summary>
        Yaw,
        /// <summary>
        /// ƫ�Ʒ���
        /// </summary>
        Yaw_Inverse,
    }
}
