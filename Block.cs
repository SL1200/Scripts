using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // array for holding hit sprites 
    public Sprite[] hitSprites;
    // needs moving into LevelManager
    public static int breakableCount = 0;
    // audio clips 
    public AudioClip fracture;
    public AudioClip destroy;

    private bool isBreakable;
    private bool bonusHitsActive = false;
    private int timesHit;
    private int maxHits;
    private int bonusHits;
    private float duration;
    private float sfxVol = AudioManager.instance.sfxVolume;

    private void Awake()
    {
        maxHits = hitSprites.Length + 1;
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
            breakableCount++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        int hitCount = hitSprites.Length + 1;
        if (hitCount > 1)
            AudioSource.PlayClipAtPoint(fracture, transform.position, sfxVol);
        if (isBreakable)
            ManageHits();
    }

    // process sprite change or block removal
    void ManageHits()
    {
        // get this blocks position
        Vector3 blockPos = transform.position;
        
        // increment timesHit and add on bonusHits 
        timesHit = (timesHit + 1) + bonusHits;

        ScoreManager.instance.SetTimesHit(timesHit);
		
        if(timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(destroy, transform.position, sfxVol);
            ScoreManager.instance.AddPointsToScore();
            ScoreManager.instance.CheckHighScore();
            breakableCount--;
            LevelManager.instance.AllBlocksDestroyed();
            BonusManager.instance.SetDropPosition(blockPos);
            Destroy(gameObject);
        }
        else
        {
            SetSprite();
        }
    }

    /*
        blocks can have up to 4 hits before they are destroyed,
        each hit sprite has a different shade.
    */

    // change sprites for blocks with more than one hit. only called if needed in ManageHits()
    void SetSprite()
    {
        int spriteIndex = timesHit - 1;
		// set new sprite based on hitSprites index
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    
    // called from the BombBall Bonus, this bonus triggers a one hit kill on standard blocks  
    public void SetBonusHits()
    {
        bonusHits = maxHits;
        duration = 10.0f;
        bonusHitsActive = true;
        BonusHitsTimer();
    }

    // timer for bonus effect
    void BonusHitsTimer()
    {
        duration -= Time.deltaTime;
        if(duration <= 0.0f)
        {
            StopBonusHits();
        }
    }

    void StopBonusHits()
    {
        bonusHitsActive = false;
        bonusHits = 0;
    }

    private void Update()
    {
        if (bonusHitsActive)
            BonusHitsTimer();
    }
}
