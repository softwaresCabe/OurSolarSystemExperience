using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdManager : MonoBehaviour 
{

     //---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//
    #if UNITY_IOS
    private string gameId = "2710784";
    #elif UNITY_ANDROID
    private string gameId = "2710785";
    #endif
    //-------------------------------------------------------------------//




    public GameObject buttons;
    public GameObject waitText;

    void Awake()
    {
        Advertisement.Initialize (gameId, true);
        StartCoroutine(ShowAdWhenReady());
        buttons.SetActive(false);
        waitText.SetActive(true);
    }

    public void ShowAd(string zone = "video")
    {
        #if UNITY_EDITOR
            StartCoroutine(WaitForAd ());
        #endif

        if (string.Equals (zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions ();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady (zone))
            Advertisement.Show (zone, options);
    }

    void AdCallbackhandler(ShowResult result)
    {
            switch (result)
        {
            case ShowResult.Finished:
                
                    buttons.SetActive(true);
                    waitText.SetActive(false);
                break;
            case ShowResult.Skipped:
                waitText.SetActive(false);
                buttons.SetActive(true);
                break;
            case ShowResult.Failed:
                waitText.SetActive(false);
                buttons.SetActive(true);
                break;
        }
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
            yield return null;

        //Advertisement.Show ();
        ShowAd();
    }

    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }

    IEnumerator LoadAsyncScene(int buildIndex)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

       AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
			float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
			//Debug.Log(progress);
            yield return null;
        }
    }
}