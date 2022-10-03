using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public sealed class CoinsManager : IDisposable
{
    private SpriteAnimation _spriteAnimation;
    private List<CoinView> _coinViews;
    private ScoreView _score;
    private int _scoreCoins;

    public int ScoreCoins  => _scoreCoins;

    public CoinsManager(List<CoinView> coinViews,SpriteAnimation spriteAnimation,ScoreView score)
    {
        _coinViews = coinViews;
        _score = score;
        _spriteAnimation = spriteAnimation;
        foreach (CoinView coinView in _coinViews)
        {
            coinView.OnLevelObjectContact += OnLevelObjectContact;
            var spriteRender = coinView.GetComponent<SpriteRenderer>();
            _spriteAnimation.StartAnimation(spriteRender, Track.coin, true, 5.0f);
        }
    }


    private void OnLevelObjectContact(CoinView contactView)
    {
        if (_coinViews.Contains(contactView))
        {
            _scoreCoins++;
            Score(ScoreCoins);
            _spriteAnimation.StopAnimation(contactView.GetComponent<SpriteRenderer>());
            contactView.gameObject.SetActive(false);
        }

    }
    public void Dispose()
    {
        foreach (CoinView coinView in _coinViews)
        {
            coinView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
    private void Score(int score)
    {
        _score.Score.text = ($"Coins: " + score);
    }
}
