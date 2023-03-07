using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ParalaxController : MonoBehaviour
    {
        [SerializeField] private List<Transform> paralaxObjects;
        [SerializeField] private Transform cameraPosition;
    }
}