using UnityEngine;

public sealed class InputController : IFixedUpdate
{
    public InputHorizontal _inputHorizontal;
    public InputVertical _inputVertical;
    public InputJump _inputJump;
    public InputButtonE _inputButtonE;

    public InputController()
    {
        _inputHorizontal = new InputHorizontal();
        _inputVertical = new InputVertical();
        _inputJump = new InputJump();
        _inputButtonE = new InputButtonE();
    }

    public void FixedUpdate()
    {
        _inputHorizontal.Execute();
        _inputVertical.Execute();
        _inputJump.Execute();
        _inputButtonE.Execute();
    }
}