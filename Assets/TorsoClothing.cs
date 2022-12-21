using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoClothing : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Serializable]
    public class SpriteList
    {
        public Sprite[] torsoSprites;
    }

    public SpriteList[] torsoList;    
    void SplitSprites()
    {

    }
}
