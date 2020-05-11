using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameLogic : MonoBehaviour {

    private int sceneIndex;

	void Awake() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        sceneIndex = SceneManager.GetSceneAt(sceneIndex).buildIndex;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ScreenshotHandler.TakeScreenshot_Static(500, 500);
    //    }
    //}

    public void toggleVRMode(){
        if(DontDestroy.playerData.VRMode == true) {
            DontDestroy.playerData.VRMode = false;
            StartCoroutine(SwitchTo2D());
        }
        else{
            DontDestroy.playerData.VRMode = true;
            StartCoroutine(SwitchToVR());
        }
    }

    public void startButton() {
        SceneManager.LoadScene(1);
    }

    public  void nextScene(){
        StartCoroutine(WaitNext());
    }
    
    public void previousScene(){
        StartCoroutine(WaitBack());
	}

    public void reStart(){
        SceneManager.LoadScene(0);
    }

    public void showBox(GameObject box){
        box.SetActive(true);
    }

    public void hideBox(GameObject box){
        box.SetActive(false);
    }

    public void OpenUI(GameObject myUI){
        myUI.SetActive(true);
    }

    public void CloseUI(GameObject myUI){
        myUI.SetActive(false);
    }

    IEnumerator WaitNext(){
        yield return new WaitForSecondsRealtime( 2f );
        SceneManager.LoadScene( sceneIndex += 1, LoadSceneMode.Single );
    }

    IEnumerator WaitBack(){
        yield return new WaitForSecondsRealtime( 2f );
        SceneManager.LoadScene( sceneIndex -= 1, LoadSceneMode.Single );
    }

    IEnumerator WaitReset(){
        yield return new WaitForSecondsRealtime( 2f );
        SceneManager.LoadScene( 0, LoadSceneMode.Single );
    }
    IEnumerator SwitchToVR() {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard"; // Or "cardboard".

        // Some VR Devices do not support reloading when already active, see
        // https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
        
        XRSettings.LoadDeviceByName(desiredDevice);

        // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
        yield return null;
        
        // Now it's ok to enable VR mode.
        XRSettings.enabled = true;
        reStart();

    }

    IEnumerator SwitchTo2D() {
        // Empty string loads the "None" device.
        XRSettings.LoadDeviceByName("");

        // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
        yield return null;

        // Not needed, since loading the None (`""`) device takes care of this.
        // XRSettings.enabled = false;

        // Restore 2D camera settings.
        ResetCameras();
        reStart();
    }

// Resets camera transform and settings on all enabled eye cameras.
    void ResetCameras() {
        // Camera looping logic copied from GvrEditorEmulator.cs
        for (int i = 0; i < Camera.allCameras.Length; i++) {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None) {

            // Reset local position.
            // Only required if you change the camera's local position while in 2D mode.
            cam.transform.localPosition = Vector3.zero;

            // Reset local rotation.
            // Only required if you change the camera's local rotation while in 2D mode.
            cam.transform.localRotation = Quaternion.identity;

            // No longer needed, see issue github.com/googlevr/gvr-unity-sdk/issues/628.
            // cam.ResetAspect();

            // No need to reset `fieldOfView`, since it's reset automatically.
            }
        }
    }



#if UNITY_IOS
    private string AppURL = "https://itunes.apple.com/us/app/our-solar-system-experience/id1433897867?mt=8";
#elif UNITY_ANDROID
    private string AppURL = "https://play.google.com/store/apps/details?id=com.CabeSoftwares.OurSolarExperienceCB";
#endif
    public void SendToUrl()
    {
        Application.OpenURL(AppURL);
    }

}




