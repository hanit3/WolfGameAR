using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    Weapon sword;

    [SerializeField]
    Enemy enemy;

    Rigidbody rigid;
    Animator anim;

    public int health;
    public int maxHealth = 350;
    public bool attack_button_down;

    float attackDelay;
    bool isAttackReady;
    bool isStun;
    bool isDamage;

    float skillDelay;

    public Text hpText;
    public Text scoreText;
    public int score;
 

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isStun = false;
        isDamage = false;
        hpText.text = maxHealth + " / 350";
        scoreText.text = "00";
        
    }

    private void Update()
    {
        scoreText.text = "" + score;
        if(score == 100)
        {
            EndGame();
        }
    }

    public void Attack()
    {
        //attack_button_down = true;

        attackDelay += Time.deltaTime;

       // isAttackReady = sword.rate < attackDelay;

        if(!isStun)
        {
            sword.Use();
            anim.SetTrigger("doAttack");
            //anim.SetBool("isAttack", true);
            attackDelay = 0;
            
        }

        //attack_button_down = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyCol")
        {
            StartCoroutine(OnDamage());
        }
    }

    IEnumerator OnDamage()
    {
        isDamage = true;
        health -= enemy.enemyDamage;
        hpText.text = health + " / 350";
        Debug.Log("Player hp:" + health);
        isStun = true;
        anim.SetTrigger("doStun");
        yield return new WaitForSeconds(1f);
        isDamage = false;
        isStun = false;
    }



    public void Stun()
    {
        
        anim.SetTrigger("doStun");
        isStun = false;

    }

    private void EndGame()
    {
        
            SceneManager.LoadScene("EndScene");
       
    }
}
