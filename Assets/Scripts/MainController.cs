using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public static MainController instance = null;
    [SerializeField]
    private GameObject pillar;
    private float timer;
    private Vector2 spawnPos = new Vector2(4.35f, 0);
    [SerializeField]
    private GameObject windowRestart;
    public int bonus = 0;
    public Text bonusTxt;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        bonus = 0;
        timer = 0;
        StartCoroutine(InstancePillar());
    }

    private void Update()
    {
        bonusTxt.text = "Bonus: " + bonus.ToString();
    }

    private IEnumerator InstancePillar()
    {
        while (true)
        {
            Instantiate(pillar, new Vector2(5f, Random.Range(-3f, 3f)), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }

    public void Restart()
    {
        PillarController.run = true;
        Debug.Log("restart");
        windowRestart.SetActive(false);
        Time.timeScale = 1;
        bonus = 0;
    }

    public void ActiveWindow()
    {
        windowRestart.SetActive(true);
    }
}
