using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {
    public delegate void OnDamageTaken();
    public static event OnDamageTaken DamageEvent;

    public delegate void OnDeathOfCity();
    public event OnDeathOfCity DeathEvent; //When the city has died

    public int health;
	void Start () {
        Meteor.HitEvent += TakeDamage;
        City.DamageEvent += CheckHealth;
        this.DeathEvent += KillCity;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("The health of " + gameObject.name + " is " + health);
	}

    void TakeDamage(GameObject Hit)
    {
        if(Hit == this.gameObject)
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
