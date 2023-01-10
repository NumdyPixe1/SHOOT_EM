using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Movement : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speed = 5;
    [SerializeField] private float roateSpeed = 200f;
    Rigidbody2D rb;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float roateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -roateAmount * roateSpeed;
            rb.velocity = transform.up * speed;

        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
