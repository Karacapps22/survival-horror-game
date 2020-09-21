using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ZombieDeath : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject Enemy;
    public int StatusCheck;
    public AudioSource JumpScareMusic;
    public AudioSource AMusic;

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }


    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            Enemy.GetComponent<Animation>().Stop("ZombieAnim"); //Not actual name
            Enemy.GetComponent<Animation>().Play("ZombieFall"); // this part not working
            JumpScareMusic.Stop();
            AMusic.Play();
        }
    }
}

