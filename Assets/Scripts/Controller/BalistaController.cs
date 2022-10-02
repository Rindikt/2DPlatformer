using UnityEngine;
using System.Collections.Generic;


public sealed class BalistaController : IExecute
{
    private BalistaView _balistaView;
    private float _reloadin;
    private bool _isaVailable;
    private List<Bullet> _bullets = new List<Bullet>();

    private int _currentIndex;
    private Transform _charecter;

    public BalistaController(BalistaView balistaView, Transform charecter)
    {
        _balistaView = balistaView;
        _charecter = charecter;
        foreach (var b in _balistaView.BulletViews)
        {
            _bullets.Add(new Bullet(b));
        }

        _reloadin = _balistaView.Reload;
    }

    public void Execute()
    {
        var distance = (_balistaView.transform.position - _charecter.position).magnitude;
        if (distance < _balistaView.Radius)
        {
            Rotate();
            if (_isaVailable)
            {
                if (_reloadin == 0)
                {
                    Attack(CheckDirection());
                    _reloadin = _balistaView.Reload;
                }
                _reloadin = _reloadin > 0 ? _reloadin -= 1 * Time.deltaTime : _reloadin = 0;

            }
        }
    }

    private void Rotate()
    {
        var dir = _charecter.position - _balistaView.transform.position;
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        _isaVailable = true;
        if (angle > 90)
        {
            _isaVailable = false;
            angle = 90;
        }
        if (angle < -90)
        {
            _isaVailable = false;
            angle = -90;
        }

        var a = Quaternion.AngleAxis(angle, Vector3.back);
        _balistaView.transform.rotation = a;

    }

    private void Attack(Vector3 direction)
    {
        _bullets[_currentIndex].Throw(_balistaView.transform.position, direction * 5.0f);
    }
    private Vector3 CheckDirection()
    {
        return _charecter.position - _balistaView.transform.position;
    }

}
