using System;
using UnityEngine;


public sealed class CoinView : MonoBehaviour 
{
    public Action<CoinView> OnLevelObjectContact { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var levelObject = collision.gameObject.GetComponent<CharacterView>();
        if (levelObject != null)
        {
                    OnLevelObjectContact?.Invoke(this);
        }
            
    }
}
