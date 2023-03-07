using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class ParalaxController : MonoBehaviour
    {
        [SerializeField] private List<ParalaxObject> paralaxObjects;
        
        [SerializeField] private Transform cameraPosition;
        [SerializeField] private Vector3 prevCameraPosition;

        private float GetCameraDelta()
        {
            return cameraPosition.position.x - prevCameraPosition.x;
        }

        public void UpdateParalax()
        {
            float cDelta = GetCameraDelta();
            for (int i = 0; i < paralaxObjects.Count; i++)
            {
                ParalaxObject pObject = paralaxObjects[i];

                pObject.paraObject.position += new Vector3(cDelta * pObject.paralaxSpeed, 0, 0);
            }
        }

        private void Update()
        {
            UpdateParalax();
            
            prevCameraPosition = cameraPosition.position;
        }
    }
}