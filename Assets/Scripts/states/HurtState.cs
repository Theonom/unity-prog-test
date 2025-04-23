using UnityEngine;

public class HurtState : NinjaState
{
    private float attackDuration = 1.0f;
    private float attackTimer;

    public HurtState(NinjaController controller) : base(controller) { }

    public override void Enter()
    {
        animator.SetTrigger("isHurt");
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
        if (controller.IsDead())
        {
            controller.ChangeState(new DieState(controller));
        }
    }
}
