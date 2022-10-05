using UnityEngine;
public  class TrollController :IFixedUpdate
{
    private EnemyTrollView _trollView;
    private SpriteAnimation _spriteAnimation;
    private bool _movingLeft;
    public TrollController(EnemyTrollView enemyTroll, SpriteAnimation spriteAnimation)
    {
        _spriteAnimation = spriteAnimation;
        _trollView = enemyTroll;
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_movingLeft)
        {
            if (_trollView.transform.position.x >= _trollView.LeftEdge.position.x)
                MoveInDerection(-1);

            else
                DirectoinChange();
        }
        else
        {
            if (_trollView.transform.position.x <= _trollView.RightEdge.position.x)
                MoveInDerection(1);
            else
                DirectoinChange();
        }
    }

    private void DirectoinChange()
    {
        _movingLeft = !_movingLeft;
    }
    private void MoveInDerection(int derection)
    {
        RunAnimation();
        _trollView.SpriteRenderer.flipX = derection < 0;
        _trollView.transform.position = new Vector2(_trollView.transform.position.x + Time.fixedDeltaTime * derection * _trollView.Speed, _trollView.transform.position.y);
    }


    private void RunAnimation()
    {
        _spriteAnimation.StartAnimation(_trollView.SpriteRenderer, Track.trollSummerRun, true, 9);
    }
}
