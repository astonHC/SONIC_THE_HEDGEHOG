using System;
using System.Collections;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public void ON_UPDATE_STATE(PlayerStateMachine STATE)
    {
    }

    public void BASE_UPDATE_STATE(PlayerStateMachine STATE)
    {
        ON_UPDATE_STATE(STATE);
    }

    public class StateJump : PlayerStates
    {
        public static void OnEnterState()
        {
            
        }
    }
}
