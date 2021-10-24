using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour {

    [SerializeField] private string _sceneName;

    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG)) {
            LoadScene();
        }
    }

    private void LoadScene() {
        SceneManager.LoadScene(_sceneName);
    }
}
