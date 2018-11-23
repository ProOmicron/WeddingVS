using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;

public class IntroSceneController : MonoBehaviour
{
    public Text text;

    void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Авторизация прошла успешно");
            }
            else
            {
                Debug.Log("Ошибка авторизации");
            }
        });
        StartCoroutine(TextFade());
    }

    private IEnumerator TextFade()
    {
        yield return new WaitForSeconds(2);
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            text.canvasRenderer.SetAlpha(1f - timer);
            yield return null;
        }
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
