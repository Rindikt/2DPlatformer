using UnityEngine;
using System;

public class LiftView : MonoBehaviour
{
    public Action<Collision2D> OnCollisionEnter;

    [SerializeField]
    private Transform _anchor;

    public Transform Anchor => _anchor; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEnter?.Invoke(collision);
    }

}
