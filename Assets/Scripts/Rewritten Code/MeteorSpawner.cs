using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {
    public delegate void MeteorDelegate();
    public event MeteorDelegate MeteorSpawnEvent;

    public float maxRange;
    public float minRange;
    public float timeBetweenWaves;
    public int amountOfMeteors;
    public GameObject Meteor;
    
    void Start () {
        StartCoroutine(Example());
	}
	
	
	void Update () {
	
	}

    void SpawnMeteor(GameObject Meteor, float min, float max)
    {
        Instantiate(Meteor, new Vector3(Random.Range(min, max), FindObjectOfType<Camera>().orthographicSize*2, 0), Quaternion.identity);
        //Clone Meteor Object with an x that is random between min, max, and the y being at the top of the screen

        if (MeteorSpawnEvent != null)
        {
            MeteorSpawnEvent();
        }
    }

    IEnumerator Example()
    {
        while (true)
        {
            for (int i = 0; i < amountOfMeteors; i++)
            {
                SpawnMeteor(Meteor, minRange, maxRange);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
            
        }
    }


}
