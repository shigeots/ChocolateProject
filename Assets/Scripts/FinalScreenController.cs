using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreenController : MonoBehaviour {

    private const string SCENE_NAME = "MenuScene";

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            LoadScene();
        }
    }

    private void LoadScene() {
        SceneManager.LoadScene(SCENE_NAME);
    }
}
