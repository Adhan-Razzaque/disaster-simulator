using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene("MainOfficeScene");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnClick()
    {
        
    }
}
