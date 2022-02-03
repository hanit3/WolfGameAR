using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool isAttack;
    public GameObject enemy;

    public int damage = 30;
    Animator enemyAnim;
    public BoxCollider box;

    private void Awake()
    {
        enemyAnim = enemy.GetComponent<Animator>();
        box.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Attacking());
        }
    }


    IEnumerator Attacking()
    {
        isAttack = true;
        enemyAnim.SetTrigger("doWolfAttack");
        yield return new WaitForSeconds(1f);
        box.enabled = true;

        yield return new WaitForSeconds(0.2f);
        box.enabled = false;

        yield return new WaitForSeconds(3f);
        isAttack = false;
    }
}
