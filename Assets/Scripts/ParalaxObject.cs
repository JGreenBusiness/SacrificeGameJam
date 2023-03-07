using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ParalaxObject : MonoBehaviour
    {
        /// <summary>
        /// The Object to be moved
        /// </summary>
        public Transform paraObject;
        
        /// <summary>
        /// The speed the objects moves at relative to the camera's speed.
        /// 1 is the same as the camera, -1 is the opposite direction of the camera, 2 is faster than the camera.
        /// </summary>
        [Range(-2, 2)] public float paralaxSpeed;

        private void Awake()
        {
            paraObject = transform;
        }
    }
}