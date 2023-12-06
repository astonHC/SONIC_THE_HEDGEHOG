/* COPYRIGHT (C) HARRY CLARK 2023 */

/* SONIC THE HEDGEHOG UNITY PROJECT */

/* THE FOLLOWING FILE SERVES TO PROVIDE FUNCTIONALITY PERTAINING TOWARDS */
/* WHICH MOUTH MESH IS DISPLAYED IN RELATION TO THE POSITION AND ROTATION OF THE CAMERA */

/* THIS IS ONLY BECAUSE OF THE WAY IN WHICH SONIC TEAM USES DIFFERENT MESHES FOR THIS EXACT PURPOSE */

using System;
using UnityEngine;

public class SONIC_MOUTH : MonoBehaviour
{
    [System.Serializable]
    public class OBJECTS
    {
        [Header("MOUTH SETTINGS")]
        
        [SerializeField]
        private GameObject MOUTH_L;

        [SerializeField]
        private GameObject MOUTH_R;
        
        [SerializeField]
        private Transform CAMERA;

        public GameObject LEFT { get { return MOUTH_L; } }
        public GameObject RIGHT { get { return MOUTH_R; } }

        public Transform MAIN_CAMERA { get { return CAMERA; } }
    }

    [SerializeField]
    private OBJECTS OBJ;

    private void LateUpdate()
    {
        if(Vector3.SignedAngle(transform.up, OBJ.MAIN_CAMERA.forward, Vector3.up) <= 0f)
        {
            OBJ.LEFT.transform.localScale = Vector3.zero;
            OBJ.RIGHT.transform.localScale = Vector3.one;
            return;
        }

        OBJ.LEFT.transform.localScale = Vector3.one;
        OBJ.RIGHT.transform.localScale = Vector3.zero;
    }
}
