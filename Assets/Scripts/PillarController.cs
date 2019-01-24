using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    public static PillarController instance = null;
    private float timerPillar;
    private GameObject pillar;
    public float speed = 0.01f;
    private float step;
    private float target;
    public static bool run = false;


    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        pillar = this.gameObject;
        target = -4.66f;
        run = true;
    }
    void Update()
    {
        if (run)
        {
            //timerPillar += Time.deltaTime;
            //step = timerPillar * speed;
            //pillar.transform.position = Vector2.MoveTowards(transform.position, new Vector2(target, pillar.transform.position.y), step);
            pillar.transform.position += new Vector3(-Time.deltaTime * speed, 0, 0);

            if (pillar.transform.position.x <= target)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("pause");
        }
    }
}
