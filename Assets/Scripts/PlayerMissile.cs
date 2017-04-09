using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMissile : MonoBehaviour {
    public float speed;
    public float rangeOfDestruction;
    Vector3 activeTarget;
    
    void Start () {
        activeTarget = GameObject.Find("Main Camera").GetComponent<PlayerControl>().missileTarget;
	}
	
	
	void Update () {
	if(Vector3.Distance(transform.position,activeTarget) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, activeTarget, speed * Time.deltaTime);
        }
        else
        {
            Explode();
        }
	}

    void Explode()
    {
        List<GameObject> meteorsToDestroy = new List<GameObject>();
        PlayerControl.missileOut = false;
        foreach (var item in GameSetup.meteorGroup)
        {
            if (Vector3.Distance(transform.position,item.transform.position) < rangeOfDestruction)
            {
                meteorsToDestroy.Add(item);
            }
        }

        foreach (var item in meteorsToDestroy)
        {
            item.GetComponent<Meteor>().ExplodeByMissile();
        }
        Destroy(gameObject);
    }
}
