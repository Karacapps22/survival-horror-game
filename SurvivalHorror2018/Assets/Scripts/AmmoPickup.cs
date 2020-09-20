using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmoPickup : MonoBehaviour
{
    public GameObject theAmmo;
    public GameObject ammoDisplayBox;

    private void OnTriggerEnter(Collider other)
    {
        theAmmo.SetActive(false);
        GlobalAmmo.AmmoCount += 7;
        ammoDisplayBox.SetActive(true);
    }
}
