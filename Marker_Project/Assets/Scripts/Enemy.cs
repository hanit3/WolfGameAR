using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Weapon sword;
    public GameObject attackColliderObject;
    public PlayerControl player;

    public int maxHealth;
    public int curHealth;

    Rigidbody rigid;
    BoxCollider boxCollider;
    BoxCollider attackCollider;

    Animator anim;

    public Text scoreText;
    public int score;

    public int enemyDamage = 30;
    public Transform target;
    NavMeshAgent nav;

    public bool isAttack;
    
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        
        nav = GetComponent<NavMeshAgent>();
        isAttack = false;
        attackCollider = attackColliderObject.GetComponent<BoxCollider>();
        attackCollider.enabled = false;

            
    }

    void Update()
    {
        nav.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        curHealth -= sword.damage;
        Debug.Log("Enemy hp: " + curHealth);
        anim.SetTrigger("doWolfStun");

        if(curHealth == 0)
        {
            Destroy(gameObject);
            // score += 10;
            player.score += 10;
            //scoreText.text = "" + score;
        }
    }



    //void Targeting()
    //{
    //    float targetRadius = 1.5f;
    //    float targetRange = 3f;

    //    RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, Vector3.forward, targetRange, LayerMask.GetMask("Player"));

    //    if (rayHits.Length > 0 )
    //    {

    //        StartCoroutine((Attacking()));
    //    }
    //}

    //void Attack()
    //{
    //    isAttack = true;
    //    anim.SetTrigger("doWolfAttack");

    //    StartCoroutine(Attacking());
        
    ////    attackCollider.enabled = false;
    ////    isAttack = false;
    //}

    //IEnumerator Attacking()
    //{
    //    isAttack = true;
    //    anim.SetTrigger("doWolfAttack");
    //    yield return new WaitForSeconds(1f);
    //    attackCollider.enabled = true;

    //    yield return new WaitForSeconds(0.2f);
    //    attackCollider.enabled = false;

    //    yield return new WaitForSeconds(3f);
    //    isAttack = false;
    //}


   
}
