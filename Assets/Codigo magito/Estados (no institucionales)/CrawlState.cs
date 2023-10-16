using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrawlState : MovementBaseState
{
    // En realidad es Crouch pero no se lo digas a nadie

    public override void EnterState(MovementStageManager movement)
    {
        movement.anim.SetBool("Crouching", true);
    }

    public override void UpdateState(MovementStageManager movement)
    {
        if(Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Run);
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(movement.dir.magnitude > 0.1f) ExitState(movement, movement.Idle);
            else ExitState(movement, movement.walk);

            if (movement.vInput < 0) movement.currentMoveSpeed = movement.CrouchBackSpeed;
            else movement.currentMoveSpeed = movement.CrouchSpeed;
        }
    }

    void ExitState(MovementStageManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Crouching", false);
        movement.SwichState(state);
    }
}
