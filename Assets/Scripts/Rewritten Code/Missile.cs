using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public Vector3 Target;
    public float speed;

    void Start () {
	
	}
	
	
	void LateUpdate () {
        
       
        if (Vector3.Distance(transform.position, Target) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        }
        else
        {
            Explode();
        }
	}
    
    public void Explode()
    {
        Debug.Log(gameObject.name + " has been destroyed");
        Destroy(gameObject);
    }
}
