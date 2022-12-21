using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerClothing : MonoBehaviour
{
    // Start is called before the first frame update

    //-1 Means Nothing
    public int HairID = -1;
    public int TorsoID = -1;
    public int LegsID = -1;


    public Transform torso;
    public Transform legs;
    public Transform hair;

    public TorsoClothing torsoClothing;

    public AnimationClip downClip;
    public AnimationClip upClip;
    public AnimationClip rightClip;

    Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        if (TorsoID != -1)
        {
            UpdateClips();
        }
        else
        {
            downClip.ClearCurves();
            upClip.ClearCurves();
            rightClip.ClearCurves();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateClips()
    {
        UpdateClip(downClip, new Sprite[] { torsoClothing.torsoList[TorsoID].torsoSprites[0], torsoClothing.torsoList[TorsoID].torsoSprites[1], torsoClothing.torsoList[TorsoID].torsoSprites[2] });

        UpdateClip(upClip, new Sprite[] { torsoClothing.torsoList[TorsoID].torsoSprites[3], torsoClothing.torsoList[TorsoID].torsoSprites[4], torsoClothing.torsoList[TorsoID].torsoSprites[5] });

        UpdateClip(rightClip, new Sprite[] { torsoClothing.torsoList[TorsoID].torsoSprites[6], torsoClothing.torsoList[TorsoID].torsoSprites[7], torsoClothing.torsoList[TorsoID].torsoSprites[8] });
    }

    void UpdateClip(AnimationClip clip, Sprite[] view)
    {

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = torso.name;
        spriteBinding.propertyName = "m_Sprite";

        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[4];

        spriteKeyFrames[0].time = 0f;
        spriteKeyFrames[0].value = view[0];

        spriteKeyFrames[1].time = 0.01f;
        spriteKeyFrames[1].value = view[1];

        spriteKeyFrames[2].time = 0.025f;
        spriteKeyFrames[2].value = view[0];

        spriteKeyFrames[3].time = 0.05f;
        spriteKeyFrames[3].value = view[2];


        AnimationUtility.SetObjectReferenceCurve(clip, spriteBinding, spriteKeyFrames);

    }
}
