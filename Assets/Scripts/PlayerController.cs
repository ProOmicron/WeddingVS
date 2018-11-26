using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    private Collider2D playerCollider;
    private void Start()
    {
        playerCollider = rigidbody.gameObject.GetComponent<Collider2D>(); 
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            rigidbody.velocity = new Vector2(0,5);
        }
    }
}
