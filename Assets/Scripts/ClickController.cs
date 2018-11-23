using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickController : MonoBehaviour
{
    public int points = 0;
    public RectTransform heartPivot;
    public Text pointCountText;
    public RectTransform heartMask;
    public Image heartImage;
    public float startHeight = 0;
    public Levels levels;
    public int level = 0;

    public ParticleSystem particle;

    private Vector3 heartStartPosition;
    private Coroutine coroutine;

    private readonly string liderboardName = "CgkIxqvatLEHEAIQAA";


    void Start()
    {
        startHeight = heartMask.sizeDelta.y;
        heartMask.sizeDelta = new Vector2(heartMask.sizeDelta.x, 0);
        heartImage.color = levels.levels[level].color;
        heartStartPosition = heartPivot.position;

        points = PlayerPrefs.GetInt("Score", 0);
        HeartUpdate();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            points++;
            HeartUpdate();
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(ClickAnimation());
            particle.Play();

            PlayerPrefs.SetInt("Score", points);
            PlayGamesPlatform.Instance.ReportScore(points, liderboardName, (bool success) =>
            {
                // handle success or failure
                if (success)
                {
                    Debug.Log("Улетел");
                }
                else
                {
                    Debug.Log("Не улетел");
                }
            });
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("Score", points);
            Social.ReportScore(points, liderboardName, (bool success) =>
            {
                
            });
            Application.Quit();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetInt("Score", points);
        Social.ReportScore(points, liderboardName, (bool success) =>
        {

        });
    }

    private void HeartUpdate()
    {
        if (levels.levels[level].difficulty >= points)
        {
            float height = startHeight * (float)points / levels.levels[level].difficulty;
            heartMask.sizeDelta = new Vector2(heartMask.sizeDelta.x, height);
        }
        else //New level
        {
            level++;
            heartImage.color = levels.levels[level].color;
            heartMask.sizeDelta = new Vector2(heartMask.sizeDelta.x, 0);
            float height = startHeight * (float)points / levels.levels[level].difficulty;
            heartMask.sizeDelta = new Vector2(heartMask.sizeDelta.x, height);
        }
        pointCountText.text = points.ToString();
    }

    public void GetLiderBoardBtn()
    {
        Social.ShowLeaderboardUI();
    }

    private IEnumerator ClickAnimation()
    {
        float timer = 0;
        while (timer < 0.05f)
        {
            timer += Time.deltaTime;
            heartPivot.localScale = new Vector3(1f - timer / 2f, 1f - timer / 2f, 1f - timer / 2f);
            yield return null;
        }
        timer = 0.95f;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            heartPivot.localScale = new Vector3(timer, timer, timer);
            yield return null;
        }
    }
}
