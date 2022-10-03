using UnityEngine;

public sealed class ControllerAnimator
{
    private CharacterView _charecterView;
    private SpriteAnimation _spriteAnimator;

    public ControllerAnimator(CharacterView charecterView, SpriteAnimation spriteAnimator)
    {
        _charecterView = charecterView;
        _spriteAnimator = spriteAnimator;
        Idle();
    }

    public void Move(float derection)
    {
        if (!Mathf.Approximately(derection, 0))
        {
            Run();

            _charecterView.SpriteRenderer.flipX = derection < 0;
        }
        else
        {
            Idle();
        }

    }

    public void Idle()
    {
        _spriteAnimator.StartAnimation(_charecterView.SpriteRenderer, Track.idle, true, 3.5f);
    }

    public void Run()
    {
        _spriteAnimator.StartAnimation(_charecterView.SpriteRenderer, Track.run, true, 10f);
    }
    public void Jump()
    {
        _spriteAnimator.StartAnimation(_charecterView.SpriteRenderer, Track.jump, false, 3f);
    }

    public void Dead()
    {
        _spriteAnimator.StartAnimation(_charecterView.SpriteRenderer, Track.dead, true, 3.5f);
    }

    public void Attack()
    {
        _spriteAnimator.StartAnimation(_charecterView.SpriteRenderer, Track.attack, true, 3f);
    }
}