using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    private static LevelLoader _instance;
    public Animator transition;
    public float transitionTime = 1f;

    public static LevelLoader Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    public void LoadLevel()
    {

       StartCoroutine(loading());


    }

    IEnumerator loading()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("SampleScene");
    }

}
