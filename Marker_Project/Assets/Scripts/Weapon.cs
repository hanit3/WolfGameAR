using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float rate; // 공격 속도
    public BoxCollider weaponArea;

    private void Awake()
    {
        weaponArea.enabled = false;
    }

    public void Use() // 메인루틴
    {
        weaponArea.enabled = true;
        StartCoroutine(Swing());
    }

    IEnumerator Swing() // 코루틴
    {
        yield return new WaitForSeconds(1f);
        weaponArea.enabled = true;

        yield return new WaitForSeconds(0.2f);
        weaponArea.enabled = false;



    }

// 메인루틴+코루틴 동시 실행

}
