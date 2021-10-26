using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour {

    #region Private properties

    [SerializeField] private string _sceneName;

    private const string PLAYER_TAG = "Player";

    #endregion

    #region Main methods

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG)) {
            LoadScene();
        }
    }

    #endregion

    #region Private methods

    private void LoadScene() {
        SceneManager.LoadScene(_sceneName);
    }

    #endregion
}
