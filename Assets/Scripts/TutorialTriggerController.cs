using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerController : MonoBehaviour {

    #region Private properties

    [SerializeField] private TutorialHUDController _tutorialHUDController;

    private const string PLAYER_TAG = "Player";

    #endregion

    #region Main methods

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG))
            _tutorialHUDController.HideTutorialPanel();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG))
            _tutorialHUDController.ShowTutorialPanel();
    }

    #endregion
}
