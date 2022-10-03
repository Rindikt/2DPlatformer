using System;
using UnityEngine;

public sealed class BulletView : MonoBehaviour 
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private CircleCollider2D _collider2D;

    [Header("Settings")]

    private float _radius = 0.3f;

    private float _groundLevel = 0f;

    private float _acceleration = -10.0f;


    public float Radius => _radius;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;

    public Rigidbody2D Rigidbody2D  => _rigidbody2D;
    public CircleCollider2D Collider2D => _collider2D;

    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetVisible(false);
        gameObject.SetActive(false);
    }

}

