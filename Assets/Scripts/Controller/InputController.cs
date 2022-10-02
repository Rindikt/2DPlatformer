using UnityEngine;

public sealed class InputController : IFixedUpdate
{
    public InputHorizontal _inputHorizontal;
    public InputVertical _inputVertical;
    public InputJump _inputJump;

    public InputController()
    {
        _inputHorizontal = new InputHorizontal();
        _inputVertical = new InputVertical();
        _inputJump = new InputJump();
    }

    public void FixedUpdate()
    {
        _inputHorizontal.Execute();
        _inputVertical.Execute();
        _inputJump.Execute();
    }
}