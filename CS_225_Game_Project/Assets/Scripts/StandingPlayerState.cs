using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerState
{
    public void Enter(PlayerController player)
    {
        player.currentState = this;
    }

    public void Execute(PlayerController player)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // transition to duck
            DuckingPlayerState DUCKState = new DuckingPlayerState();
            DUCKState.Enter(player);
        }
    }
}