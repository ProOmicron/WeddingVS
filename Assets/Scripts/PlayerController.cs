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
            rigidbody.velocity = new Vector2(0,4);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        Time.timeScale = 0;
        PillarController.run = false;
    }
}
