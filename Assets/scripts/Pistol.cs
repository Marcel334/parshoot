using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        auto = false;
    }

    protected override void OnShot()
    {
        Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);        
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition);
        RaycastHit hit;

        //To powinno być napisane po linii RaycastHit hit
        if (Physics.Raycast(ray, out hit))
            {
                GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation);
                Destroy(gameBullet, 1);
            }
    }

}
