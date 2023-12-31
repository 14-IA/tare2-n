using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovementStageManager movement)
    {
        movement.anim.SetBool("Running", true);
    }

    public override void UpdateState(MovementStageManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ExitState(movement, movement.walk);
        }
        else if (movement.dir.magnitude > 0.1f)
        {
            ExitState(movement, movement.Idle);
        }
        else if (movement.vInput < 0)
        {
            movement.currentMoveSpeed = movement.RunBackSpeed;
        }
        else
        {
            movement.currentMoveSpeed = movement.RunSpeed;
        }

        if (movement.dir.magnitude < 0.1f)
        {
            ExitState(movement, movement.Idle);
        }
    }

    void ExitState(MovementStageManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwichState(state);
    }
}
