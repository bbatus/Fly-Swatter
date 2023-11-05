using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameManager : MonoBehaviour
{
    public Slider loadingBar;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void OnPlayButtonClicked()
    {
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        float progress = 0;
        while (progress < 1)
        {
            progress += Time.deltaTime / 3; 
            loadingBar.value = progress; 
            yield return null;
        }
        SceneManager.LoadScene("GameScene"); 
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void MuteUnmuteAudio()
    {
        AudioListener.volume = (AudioListener.volume == 0) ? 1 : 0;
    }
}
