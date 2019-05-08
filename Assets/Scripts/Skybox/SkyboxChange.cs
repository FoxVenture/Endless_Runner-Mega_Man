using UnityEngine;
using System.Collections;

public class SkyboxChange : MonoBehaviour
{
    public Material skybox1;
    public Material skybox2;
    public Material skybox3;

	// Use this for initialization
	void Start ()
    {
        RenderSettings.skybox = skybox1;
	}
	
	// Update is called once per frame
	public void skyboxSnow()
    {
        RenderSettings.skybox = skybox2;
    }

    public void skyboxNeon()
    {
        RenderSettings.skybox = skybox3;
    }
}
