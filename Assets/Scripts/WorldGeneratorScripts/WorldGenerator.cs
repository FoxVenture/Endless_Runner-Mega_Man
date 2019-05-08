using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour
{
    public GameObject startMap;
    public GameObject Map1;
    public GameObject Map2;
    //Voeg meer Maps toe

    GameObject[] allWorldMaps;
    GameObject[] activeMaps;

    MapConnections firstMapScript;
    MapConnections secondMapScript;

    int secondMapNr;
    public bool secondIsActive;

    void Start()
    {
        allWorldMaps = new GameObject[7] { startMap, Map1, Map2, Map1, Map2, Map1, Map2}; //Voeg hier ook de nieuwe Maps toe
        GameObject startM = (GameObject)Instantiate(allWorldMaps[0], new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        activeMaps = new GameObject[2] { startM, null };
        instantiareMap();
        firstMapScript = activeMaps[0].GetComponent<MapConnections>();
        secondMapScript = activeMaps[1].GetComponent<MapConnections>();
        secondIsActive = false;
    }

    void FixedUpdate()
    {
        if (secondMapScript.isActive)
        {
            Destroy(activeMaps[0], 2.0f);
            activeMaps[0] = activeMaps[1];
            instantiareMap();

            firstMapScript = activeMaps[0].GetComponent<MapConnections>();
            secondMapScript = activeMaps[1].GetComponent<MapConnections>();
        }
    }

    private void instantiareMap()
    {
        //Verander random
        secondMapNr = Random.Range(1, 7);

        //Get the right script with the Transform
        secondMapScript = activeMaps[0].GetComponent<MapConnections>();

        //Instantiate the new map
        GameObject secondMap = (GameObject)Instantiate(allWorldMaps[secondMapNr], secondMapScript.connectionB.position, secondMapScript.connectionB.rotation);

        activeMaps[1] = secondMap;
    }
}
