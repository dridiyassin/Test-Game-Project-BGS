using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerClothing : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Serializable]
    public struct Clips
    {
        public AnimationClip idleClip;
        public AnimationClip downClip;
        public AnimationClip upClip;
        public AnimationClip rightClip;
    }

    public Transform torso;
    public Transform legs;
    public Transform hair;

    public TorsoClothing torsoClothing;
    public LegsClothing legsClothing;
    public HairClothing hairClothing;

    public Clips torsoClips;
    public Clips legsClips;
    public Clips hairClips;

    Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        if (torsoClothing != null)
        {
            UpdateClothesClips(torsoClips, torsoClothing, torso);
        }
        else
        {
            ClearClips(torsoClips);
        }

        if(hairClothing != null)
        {
            UpdateHairClips(hairClips, hairClothing, hair);
        } else
        {
            ClearClips(hairClips);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClearClips(Clips clips)
    {
        clips.idleClip.ClearCurves();
        clips.downClip.ClearCurves();
        clips.upClip.ClearCurves();
        clips.rightClip.ClearCurves();
    }

    void UpdateClothesClips(Clips clips, Clothing clothing, Transform affected)
    {
        UpdateClothesIdleClip(clips.idleClip, clothing.clothingList[0], affected);
        UpdateClothesClip(clips.downClip, new Sprite[] { clothing.clothingList[0], clothing.clothingList[1], clothing.clothingList[2] }, affected);
        UpdateClothesClip(clips.upClip, new Sprite[] { clothing.clothingList[3], clothing.clothingList[4], clothing.clothingList[5] }, affected);
        UpdateClothesClip(clips.rightClip, new Sprite[] { clothing.clothingList[6], clothing.clothingList[7], clothing.clothingList[8] }, affected);

    }

    void UpdateHairClips(Clips clips , HairClothing cothing, Transform affected)
    {
        UpdateHairIdleClip(clips.idleClip, cothing.clothingList[0], affected);
        UpdateHairClip(clips.downClip, cothing.clothingList[0], affected);
        UpdateHairClip(clips.upClip, cothing.clothingList[1], affected);
        UpdateHairClip(clips.rightClip, cothing.clothingList[2], affected);
    }

    void UpdateClothesClip(AnimationClip clip, Sprite[] view, Transform affected)
    {

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = affected.name;
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

    void UpdateClothesIdleClip(AnimationClip clip, Sprite idleClothing, Transform affected)
    {

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = affected.name;
        spriteBinding.propertyName = "m_Sprite";

        ObjectReferenceKeyframe[] spriteIdleKeyFrames = new ObjectReferenceKeyframe[1];

        spriteIdleKeyFrames[0].time = 0f;
        spriteIdleKeyFrames[0].value = idleClothing;

        AnimationUtility.SetObjectReferenceCurve(clip, spriteBinding, spriteIdleKeyFrames);
    }



    void UpdateHairClip(AnimationClip clip, Sprite view, Transform affected)
    {

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = affected.name;
        spriteBinding.propertyName = "m_Sprite";

        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[1];

        spriteKeyFrames[0].time = 0f;
        spriteKeyFrames[0].value = view;



        AnimationUtility.SetObjectReferenceCurve(clip, spriteBinding, spriteKeyFrames);



    }

    void UpdateHairIdleClip(AnimationClip clip, Sprite idleClothing, Transform affected)
    {

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = affected.name;
        spriteBinding.propertyName = "m_Sprite";

        ObjectReferenceKeyframe[] spriteIdleKeyFrames = new ObjectReferenceKeyframe[1];

        spriteIdleKeyFrames[0].time = 0f;
        spriteIdleKeyFrames[0].value = idleClothing;

        AnimationUtility.SetObjectReferenceCurve(clip, spriteBinding, spriteIdleKeyFrames);
    }
}
