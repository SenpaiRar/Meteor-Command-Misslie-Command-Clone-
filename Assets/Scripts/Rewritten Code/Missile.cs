using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    public delegate void ExplodeDelegate(Transform trans);
    public static event ExplodeDelegate ExplodeEvent;

    public Vector3 ActiveTarget;
    public float Speed;
    public float DestroyRange;

    void Start () {
        GetTarget();
	}
	
	
	void LateUpdate () {
        
        if (Vector3.Distance(transform.position, ActiveTarget) > 1) //move towards the ActiveTarget Vector3 until the distance is less than 1 unit
        {
            transform.position = Vector3.MoveTowards(transform.position, ActiveTarget, Speed * Time.deltaTime); 
        }
        else //Once the missile is less than 1 unit away, Explode
        {
            Explode();
        }
	}
    
    public void Explode()
    {
        Destroy(gameObject); //Destroy GameObject
        if(ExplodeEvent != null)
        {
            ExplodeEvent(this.transform); //Event that contains the missile's transform when it exploded
        }
    }

    void GetTarget()
    {
        ActiveTarget = (GameObject.Find("Main Camera").GetComponent<Player>().missileTarget); //Gets the Vector3 of the target from the Player class
        return;
    }
    
}
