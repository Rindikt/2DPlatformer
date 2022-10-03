
public sealed class PlayerController : IFixedUpdate
{
    public Health _health;
    private InputController _inputController;
    private MoveTransform _moveTransform;
    private ControllerAnimator _cintrollerAnimator;
    CharacterView _charecterView;
    public PlayerController(InputController inputController, CharacterView charecterView, SpriteAnimation spriteAnimator)
    {
        _charecterView = charecterView;
        _cintrollerAnimator = new ControllerAnimator(charecterView, spriteAnimator);
        _inputController = inputController;
        _moveTransform = new MoveTransform(charecterView, _cintrollerAnimator);
        _inputController._inputHorizontal.AxisOnChange += _moveTransform.Move;
        _inputController._inputJump.OnClickJump += _moveTransform.Jump;
        _health = new Health(charecterView.MaxHealPoint);
        _charecterView.OnGetDamage += _health.GetDamage;
    }

    public void FixedUpdate()
    {
        _moveTransform.FixedUpdate();
    }

    public void Dispose()
    {
        _inputController._inputHorizontal.AxisOnChange -= _moveTransform.Move;
        _inputController._inputJump.OnClickJump -= _moveTransform.Jump;
        _charecterView.OnGetDamage -= _health.GetDamage;
    }
}

