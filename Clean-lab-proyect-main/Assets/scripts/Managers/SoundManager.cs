using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public AudioClip moneyClip;

    //Per quan vulguem afegir més efectes de so.
    //public AudioClip sheepHitClip; 
    //public AudioClip sheepDroppedClip;

    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;

    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayMoneyClip()
    {
        PlaySound(moneyClip);
    }


    //Pels diferents efectes de so
    //public void PlaySheepHitClip()
    //{
    //    PlaySound(sheepHitClip);
    //}

    //public void PlaySheepDroppedClip()
    //{
    //    PlaySound(sheepDroppedClip);
    //}

}
