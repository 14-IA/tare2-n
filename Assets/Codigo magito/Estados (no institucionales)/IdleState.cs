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
<<<<<<< HEAD
        if(movement.dir.magnitude > 0.1f)
=======
        if(movement.dir.magnitude < 0.1f)
>>>>>>> 0f47f2a62122153b0cb620096b7c4c88e398360d
        {
            if(Input.GetKey(KeyCode.LeftShift)) movement.SwichState(movement.Run);
            else movement.SwichState(movement.walk);
        }
<<<<<<< HEAD
        if(Input.GetKeyDown(KeyCode.Z)) movement.SwichState(movement.Crawl); 
=======
        if(Input.GetKeyDown(KeyCode.C)) movement.SwichState(movement.Crawl);
>>>>>>> 0f47f2a62122153b0cb620096b7c4c88e398360d
    }

}
