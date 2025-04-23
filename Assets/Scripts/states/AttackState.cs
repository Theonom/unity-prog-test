using UnityEngine;

public class AttackState : NinjaState
{
    private float attackDuration = 1.0f;
    private float attackTimer;

    public AttackState(NinjaController controller) : base(controller) { }

    public override void Enter()
    {
        animator.SetTrigger("isAttacking");
        attackTimer = attackDuration;
        controller.canMove = false;
    }

    public override void Exit()
    {
        animator.SetBool("isJumping", false);
        controller.canMove = true;
    }

    public override void Update()
    {
        attackTimer -= Time.deltaTime;

        if (!controller.IsJumping() && attackTimer <= 0f)
        {
            controller.ChangeState(new IdleState(controller));
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
