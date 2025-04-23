using UnityEngine;

public class RunState : NinjaState
{
    public RunState(NinjaController controller) : base(controller) { }

    public override void Enter()
    {
        animator.SetBool("isRunning", true);
    }

    public override void Exit()
    {
        animator.SetBool("isRunning", false);
    }

    public override void Update()
    {
        float moveInput = controller.GetMoveInput();

        if (moveInput != 0)
        {
            controller.Flip(moveInput);
        }

        if (!controller.IsMoving())
        {
            controller.ChangeState(new IdleState(controller));
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
