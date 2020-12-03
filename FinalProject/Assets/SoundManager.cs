using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip shootingSound, itemSound, boomSound, enemyGetKilledSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip> ("shooting");
        itemSound = Resources.Load<AudioClip>("itemSound");
        boomSound = Resources.Load<AudioClip>("boomSound");
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
            {
                case "shooting"
            }
            audioSrc.PlayOneShot(shooting);

        }
    }
}
