using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJumpTrigger : MonoBehaviour
{
    public AudioSource DoorBang;
    public AudioSource DoorJumpMusic;
    public GameObject TheZombie;
    public GameObject TheDoor;
    public AudioSource AMusic;

    private void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("Door2Open");
        DoorBang.Play();
        TheZombie.SetActive(true);

        StartCoroutine(PlayJumpMusic());


    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(.4f);
        AMusic.Stop();
        DoorJumpMusic.Play();
    }

}
