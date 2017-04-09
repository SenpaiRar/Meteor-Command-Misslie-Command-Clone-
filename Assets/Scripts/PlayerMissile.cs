using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour {
    public float speed;
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
        PlayerControl.missileOut = false;
        Destroy(gameObject);
    }
}
