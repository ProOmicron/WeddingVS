using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    private Collider2D playerCollider;
    public int bonus;
    private void Start()
    {
        playerCollider = rigidbody.gameObject.GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y < 4.3f)
        {
            rigidbody.velocity = new Vector2(0f, 7.5f);
        }
        if (transform.position.y < -4.3f)
        {
            rigidbody.velocity = new Vector2(0f, 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        PillarController.run = false;
        MainController.instance.ActiveWindow();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MainController.instance.bonus++;
    }
}
