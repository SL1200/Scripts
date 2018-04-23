using UnityEngine;


public class BonusManager : MonoBehaviour {

	public static BonusManager instance = null;

    private Vector2 dropPosition;

    private bool padSizeActive = false;
    private bool extraBallsActive = false;
    private bool barrierActive = false;
    private bool bombBallActive = false;
    

    private int bonusBallCount = 0;

    private float padSizeDuration = 0.0f;
    private float extraBallsDuration = 0.0f;
    private float barrierDuration = 0.0f;
    private float bombBallDuration = 0.0f;

    // the Awake function is called before Start() and Update()
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        CheckPadBonus();
        CheckExtraBallsBonus();
        CheckBarrierBonus();
        CheckBombBallBonus();
    }

    private void CheckPadBonus()
    {   
        if (padSizeActive)
        {
            padSizeDuration -= Time.deltaTime;
            if (padSizeDuration <= 0.0f)
            {
                ResetPadBonus();
                if(PaddleMiddle.instance != null)
                {
                    PaddleMiddle.instance.ResetPaddleWidth();
                    padSizeActive = false;
                    padSizeDuration = 0.0f;
                }
            }
        }
             
    }

    private void CheckExtraBallsBonus()
    {
        if (extraBallsActive)
        {
            extraBallsDuration -= Time.deltaTime;
            if(extraBallsDuration <= 0.0f)
            {
                extraBallsActive = false;
                extraBallsDuration = 0.0f;
                
            }
        }
    }

    private void CheckBarrierBonus()
    {
        if(barrierActive)
        {
            barrierDuration -= Time.deltaTime;
            if (barrierDuration <= 0.0f)
            {
                barrierActive = false;
                barrierDuration = 0.0f;
            }
                
        }
    }

    private void CheckBombBallBonus()
    {
        if (bombBallActive)
        {
            bombBallDuration -= Time.deltaTime;
            if(bombBallDuration <= 0.0f)
            {
                bombBallActive = false;
                bombBallDuration = 0.0f;
            }
                
        }
    }

    private void NormalRandomBonus()
    {
        if(GameSettings.instance.GetGameType() == "normal") // remove and place inside SetDropPos
        {
            float randNum = RNG();
            float randTime = RTG();

            if(!padSizeActive)
            {
                // if random number is between 1 - 10
                if(randNum > 0.9 && randNum < 10.1f)
                {
                    SizeBonus(dropPosition);
                    SetPadWidthBonusTime(randTime); 
                    // needs to be triggered onCollision of paddle
                }
            }
            else if(!extraBallsActive)
            {
                // if random number is between 10 - 15
                if (randNum > 10.1f && randNum < 15.1f)
                {
                    ExtraBallsBonus(dropPosition);
                    SetExtraBallsBonusTime(randTime);
                }
            }
            else if(!barrierActive)
            {
                // if random number is between 15 - 20 
                if(randNum > 15.1f && randNum < 20.1f)
                {
                    BarrierBonus(dropPosition);
                    SetBarrierBonusTime(randTime);
                }
            }
            else if(!bombBallActive)
            {
                // if random number is between 20 - 25
                if (randNum > 20.1f && randNum < 25.1f)
                {
                    BombBallBonus(dropPosition);
                    SetBombBallBonusTime(randTime);
                }
            }
            else
            {
                Debug.Log("Bonus called, no winning number this time.");
            }
        }
    }

    // pad size bonus / drop
    private void SizeBonus(Vector2 dropPosition)
    {
        padSizeActive = true;
        Vector2 tgt = dropPosition;
        GameObject padSizeBoost = Instantiate(Resources.Load("Prefabs/PadSizeBoost")) as GameObject;
        padSizeBoost.transform.position = tgt;
    }

    private void SetPadWidthBonusTime(float newDuration)
    {
        padSizeDuration = newDuration;
    }

    // when a block is destroyed this method is passed the blocks position
    public void SetDropPosition(Vector2 newDropPosition)
    {
        Vector2 dropPos = newDropPosition;
        dropPosition = dropPos;
        // here should be the gametype check to decide which set of bonuses to activate
        NormalRandomBonus();
    }

    public float GetPadSizeDuration()
    {
        return padSizeDuration;
    }

    public bool IsPadBonusActive()
    {
        if (padSizeActive)
            return true;
        else
            return false;
    }

    public void ResetPadBonus()
    {
        padSizeActive = false;
    }

    // extra balls bonus / automatic
    private void ExtraBallsBonus(Vector2 dropPosition)
    {
        extraBallsActive = true;
        int randNum = Random.Range(1, 3);
        bonusBallCount = randNum;
        for(int i = 0; i < bonusBallCount; i++)
        {
            Vector2 tgt = dropPosition;
            GameObject extraBall = Instantiate(Resources.Load("Prefabs/ExtraBall")) as GameObject;
            extraBall.name = "ExtraBall_" + i;
            extraBall.tag = "ExtraBall";
            extraBall.transform.position = tgt;
            extraBall.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 4f);
        }
    }

    private void SetExtraBallsBonusTime(float newDuration)
    {
        extraBallsDuration = newDuration;
    }

    public float GetExtraBallsDuration()
    {
        return extraBallsDuration;
    }

    public bool IsExtraBallsActive()
    {
        if (extraBallsActive)
            return true;
        else
            return false;
    }

    public void ResetExtraBallsBonus()
    {
        extraBallsActive = false;
        if(GetExtraBallCount() > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("ExtraBall"));
        }
    }

    private int GetExtraBallCount()
    {
        return bonusBallCount;
    }

    // barrier bonus / drop 
    private void BarrierBonus(Vector2 dropPosition)
    {
        barrierActive = true;
        Vector2 tgt = dropPosition;
        GameObject barrierBonus = Instantiate(Resources.Load("Prefabs/BarrierBonus")) as GameObject;
        barrierBonus.transform.position = tgt;
    }

    private void SetBarrierBonusTime(float newDuration)
    {
        barrierDuration = newDuration;
    }

    public float GetBarrierDuration()
    {
        return barrierDuration;
    }

    public bool IsBarrierActive()
    {
        if (barrierActive)
            return true;
        else
            return false;
    }

    public void ResetBarrierBonus()
    {
        barrierActive = false;
    }

    // bomb ball bonus / drop
    private void BombBallBonus(Vector2 dropPosition)
    {
        bombBallActive = true;
        Vector2 tgt = dropPosition;
        GameObject BombBallBonus = Instantiate(Resources.Load("Prefabs/BombBallBonus")) as GameObject;
    }

    private void SetBombBallBonusTime(float newDuration)
    {
        bombBallDuration = newDuration;
    }

    public float GetBombBallDuration()
    {
        return bombBallDuration;
    }

    public bool IsBombBallActive()
    {
        if (bombBallActive)
            return true;
        else
            return false;
    }

    public void ResetBombBallBonus()
    {
        bombBallActive = false;
    }

    // still need an extra life drop and auto assign on completing certain tasks
    // i.e complete 1 level(5 stages) without losing a life gain +2 extra lives
    // gain 1 life every 5 stages
    // poss wipe bomb for rush mode
    

    // rng random number generator
    private float RNG()
    {
        // generate random number in the range of 1-100
        int randomNumber = Random.Range(1, 100);
        // need to remember why this was cast and not just using int
        float rng = (float)randomNumber;
        return rng;
    }

    // rtg random time generator
    private float RTG()
    {
        // generate random duration for bonus to be active.
        int randomTime = Random.Range(10, 30);
        float rtg = (float)randomTime;
        return rtg;
    }

    
}
