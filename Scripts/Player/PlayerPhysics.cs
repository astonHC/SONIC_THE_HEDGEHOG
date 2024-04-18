using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    public void FIX_VELOCITY_INIT()
    {
         this.RIGIDBODY.velocity = this.FIXED_VELOCITY;
         this.IS_VELOCITY_FIXED = false;
    }

    public void SET_FIXED_VELOCITY(Vector3 VELOCITY)
    {
        FIXED_VELOCITY = VELOCITY;
    }

    private void DETECT_GROUND()
    {
        if(PLAYER_CORE.STATES.CURRENT_STATE.IS_DETECTED_GROUND)
        {
            return;
        }

        if(GROUNDED || (!GROUNDED && GET_NORMAL_SPEED() <= 4f))
        {

        }
    }

    private float GET_NORMAL_SPEED()
    {
        return Vector3.Dot(GRAVITY_DIR, RIGIDBODY.velocity);
    }

    [SerializeField]
    private PlayerCore PLAYER_CORE;

    public Rigidbody RIGIDBODY;

    public CapsuleCollider CAPSULE;

    [SerializeField]
    private static Vector3 GRAVITY_DIR = Vector3.up;

    [SerializeField]
    private float RAYCAST_DIRECTION_BASE;
    [SerializeField]
    private float GROUND_OFFSET = 0.025f;

    [SerializeField]
    private float MAX_SPEED;

    [SerializeField]
    private float MAX_ANGLE;

    [SerializeField]
    private float MAX_GROUND_ANGLE;

    [SerializeField]
    private float SLOPE_NORMAL_SPEED;

    [SerializeField]
    private float SLOPE_MIN_LAT;

    private bool GROUNDED;
    private float GROUND_ANGLE;

    private float INPUT_MAG;
    private Vector3 TRANSFORM_NORMAL;
    private Vector3 MOVEMENT_INPUT = Vector3.zero;
    private Vector3 RAW_INPUT = Vector3.zero;

    private Vector3 GROUND_NORMAL;
    private Vector3 GROUND_NORMAL_PREV;

    private bool IS_VELOCITY_FIXED;
    private Vector3 FIXED_VELOCITY;


}
