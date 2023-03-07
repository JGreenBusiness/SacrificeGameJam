using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class AIManagerSingleton : MonoBehaviour
    {
        public List<AIBase> ai;
        
        public static AIManagerSingleton instance;

        private void Awake()
        {
            if (instance != null)
                return;

            instance = this;
        }


        private void FixedUpdate()
        {
            for (int i = 0; i < ai.Count; i++)
            {
                ai[i].Move(Time.fixedDeltaTime);
            }
        }
    }
}