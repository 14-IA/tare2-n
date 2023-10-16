using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementStageManager movement)
    {
        movement.anim.SetBool("walking", true);
    }

    public override void UpdateState(MovementStageManager movement)
    {
        if(Input.GetKey(KeyCode.LeftShift)) movement.SwichState(movement.currentState);
        else if(Input.GetKeyDown(KeyCode.LeftShift)) ExitState(movement, movement.Crawl);
        else if(movement.dir.magnitude > 0.1f) ExitState(movement, movement.currentState);

        if(movement.vInput < 0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed = movement.WalkSpeed;
    }

    void ExitState(MovementStageManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("walking", false);
        movement.SwichState(state);
    }
}
