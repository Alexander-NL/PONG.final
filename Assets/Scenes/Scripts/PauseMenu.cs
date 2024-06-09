using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause1;
    public bool Paused;
    public CanvasGroup canvasGroup;
    public float duration = 2.0f;

    void Start(){
        pause1.SetActive(false);
        StartCoroutine(Timer());
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Paused){
                Resume();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pause1.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume(){
        pause1.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    } 

    public void GoToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator Timer()
    {
        float startAlpha = 1.0f;
        float endAlpha = 0.0f;
        float elapsedTime = 0.0f;

        canvasGroup.alpha = startAlpha;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }
}
