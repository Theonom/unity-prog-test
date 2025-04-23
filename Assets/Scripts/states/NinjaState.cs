using UnityEngine;

public abstract class NinjaState
{
    protected NinjaController controller;
    protected Animator animator;

    public NinjaState(NinjaController controller)
    {
        this.controller = controller;
        this.animator = controller.GetComponent<Animator>();
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
