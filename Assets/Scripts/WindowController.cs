using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D player;
    [SerializeField]
    private float posY;

    private void Start()
    {
        posY = 10;
    }
    private void Update()
    {
      
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            player.AddRelativeForce(new Vector2(0, 250000));
        }
    }
}
