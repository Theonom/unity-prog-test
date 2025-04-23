using UnityEngine;

public class IdleState : NinjaState
{
    public IdleState(NinjaController controller) : base(controller) { }

    public override void Enter()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }

    public override void Exit() { }

    public override void Update()
    {
        if (controller.IsMoving())
        {
            controller.ChangeState(new RunState(controller));
        }
        if (controller.IsJumping())
        {
            controller.ChangeState(new JumpState(controller));
        }
        if (controller.IsAttacking())
        {
            controller.ChangeState(new AttackState(controller));
        }
        if (controller.IsHurt())
        {
            controller.ChangeState(new HurtState(controller));
        }
        if (controller.IsDead())
        {
            controller.ChangeState(new DieState(controller));
        }
    }
}
