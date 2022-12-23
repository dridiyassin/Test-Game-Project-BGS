using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using System;

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

    public static PlayerClothing Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        RefreshClothes();
    }

    public void RefreshClothes()
    {
        if (torsoClothing != null)
        {
            torso.gameObject.SetActive(true);
            UpdateClothesClips(torsoClips, torsoClothing, torso);
        }
        else
        {
            torso.gameObject.SetActive(false);
        }

        if (hairClothing != null)
        {
            hair.gameObject.SetActive(true);
            UpdateHairClips(hairClips, hairClothing, hair);
        }
        else
        {
            hair.gameObject.SetActive(false);
        }
    }
    public void SetClothing(Clothing clothingItem)
    {
        Type type = clothingItem.GetType();
        if (type == typeof(TorsoClothing))
            SetTorsoClothing((TorsoClothing)clothingItem);
        else if (type == typeof(LegsClothing))
            SetLegsClothing((LegsClothing)clothingItem);
        else if (type == typeof(HairClothing))
            SetHairClothing((HairClothing)clothingItem);
    }
    public void SetTorsoClothing(TorsoClothing clothingItem)
    {
        torsoClothing = clothingItem;
        ClothingInventory.Instance.EquipTorso(clothingItem);
        RefreshClothes();
    }
    public void SetLegsClothing(LegsClothing clothingItem)
    {
        legsClothing = clothingItem;
        ClothingInventory.Instance.EquipLegs(clothingItem);
        RefreshClothes();
    }
    public void SetHairClothing(HairClothing clothingItem)
    {

        hairClothing = clothingItem;
        ClothingInventory.Instance.EquipHair(clothingItem);
        RefreshClothes();
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

      


    }

    void UpdateClothesIdleClip(AnimationClip clip, Sprite idleClothing, Transform affected)
    {

    }



    void UpdateHairClip(AnimationClip clip, Sprite view, Transform affected)
    {




    }

    void UpdateHairIdleClip(AnimationClip clip, Sprite idleClothing, Transform affected)
    {

      
    }
}
