using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerHitSound, shootingSound, itemSound, boomSound, enemyDeathSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip> ("playerHit");
        shootingSound = Resources.Load<AudioClip> ("shooting");
        itemSound = Resources.Load<AudioClip>("item");
        boomSound = Resources.Load<AudioClip>("boom");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");

        audioSrc = GetComponent<AudioSource> ();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) 
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;    
            case "shooting":
                audioSrc.PlayOneShot(shootingSound);
                break;                    
            case "item":
                audioSrc.PlayOneShot(itemSound);
                break;    
            case "boom":
                audioSrc.PlayOneShot(boomSound);
                break;    
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;    
        }
    }
}
