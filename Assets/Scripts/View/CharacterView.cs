using UnityEngine;
using System;

public sealed class CharacterView : MonoBehaviour
{
    public event Action<float> OnGetDamage;

    [SerializeField] 
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private Collider2D _collider;

    [Header("Settings")]
    [SerializeField]
    private float _ranSpeed = 10.0f;

    [SerializeField]
    private float _animationSpeed = 3.0f;

    [SerializeField]
    private float _jumpStartForce = 2.0f;

    [SerializeField]
    private float _moveThresh = 0.1f;

    [SerializeField]
    private float _flyTresh = 0.4f;

    [SerializeField]
    private float _groundLevel = 0.5f;

    [SerializeField]
    private float _acceleration = -10.0f;

    [SerializeField]
    private float _maxHealPoint = 3.0f;




    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public float RanSpeed => _ranSpeed;
    public float AnimationSpeed => _animationSpeed;
    public float JumpStartForce => _jumpStartForce;
    public float MoveThresh => _moveThresh;
    public float FlyTresh => _flyTresh;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;

    public Rigidbody2D Rigidbody  => _rigidbody;
    public Collider2D Collider  => _collider;

    public float MaxHealPoint  => _maxHealPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Weapon weapon))
        {
            OnGetDamage?.Invoke(weapon.Demage);
        }
        
    }

}
