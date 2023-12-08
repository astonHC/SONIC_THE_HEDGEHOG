/* COPYRIGHT (C) HARRY CLARK 2023 */

/* SONIC THE HEDGEHOG UNITY PROJECT */

/* THE FOLLOWING FILE PERTAINS TOWARDS THE MAIN FUNCTIONALITY OF SONIC'S MOVEMENT */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore;

public class SONIC_MAIN : MonoBehaviour
{
    public Rigidbody RIGIDBODY
    {
        get
        {
            return GetComponent<Rigidbody>();
        }
    }

    private SONIC_STATE STATE
    {
        get  
        {
            return GetComponent<SONIC_STATE>();
        }
    }

    private Vector3 FORWARD_VELOCITY
    {
        get
        {
            Vector3 NORMALISE = RIGIDBODY.velocity.normalized;
            NORMALISE.y += 0f;
            return NORMALISE;
        }
    }

    public void KEEP_VELOCITY()
    {
        KEEP_VELOCITY_TIME = VELOCITY_TIME_LEN;
        IS_KEEP_VELOCITY = true;
    }


    private void GROUND_PHYSICS()
    {
        Vector3 INPUT_NORMALISED = INPUT_DIRECTION.normalized;
        Vector3 BASE_NORMALISED = VECTOR.normalized;

        if(Vector3.Dot(INPUT_NORMALISED, BASE_NORMALISED) < -0.25f && VECTOR.magnitude > 20f)
        {
            IS_SKIDDING = true;
        } 
    }

    [SerializeField]
    [Header("Physics")]

    public Vector3 GROUND_NORMAL;
    public Vector3 INPUT_DIRECTION;

    public bool IS_SKIDDING;

    [HideInInspector]
    public Vector3 VECTOR;
    [HideInInspector]
    public Vector3 VECTOR_BASE;
    
    public static bool IS_KEEP_VELOCITY;
    public static float KEEP_VELOCITY_TIME;

    public static float VELOCITY_TIME_LEN;


}
