using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Transform missileOrigin;
    public GameObject missile;
    public Camera mainCamera;
    public static bool isMissleFired;
	
	void Start () {
        isMissleFired = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isMissleFired)
        {
            Vector3 missileTarget;
            missileTarget.x = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            missileTarget.y = mainCamera.ScreenToWorldPoint(Input.mousePosition).y;
            missileTarget.z = 0;
            
            LaunchMissile(missile.GetComponent<Missile>(),missileTarget);
        }
    }

    void LaunchMissile (Missile Projectile, Vector3 Target)
    {

        Projectile.Target = Target;
        Missile x = Instantiate(Projectile, missileOrigin.position, Quaternion.identity) as Missile;
        
    }
}
