using UnityEngine;

public class JumpState : NinjaState
{
    private float attackDuration = 1.0f;
    private float attackTimer;

    public JumpState(NinjaController controller) : base(controller) { }

    public override void Enter()
    {
        animator.SetBool("isJumping", true);
        attackTimer = attackDuration;

        Vector2 jumpForce = new Vector2(0f, controller.jumpForce);

        controller.rig.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        animator.SetBool("isJumping", false);
    }

    public override void Update()
    {
        attackTimer -= Time.deltaTime;
        float moveInput = controller.GetMoveInput();

        if (moveInput != 0)
        {
            controller.Flip(moveInput);
        }

        if (!controller.IsJumping() && attackTimer <= 0f)
        {
            controller.ChangeState(new IdleState(controller));
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
