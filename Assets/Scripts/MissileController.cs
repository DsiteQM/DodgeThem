using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MissileController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] GameObject explosionPrefab;

    private GameObject target;

    private void Start()
    {
        StartCoroutine(ExplodeAfterSpawn());    
        target = GameObject.Find("Plane");
    }
    private void FixedUpdate()
    {
        
        var direction = target.transform.position - transform.position;
        direction = direction.normalized;

        var rotateAmount = Vector3.Cross(direction ,transform.up).z;

        rb.velocity = transform.up * (speed * Time.deltaTime);
        rb.angularVelocity = -rotateAmount * (rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Explode();
        }
        if (collision.CompareTag("Plane"))
        {
            Explode();
        }
    }
 
    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator ExplodeAfterSpawn()
    {
        yield return new WaitForSeconds(5f);
        Explode();
    }
}
