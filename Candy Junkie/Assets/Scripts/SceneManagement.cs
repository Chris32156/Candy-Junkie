using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Params
    [SerializeField] Animator transitionAnim;

    //Declare Vars
    string sceneName;

    //Load Scene
    public void LoadScene(string scene)
    {
        //Set Scene Name
        sceneName = scene;

        //Start Loading Scene Coroutine
        StartCoroutine(LoadingScene());
    }

    IEnumerator LoadingScene()
    {
        //Starts End Anim
        transitionAnim.SetTrigger("end");

        //Waits 1.5 Seconds
        yield return new WaitForSeconds(1.5f);

        //Load Next Scene
        SceneManager.LoadScene(sceneName);
    }
}
