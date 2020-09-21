using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ZombieAI : MonoBehaviour
{
    
    Rigidbody m_Rigidbody;

    public GameObject thePlayer;
    public GameObject theEnemy;
    public float EnemySpeed = .01f;
    public bool AttackTrigger = false;
    public bool IsAttacking = false;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public int HurtGenerator;
    public GameObject theFlash;
    public Collider col;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //col = GetComponent<Collider>();
        //col.isTrigger = true;
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.useGravity = false;
        }
    }

    void Update()
    {

        //StartCoroutine(InflictDamage());
        transform.LookAt(thePlayer.transform);
        if (AttackTrigger == false)
        {
            EnemySpeed = 0.01f;
            //theEnemy.GetComponent<Animation>().Play("NewZombieWalk"); //not actual name of walk, need to figure out animations not using animator for this
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, EnemySpeed);

        }
        if (AttackTrigger == true && IsAttacking == false)
        {
            EnemySpeed = 0;
            theEnemy.GetComponent<Animation>().Play("NewZombieWalk"); //again, need to figure out animations not using animator for this
            StartCoroutine(InflictDamage());
        }
    }

    private void OnTriggerEnter()
    {
        AttackTrigger = true;
    }
    private void OffTriggerEnter()
    {
        AttackTrigger = false;
    }
    IEnumerator InflictDamage()
    {
        IsAttacking = true;
        if(HurtGenerator ==1)
        {
            HurtSound1.Play();
        }
        if (HurtGenerator == 2)
        {
            HurtSound2.Play();
        }
        if (HurtGenerator == 3)
        {
            HurtSound3.Play();
        }
        theFlash.SetActive(true);
        yield return new WaitForSeconds(.1f);
        theFlash.SetActive(false);
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
        HurtGenerator = Random.Range(1, 4);
        yield return new WaitForSeconds(.9f);
        IsAttacking = false;
    }
}
