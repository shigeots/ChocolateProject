using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreenController : MonoBehaviour {

    #region Private properties

    private const string SCENE_NAME = "MenuScene";

    #endregion

    #region Main methods

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            LoadScene();
        }
    }

    #endregion

    #region Private methdos

    private void LoadScene() {
        SceneManager.LoadScene(SCENE_NAME);
    }

    #endregion
}
