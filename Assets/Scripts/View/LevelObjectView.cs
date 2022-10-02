using System;
using UnityEngine;


public sealed class LevelObjectView : MonoBehaviour
{
    public event Action OnLevelObjectContact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var levelObject = collision.gameObject.GetComponent<CharacterView>();
        if (levelObject != null)
        {
            OnLevelObjectContact?.Invoke();
        }
    }
}
