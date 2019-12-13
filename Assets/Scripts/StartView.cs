using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartView : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }
    // Start is called before the first frame update
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("MainScenes");
        
    }

}
