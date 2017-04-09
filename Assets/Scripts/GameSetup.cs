using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSetup : MonoBehaviour {
    public GameObject Meteor;
    public GameObject CityParent;
    public Camera cam;
    public float SpawnRange;
    public int amountOfMeteorsToSpawn;
    static public List<GameObject> meteorGroup = new List<GameObject>();

    void Awake () {
        cam.transform.Translate(SpawnRange / 2, -30, 0);
        CityParent.transform.Translate(SpawnRange / 2, -40, 0);

        for (int i = 0; i < amountOfMeteorsToSpawn; i++)
        {
            SpawnMeteor(SpawnRange,Meteor,0);
        }
	}
	
	void Update () {
	
	}

    void SpawnMeteor(float end,GameObject M,float start = 0)//start is defaulted to 0, if not specified
    {
        float rand = Random.Range(start, end);
        GameObject temp = Instantiate(M, new Vector3(rand, 0, 0), Quaternion.identity) as GameObject;
        meteorGroup.Add(temp);
    }
}
