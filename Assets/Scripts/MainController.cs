using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController instance = null;
    [SerializeField]
    private GameObject pillar;
    private float timer;
    private Vector2 spawnPos = new Vector2(4.35f, 0);

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        timer = 0;
        StartCoroutine(InstancePillar());
    }

    private IEnumerator InstancePillar()
    {
        while (true)
        {
            Instantiate(pillar, new Vector2(4.35f, Random.Range(-3f, 3f)), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
