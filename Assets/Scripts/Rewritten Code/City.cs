using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {
    public delegate void OnDamageTaken();
    public static event OnDamageTaken DamageEvent; //When the city has taken damage

    public delegate void OnDeathOfCity();
    public event OnDeathOfCity DeathEvent; //When the city has died

    public int health;
	void Start () {
        Meteor.HitEvent += TakeDamage;
        DamageEvent += CheckHealth;
        this.DeathEvent += KillCity; //Has to been (this.) so it doesn't delete the other ciites
    }
	
	
	void Update () {
      
	}

    void TakeDamage(Vector3 Pos)
    {
        if(Vector3.Distance(transform.position,Pos) < 1)
        {
            health -= 10;
            DamageEvent();
        }
    }

    void CheckHealth()
    {
        if(health <= 0)
        {
            if(DeathEvent != null)
            {
                DeathEvent();
            }
        }
    }

    void KillCity()
    {
        this.DeathEvent -= KillCity; //Unsubscribe from these events so unity doesnt raise an error after the gameobject has been destroyed
        Meteor.HitEvent -= TakeDamage;
        Destroy(gameObject);
    }
}
