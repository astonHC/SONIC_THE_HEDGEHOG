using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        if(NEXT_STATE != null) NEXT_STATE = null;

        if(CURRENT_STATE != null) CURRENT_STATE.BASE_UPDATE_STATE(this);
    }

    public void SET_STATE(PlayerStates STATE)
    {
        if(STATE == null) return;

        NEXT_STATE = STATE;

        if(CURRENT_STATE != null)
        {
            PREVIOUS_STATE = CURRENT_STATE;
            PREVIOUS_STATE.BASE_EXIT_STATE(this);
        }

        CURRENT_STATE = NEXT_STATE;
        CURRENT_STATE.BASE_ENTER_STATE(this);
    }

    private PlayerCore PLAYER_CORE;
}
