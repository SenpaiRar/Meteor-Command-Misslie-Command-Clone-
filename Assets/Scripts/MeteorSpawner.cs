using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteorSpawner : MonoBehaviour {
    public GameObject Meteor;
    public float SpawnRange;
  
    void Start () {
        for (int i = 0; i < 5; i++)
        {
            SpawnMeteor(SpawnRange,Meteor);
        }
	}
	
	void Update () {
	
	}

    void SpawnMeteor(float end,GameObject M,float start = 0)//start is defaulted to 0, if not specified
    {
        float rand = Random.Range(start, end);
      //  Debug.Log(rand);
        Instantiate(M, new Vector3(rand,0,0),Quaternion.identity);
    }
}
