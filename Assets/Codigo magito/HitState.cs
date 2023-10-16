using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        if(aim != null && aim.anim != null) { 
            aim.anim.SetBool("nombre de la animacion de disparo", false);
        }
    }

    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKey(KeyCode.Mouse1)) aim.SwitchState(aim.Aim);
    }
}
