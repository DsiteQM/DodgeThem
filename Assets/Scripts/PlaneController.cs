using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField ]private Rigidbody2D rb;
    [SerializeField] GameObject explosionPrefab;

    private float inputX;

    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
    }


    private void FixedUpdate()
    {
        rb.velocity = transform.up * (speed * Time.deltaTime);
        rb.angularVelocity = -inputX * (rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            GameManager.Instance.GameOver();
        }
    }
    
}
