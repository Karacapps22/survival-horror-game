using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IntroSequencing : MonoBehaviour
{
    public GameObject textBox;
    public GameObject dateDisplay;
    public GameObject placeDisplay;
    public AudioSource line01;
    public AudioSource line02;
    public AudioSource line03;
    public AudioSource line04;
    public AudioSource line05;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SequenceBegin());
    }

    IEnumerator SequenceBegin()
    {
        //yield return new WaitForSeconds(1);
        //placeDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        //dateDisplay.SetActive(true);
        //yield return new WaitForSeconds(4);
        //placeDisplay.SetActive(false);
        //dateDisplay.SetActive(false);
        //yield return new WaitForSeconds(1);
        //textBox.GetComponent<Text>().text = "The night of October 29th, almost Halloween";
        //line01.Play();
        //yield return new WaitForSeconds(3);
        //textBox.GetComponent<Text>().text = "";
    }
}
