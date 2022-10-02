using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpriteAnimation : IDisposable
{

    private class Animation
    {
        public Track Track;
        public List<Sprite> Sprite;
        public bool Loop = false;
        public float Speed = 10;
        public float Counter = 0;
        public bool Sleeps;
        
        public void Update()
        {
            if (Sleeps) return;
            Counter +=Time.deltaTime * Speed;
            if (Loop)
            {
                while (Counter > Sprite.Count)
                {
                    Counter -=Sprite.Count;
                }
            }
            else if (Counter > Sprite.Count)
            {
                Counter = Sprite.Count - 1;
                Sleeps = true;
            }
        }
    }

    private SpriteAnimationsConfig _config;

    public SpriteAnimation(SpriteAnimationsConfig config)
    {
        _config = config;
    }

    private Dictionary<SpriteRenderer,Animation> _activeAnimation = new Dictionary<SpriteRenderer,Animation>();

    public void StartAnimation(SpriteRenderer spriteRenderer, Track track, bool loop, float speed)
    {
        if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
        {
            animation.Loop = loop;
            animation.Speed = speed;
            animation.Sleeps = false;
            if (animation.Track != track)
            {
                animation.Track = track;
                animation.Sprite = _config.Sequence.Find(sequence => sequence.Track == track).Sprites;
                animation.Counter = 0;
            }
        }
        else
        {
            _activeAnimation.Add(spriteRenderer, new Animation()
            {
                Track = track,
                Sprite = _config.Sequence.Find(sequence => sequence.Track == track).Sprites,
                Loop = loop,
                Speed = speed
            });
        }
    }

    public void StopAnimation(SpriteRenderer sprite)
    {
        if (_activeAnimation.ContainsKey(sprite))
        {
            _activeAnimation.Remove(sprite);
        }
    }
    public void Update()
    {
        foreach (var animation in _activeAnimation)
        {
            animation.Value.Update();
            animation.Key.sprite = animation.Value.Sprite[(int) animation.Value.Counter];
        }
    }

    public void Dispose()
    {
        _activeAnimation.Clear();
    }
}
