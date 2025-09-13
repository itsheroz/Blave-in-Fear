using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    NavMeshAgent nav;
    Animator anim;
    GameManager manager;
    public static bool checkAttack = false;
    void Start()
    {
        if (target==null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (manager==null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = temp.GetComponent<GameManager>();
            anim = GetComponent<Animator>();
        }
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = target.position;
        if (nav.remainingDistance<=nav.stoppingDistance && Player.isAlive)
        {
            anim.SetBool("IsAttack", true);
        }
        else
        {
            anim.SetBool("IsAttack", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Weapon")
        {
            Destroy(other.gameObject);
            nav.isStopped = true;
            anim.SetTrigger("IsDeath");
            manager.killEnemy();
            StartCoroutine(removeEnemy());
        }
    }
    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public void beginAttack()
    {
        checkAttack = true;
    }
}
