using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endscript : MonoBehaviour {

	public void restartgame()
    {
        SceneManager.LoadScene("Scene");
    }

    public void exitgame()
    {
        Debug.Log("Exit Button pressed");
        Application.Quit();
    }
}
