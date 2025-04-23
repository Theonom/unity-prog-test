using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NinjaController : MonoBehaviour
{
    private NinjaState currentState;

    public bool canMove = true;
    public float jumpForce = 8f;
    public float moveSpeed = 5f;
    public Rigidbody2D rig;
    public Collider2D coll;
    public LayerMask ground;
    private Vector2 input;
    private bool facingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        currentState?.Update();
    }

    public void ChangeState(NinjaState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public bool IsMoving() => Mathf.Abs(input.x) > 0.1f; 
    public bool IsJumping() => Input.GetKeyDown(KeyCode.W) && coll.IsTouchingLayers(ground);
    public bool IsAttacking() => Input.GetKeyDown(KeyCode.Return);
    public bool IsHurt() => Input.GetKey(KeyCode.RightShift);
    public bool IsDead() => Input.GetKey(KeyCode.RightControl);

    private void FixedUpdate()
    {
        if (canMove)
        {
            rig.linearVelocity = new Vector2(input.x * moveSpeed, rig.linearVelocity.y);
        }
    }

    public float GetMoveInput()
    {
        return input.x;
    }

    public void Flip(float direction)
    {
        if ((direction > 0 && !facingRight) || (direction < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
