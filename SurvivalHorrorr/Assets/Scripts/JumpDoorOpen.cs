using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpDoorOpen : MonoBehaviour
{

    public float TheDistance;
    //public GameObject ActionDisplay;
    //public GameObject ActionText;
    public GameObject TheDoor;
    public AudioSource CreakSound;
    //public GameObject ExtraCross;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
			this.GetComponent<BoxCollider>().enabled = false;
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            TheDoor.GetComponent<Animation>().Play("Door2Open");
            CreakSound.Play();

        }
    }
}
