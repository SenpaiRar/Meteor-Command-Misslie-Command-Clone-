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
        
        if (Vector3.Distance(transform.position, ActiveTarget) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, ActiveTarget, Speed * Time.deltaTime);
        }
        else
        {
            Explode();
        }
	}
    
    public void Explode()
    {
        Destroy(gameObject);
        if(ExplodeEvent != null)
        {
            ExplodeEvent(this.transform);
        }
    }

    void GetTarget()
    {
        ActiveTarget = (GameObject.Find("Main Camera").GetComponent<Player>().missileTarget);
        return;
    }
    
}
