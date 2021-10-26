using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelScreenController : MonoBehaviour {

    #region Private properties

    [SerializeField] private Canvas _levelScreenCanvas;
    [SerializeField] private CanvasGroup _levelScreenCanvasGroup;

    #endregion

    #region Main methods

    private void Start() {
        _levelScreenCanvas.enabled = true;
        HideLevelScreen();
    }

    #endregion

    #region Private methods

    private void HideLevelScreen() {
        _levelScreenCanvasGroup.DOFade(0, 1.5f)
            .SetDelay(0.8f);
    }

    #endregion
}
