using UnityEngine;

public class DieState : NinjaState
{
    public DieState(NinjaController controller) : base(controller) { }

    public override void Enter()
    {
        animator.SetTrigger("isDie");

        controller.enabled = false;
        controller.rig.linearVelocity = Vector2.zero;
    }

    public override void Exit()
    {  }

    public override void Update()
    {  }
}
