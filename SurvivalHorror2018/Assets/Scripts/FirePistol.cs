using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject Gun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.AmmoCount >=1)
        {
            
            if(IsFiring == false)
            {
                GlobalAmmo.AmmoCount -= 1;
                StartCoroutine(firingPistol());
            }
        }
    }

    IEnumerator firingPistol()
    {
        RaycastHit Shot;
        IsFiring = true;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        Gun.GetComponent<Animation>().Play("Shot");
        MuzzleFlash.SetActive(true);
        //MuzzleFlash.GetComponent<Animator>().enabled = false;
// MuzzleFlash.GetComponent<Animator>().enabled = true;
        GunFire.Play();
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
