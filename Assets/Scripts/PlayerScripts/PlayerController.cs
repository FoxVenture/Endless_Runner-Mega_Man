using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public enum Swipe { None, Up, Down, Left, Right };

public class PlayerController : MonoBehaviour
{
    const float speedIncreaseTime = 3f;
    const float speedChange = 0.5f;
    public float followDistance;
    float itervalTimer = speedIncreaseTime;
    public float speed;
    public float sideSpeed = 8;
    float oldSpeed;

    private bool onGround;
    private bool firstOnTheGround;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject followEnemy;


    private Vector3 playerPosition;
    private Vector3 followEnemyPosition;

    //Swipe detect
    public float minSwipeLength = 200f;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public static Swipe swipeDirection;
    Vector3 dir = Vector3.zero; //
    float moveSpeed = 0.5f; //

    public Transform bulletSpawn;

    //Other Scripts
    public ActivatePowerAttack PowerAttack;
    public PlayerStats playerStats;
    public PlayerSounds playerSounds;
    public PlayerAnimations playerAnimations;
    public Rigidbody rb;
    public CameraController cameraController;

    bool startGame;
    bool playerDead;
    bool falling;


    void Start()
    {
        onGround = true;
        firstOnTheGround = false;
        speed = 7;
        followDistance = 6f;
        startGame = true;
        playerDead = false;
        falling = false;
    }

    void FixedUpdate()
    {

        if (startGame)
        {
            if (!playerDead)
            {
                StartCoroutine(waitBeforeStart());
            }
        }
        else
        {
            dir.x = Input.acceleration.x * moveSpeed;
            transform.Translate(dir.x, 0, speed * Time.deltaTime);
        }
        
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    Fire();
                    return;
                }

                currentSwipe.Normalize();

                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f && onGround)
                {
                    playerSounds.StopWalkingSound();
                    onGround = false;
                    firstOnTheGround = false; 
                    swipeDirection = Swipe.Up;
                    playerAnimations.jumpAnimation();
                    rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                    playerSounds.PlayJumpSound();
                    
                }
                else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f && onGround)
                {

                    swipeDirection = Swipe.Down;
                    transform.localScale = new Vector3(1, 0.5f, 1);
                    playerSounds.PlayDuckSound();
                    StartCoroutine(playerDuck());
                }

                //
                /* Turn left and right
                //
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    swipeDirection = Swipe.Left;
                    swipeText.text = "Swipe Left";
                    transform.Rotate(rb.position.x, rb.position.y - 90, rb.position.z);
                    // Swipe right
                }
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    swipeDirection = Swipe.Right;
                    swipeText.text = "Swipe Right";
                    transform.Rotate(rb.position.x, rb.position.y + 90, rb.position.z);
                }
                */
            }
        }
        else
        {
            swipeDirection = Swipe.None;
        }

        if (itervalTimer < 0)
        {
            speed += speedChange;
            itervalTimer = speedIncreaseTime;
        }
        if (followDistance > 1)
        {
            moveFollowEnemy();
        }
        else
        {
            playerStats.Dead();
        }

        if (playerStats.lives == 0)
        {
            startGame = true;
            playerDead = true;
            playerStats.Dead();
        }

        if (checkFalling() && !falling)
        {
            cameraController.freezeCameraNow();
            playerSounds.PlayFallingSound();
            falling = true;
            StartCoroutine(waitForFalling());
        }

    }

    private bool checkFalling()
    {
        if(transform.position.y < -5)
        {
            return true;
        }

        return false;
    }

    public void usePowerAttack()
    {
        PowerAttack.PowerAttackActive = true;
        playerStats.powerAttackUsed();
    }

    void moveFollowEnemy()
    {
        playerPosition = transform.position;
        followEnemyPosition = playerPosition;
        followEnemy.transform.position = new Vector3(followEnemyPosition.x, 1f, (followEnemyPosition.z - followDistance));
    }

    public void setOnGround()
    {
        onGround = true;
        if (onGround && !firstOnTheGround)
        {
            firstOnTheGround = true;
            playerSounds.PlayWalkingSound();
        }
    }

    public void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        playerAnimations.shootAnimation();

        playerSounds.PlayShootingSound();

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * (speed*3);

        Destroy(bullet, 2.0f);
    }

    public IEnumerator slowDown()
    {
        speed = speed -3;
        if (speed <= 0)
        {
            playerStats.Dead();
        }
        else
        {
            yield return new WaitForSeconds(2.0f);
            speed += 2;
        }
    }

    public IEnumerator speedUp()
    {
        oldSpeed = speed;
        speed = speed +2;
        followDistance++;
        yield return new WaitForSeconds(2.0f);
        speed = oldSpeed;
    }

    public IEnumerator playerDuck()
    {
        yield return new WaitForSeconds(1.0f);
        transform.localScale = new Vector3(1, 1, 1);
    }

    public IEnumerator Resetplayer()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        yield return new WaitForSeconds(5f);
    }

    public IEnumerator waitForFalling()
    {
        yield return new WaitForSeconds(2);
        playerStats.Dead();
    }

    public IEnumerator waitBeforeStart()
    {
        yield return new WaitForSeconds(2.2f);
        startGame = false;
        playerSounds.PlayWalkingSound();
    }


    //voor toetsenbord
    void keyboard()
    {
        //dir.x = Input.acceleration.x * moveSpeed;
        //transform.Translate(dir.x, 0, speed * Time.deltaTime);


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(speed * moveHorizontal * Time.deltaTime, 0f, speed * moveVertical * Time.deltaTime);

        if (Input.GetButtonDown("Turn Left"))
        {
            transform.Rotate(rb.position.x, rb.position.y - 90, rb.position.z);
        }

        if (Input.GetButtonDown("Turn Right"))
        {
            transform.Rotate(rb.position.x, rb.position.y + 90, rb.position.z);
        }


        if (onGround && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(moveHorizontal, 5f, moveVertical);
            onGround = false;
        }


        if (onGround && Input.GetButtonDown("Fire1"))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }

        if (onGround && Input.GetButtonUp("Fire1"))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            Fire();
        }

        if (playerPosition.y < -15f)
        {
            playerStats.Dead();
        }

        if (itervalTimer < 0)
        {
            speed += speedChange;
            itervalTimer = speedIncreaseTime;
        }
        if (followDistance > 1)
        {
            moveFollowEnemy();
        }
        else
        {
            playerStats.Dead();
        }
    }

}
