using UnityEngine;

public sealed class MoveTransform : IFixedUpdate
{
    private readonly CharacterView _characterView;
    private ContactsPoller _contactsPoller;
    private ControllerAnimator _cintrollerAnimator;
    private bool _ifDoubleJimp;

    public MoveTransform(CharacterView characterView, ControllerAnimator cintrollerAnimator/*, SpriteAnimation spriteAnimation*/)
    {
        _characterView = characterView;
        _cintrollerAnimator = cintrollerAnimator;
        _contactsPoller = new ContactsPoller(_characterView.Collider);
    }

    public void FixedUpdate()
    {
        _contactsPoller.Execute(); 
    }


    public void Move(float direction)
    {
        if (_contactsPoller.IsGround)
        {
            _cintrollerAnimator.Move(direction);
            _ifDoubleJimp = true;
        }
        else if (!_contactsPoller.IsGround)
        {
            _cintrollerAnimator.Jump();
        }

        var newVelocityX = 0f;

        if ((direction>0 && !_contactsPoller.HasRightContacts ) || (direction < 0 && !_contactsPoller.HasLeftContacts))
        {
            newVelocityX = Time.fixedDeltaTime * _characterView.RanSpeed * (direction<0?-1:1);
        }
        _characterView.Rigidbody.velocity = _characterView.Rigidbody.velocity.Change(x: newVelocityX);

    }

    public void Jump()
    {
        if ((_contactsPoller.IsGround && _characterView.Rigidbody.velocity.y<=_characterView.FlyTresh) || _ifDoubleJimp)
        {
            _characterView.Rigidbody.AddForce(Vector2.up * _characterView.JumpStartForce);
            _ifDoubleJimp = false;
        }

    }
}
