using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    Vector3 ActiveTarget;
    public float speed;
   
    void Start () {
        Missile.ExplodeEvent += ExplodeByMissile;
        ActiveTarget = new Vector3(0, -20, 0);
    }


    void LateUpdate()
    {
        if (Vector3.Distance(transform.position, ActiveTarget) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, ActiveTarget, speed * Time.deltaTime);
        }
        else
        {
            Explode();
        }
    }

    public void Explode()
    {
        Missile.ExplodeEvent -= ExplodeByMissile;
        Destroy(gameObject);
    }
    
    public void ExplodeByMissile (Transform trans)
    {

        if(Vector3.Distance(trans.position,transform.position) < 10)
        {
            Missile.ExplodeEvent -= ExplodeByMissile;
            Destroy(gameObject);
        }
    }

}
