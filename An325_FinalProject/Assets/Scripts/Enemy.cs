using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Enemy_Movement enemy_Movement;
    Animator animator;
    public int maxHp = 5;
    [SerializeField] private int currentHp;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHp = maxHp;
    }
    public void TakeDamage(int damage)
    {
        //this.GetComponent<Enemy_Movement>().enabled = false;
        animator.SetBool("IsHit", true);
        currentHp -= damage;
        StartCoroutine(secondHit(0.5f));
        //animator.SetTrigger("IsHit");

        if (currentHp == 0)
        {
            this.GetComponent<Collider2D>().enabled = false;

            // StartCoroutine(secondDeath(0.5f));
            Destroy(this.gameObject);
        }
    }

    IEnumerator secondHit(float secondHit)
    {
        yield return new WaitForSeconds(secondHit);
        //this.GetComponent<Enemy_Movement>().enabled = true;
        animator.SetBool("IsHit", false);
    }
    void Update()
    {

    }
}
