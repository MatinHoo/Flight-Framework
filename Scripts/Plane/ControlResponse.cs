using System.Collections.Generic;
using UnityEngine;

namespace Flight
{
    public enum ControlResponse
    {
        /// <summary>
        /// 无响应
        /// </summary>
        NoResponse,
        /// <summary>
        /// 节流阀正向
        /// </summary>
        Throttle,
        /// <summary>
        /// 节距
        /// </summary>
        Pitch,
        /// <summary>
        /// 节距反向
        /// </summary>
        Pitch_Inverse,
        /// <summary>
        /// 滚转
        /// </summary>
        Roll,
        /// <summary>
        /// 滚转反向
        /// </summary>
        Roll_Inverse,
        /// <summary>
        /// 偏移
        /// </summary>
        Yaw,
        /// <summary>
        /// 偏移反向
        /// </summary>
        Yaw_Inverse,
    }
}
