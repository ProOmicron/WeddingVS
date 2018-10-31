using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class IntroSceneController : MonoBehaviour
{
    public Text text;

    void Start()
    {
        StartCoroutine(TextFade());
    }

    void Update()
    {
    
    }

    private IEnumerator TextFade()
    {
        yield return new WaitForSeconds(5);
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
