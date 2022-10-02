using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpriteAnimationsConfig",menuName = "Config/SpriteAnimationsConfig",order =1)]
public class SpriteAnimationsConfig : ScriptableObject
{
   [Serializable] public class SpriteSequence
    {
        public Track Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }

    public List<SpriteSequence> Sequence = new List<SpriteSequence>();

}
