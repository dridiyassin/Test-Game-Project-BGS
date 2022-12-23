using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishingRod;
    public ParticleSystem catchEffect;

    public float minFishingTime;
    public float maxFishingTime;
    public float failTime;


    public bool canFish;
    public bool isFishing = false;
    bool canCatchFish = false;


    public Item[] fishList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFish && !isFishing)
        {
            if (Input.GetMouseButton(0))
            {
                StartFishing();
                
            }
        }
        if(canCatchFish)
        {
            if(Input.GetMouseButton(1))
            {
                PickUpFish();
            }
        }
    }


    void PickUpFish()
    {
        Inventory.Instance.AddItem(fishList[Random.Range(0, fishList.Length)]);
        StopFishing();
        canCatchFish = false;
    }

    void CatchFish()
    {
        canCatchFish = true;
        catchEffect.Play();
        
    }

    public void StopFishing()
    {
        fishingRod.SetActive(false);
        StopCoroutine("FishingSequence");
        catchEffect.Stop();
        isFishing = false;
    }

    public void StartFishing()
    {
        isFishing = true;
        fishingRod.SetActive(true);
        StartCoroutine("FishingSequence");
    }

    IEnumerator FishingSequence()
    {
        yield return new WaitForSeconds(Random.Range(minFishingTime, maxFishingTime));
        CatchFish();
        yield return new WaitForSeconds(failTime);

    }
}
