using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {
    public delegate void CityHit(Vector3 PositionAtHit);//change GameObject to Vector3
    public static event CityHit HitEvent;

    public delegate void OnMeteorDestroy();
    public static event OnMeteorDestroy MeteorDestroyed;

    Vector3 ActiveTarget = new Vector3(100,100,100);
    public float speed;
   
    void Start () {
        Missile.ExplodeEvent += ExplodeByMissile;

        foreach (var item in GameObject.FindGameObjectsWithTag("City"))
        {
            Vector3 temp = item.transform.position;

            if (Vector3.Distance(temp, transform.position) < Vector3.Distance(ActiveTarget, transform.position))
            {
                ActiveTarget = temp;
            } 
        }
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
    
    public void Explode()//TODO: Make this 2 methods. One to damage the city, and one to destroy the gameobject. If i dont, there are cases where another metoer will destroy the city and cause this one to just stop
    {
        if (HitEvent != null)
        {
            HitEvent(transform.position);
        }
        Missile.ExplodeEvent -= ExplodeByMissile; //Unsubscribe the event to not raise errors later
        Destroy(gameObject);
    }
    
    public void ExplodeByMissile (Transform trans) //When a missile explodes, this functions check wether the meteor should be destroyed
    {
        if(Vector3.Distance(trans.position,transform.position) < 10) //Is meteor and missile within 10 units?
        {
            if(MeteorDestroyed != null)
            {
                MeteorDestroyed();
            }
            Missile.ExplodeEvent -= ExplodeByMissile; //If so, destroy the gameOBject and unsubscribe from the event
            Destroy(gameObject);
        }
    }
}
