using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speedFireBall = 0.8f;
    [SerializeField] private int damage = 1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speedFireBall;
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {

        }
        if (hitInfo.gameObject.tag == "Enemy")
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }
    }
}
