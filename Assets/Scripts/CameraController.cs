using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float smoothSpeed = 0.125f;
    private Vector3 offset;

    public bool freezeCamera;
    bool startGame;

    void Start()
    {
        freezeCamera = false;
        startGame = true;
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if(startGame)
        {
            StartCoroutine(waitBeforeStart());
        }
        if (!freezeCamera)
        {
            transform.position = player.transform.position + offset;
        }
    }

    public void freezeCameraNow()
    {
        freezeCamera = true;
        //offset = transform.position;
    }

    public IEnumerator waitBeforeStart()
    {
        yield return new WaitForSeconds(4.0f);
        startGame = false;
        transform.position = player.transform.position + offset;
    }
}