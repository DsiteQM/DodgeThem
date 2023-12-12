using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = target.position - transform.position;

    }

    private void FixedUpdate()
    {
        Vector3 position = -offset + target.position;
        Vector3 currentPosition = Vector3.Lerp(transform.position, position, .5f);
        
        transform.position = currentPosition;
    }
}
