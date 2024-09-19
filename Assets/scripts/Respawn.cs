using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader1 : MonoBehaviour
{
    private void start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Game");
    }
}
