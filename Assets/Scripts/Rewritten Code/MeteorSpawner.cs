using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {
    public delegate void MeteorDelegate();
    public event MeteorDelegate MeteorSpawnEvent;

    public float maxRange;
    public float minRange;
    public int amountOfMeteors;
    public GameObject Meteor;

    void Start () {
        StartCoroutine(Example());
	}
	
	
	void Update () {
	
	}

    void SpawnMeteor(GameObject Meteor, float min, float max)
    {
        Instantiate(Meteor, new Vector3(Random.Range(min, max), FindObjectOfType<Camera>().orthographicSize, 0), Quaternion.identity);
        
        if (MeteorSpawnEvent != null)
        {
            MeteorSpawnEvent();
        }
    }

    IEnumerator Example()
    {
        while (true)
        {
            
            SpawnMeteor(Meteor, minRange, maxRange);
           
            yield return new WaitForSeconds(1);
            
        }
    }
}
