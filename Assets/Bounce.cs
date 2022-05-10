using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bounce : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float _forceMultiplier = 20f;
    private void OnCollisionEnter2D()
    {
        Debug.Log(transform.position.x - player.transform.position.x);
        Vector2 knockbackVelocity = new Vector2((transform.position.x - player.transform.position.x) * _forceMultiplier, (transform.position.y - player.transform.position.y) * _forceMultiplier);
        player.GetComponent<Rigidbody2D>().velocity = -knockbackVelocity;
    }
}
