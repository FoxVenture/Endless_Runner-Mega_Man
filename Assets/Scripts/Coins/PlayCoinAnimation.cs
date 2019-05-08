using UnityEngine;
using System.Collections;

public class PlayCoinAnimation : MonoBehaviour
{
    public Renderer coin;
    public Animator coinAnimation;

    void Start()
    {

    }

    public void coinAnimationPlay()
    {
        coinAnimation.SetTrigger("CoinAnimation");
    }
}
