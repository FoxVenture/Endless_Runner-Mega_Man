using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public PlayCoinAnimation playCoinAnimationScript;
    PlayerController controller;
    PlayerStats pStats;
    PlayerSounds playerSounds;
    public SkyboxChange changeSkybox;
    public FollowingEnemy followEnemy;

    public GameObject bullet;
    public GameObject activateSnow;
    public GameObject snowLight;
    public GameObject neonLight;

    bool isColliding = false;
    
    void Start()
    {
        pStats = gameObject.GetComponent<PlayerStats>();
        controller = gameObject.GetComponent<PlayerController>();
        playerSounds = GetComponent<PlayerSounds>();
        activateSnow.SetActive(false);
    }
    
    void Update()
    {
        isColliding = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (isColliding) return;
        isColliding = true;

        if (other.gameObject.CompareTag("Enemy"))
        {
            pStats.gotHit();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            controller.setOnGround();
        }

        if(other.gameObject.CompareTag("Coin"))
        {
            pStats.coinPickUp();
            playerSounds.PlayCoinSound();
            playCoinAnimationScript.coinAnimationPlay();
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("SpeedUp"))
        {
            pStats.speedPickUp();
            controller.speedUp();
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SnowWorldEnter"))
        {
            activateSnow.SetActive(true);
            changeSkybox.skyboxSnow();
        }

        if (other.gameObject.CompareTag("SnowWorldExit"))
        {
            activateSnow.SetActive(false);
        }

        if (other.gameObject.CompareTag("NeonWorldEnter"))
        {
            changeSkybox.skyboxNeon();
        }

        if (other.gameObject.CompareTag("NeonWorldExit"))
        {
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerSounds.PlayObstacleSound();
            StartCoroutine(controller.slowDown());
            controller.followDistance--;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(controller.slowDown());
            controller.followDistance--;
        }

        if (other.gameObject.CompareTag("SpeedUp"))
        {
            StartCoroutine(controller.speedUp());
            controller.followDistance++;
            Destroy(other.gameObject);
        }

    }
    
}
