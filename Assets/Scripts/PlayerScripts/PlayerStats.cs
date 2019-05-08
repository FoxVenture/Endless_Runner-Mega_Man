using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    int powerMeter = 0;
    int score = 0;
    int coins = 0;
    int lastCoins = 0;
    public int lives;
    public PlayerSounds playerSounds;
    public GameObject GameOverScreen;

    public Slider healthSlider;
    public Slider powerAttackSlider;

    public float flashSpeed= 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public Text coinText;
    public Text scoreText;

    bool playedPoweredUpSound;

    void Start()
    {
        coinText.text =  coins.ToString();
        scoreText.text = score.ToString();
        playedPoweredUpSound = false;
        lives = 3;
    }

    void FixedUpdate()
    {
        scoreText.text = score.ToString();
        coinText.text = coins.ToString();
        healthSlider.value = lives;
        powerAttackSlider.value = powerMeter;

        if (lives > 5)
        {
            lives = 5;
        }

        if(powerMeter > 5)
        {
            powerMeter = 5;
        }

        if (powerMeter == 5 && playedPoweredUpSound == false)
        {
            playerSounds.PlayPoweredUpSound();
            playedPoweredUpSound = true;
        }
    }
	
    public bool gotHit()
    {
        healthSlider.value = lives;
        playerSounds.PlayGotHitSound();
        lives = lives - 1;
        if (lives <= 0)
        {
            healthSlider.value = lives;
            return true;
        }
        else
        {
            healthSlider.value = lives;
            return false;
        }
    }

    public void Dead()
    {
        SceneManager.LoadScene(2);
    }

    public void coinPickUp()
    {
        coins++;
        score += 5;
        checkCoins();
    }

    public void speedPickUp()
    {
        score += 20;
    }

    public void killedEnemy()
    {
        powerMeter++;
        score += 30;
    }

    public void destroyedObstacle()
    {
        powerMeter++;
        score += 40;
    }

    public void powerAttackUsed()
    {
        powerMeter =0;
        score += 150;
    }

    public void resetPowerMeter()
    {
        powerMeter = 0;
    }

	void checkCoins()
    {

	    if(lastCoins+15 == coins)
        {
            lives++;
            score = score + 50;
            lastCoins = coins;
            playerSounds.LevelUpSound();
        }
	}
}
