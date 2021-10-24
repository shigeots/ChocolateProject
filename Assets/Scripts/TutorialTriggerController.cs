using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerController : MonoBehaviour {

    [SerializeField] private TutorialHUDController _tutorialHUDController;

    private const string PLAYER_TAG = "Player";

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG))
            _tutorialHUDController.HideTutorialPanel();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG))
            _tutorialHUDController.ShowTutorialPanel();
    }
}
