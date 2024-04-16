using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerStates PREVIOUS_STATE  {get; private set;}
    public static PlayerStates CURRENT_STATE {get; private set;}

    public static PlayerStates NEXT_STATE {get; private set;} 

    public PlayerStateMachine(PlayerCore PLAYER_CORE)
    {
        this.PLAYER_CORE = PLAYER_CORE;
        PREVIOUS_STATE = null;
        CURRENT_STATE = null;
        NEXT_STATE = null;
    }

    public void Update()
    {
        if(NEXT_STATE != null)
        {
            NEXT_STATE = null;
        } 

        if(CURRENT_STATE != null)
        {
            CURRENT_STATE.BASE_UPDATE_STATE(this);
        }
    }

    private PlayerCore PLAYER_CORE;
}
