using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStageManager movement)
    {
        
    }

    public override void UpdateState(MovementStageManager movement)
    {
        if(movement.dir.magnitude < 0.1f)
        {
            if(Input.GetKey(KeyCode.LeftShift)) movement.SwichState(movement.Run);
            else movement.SwichState(movement.walk);
        }
        if(Input.GetKeyDown(KeyCode.C)) movement.SwichState(movement.Crawl);
    }

}
