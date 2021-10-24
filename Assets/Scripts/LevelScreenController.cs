using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelScreenController : MonoBehaviour {

    [SerializeField] private Canvas _levelScreenCanvas;
    [SerializeField] private CanvasGroup _levelScreenCanvasGroup;

    private void Start() {
        _levelScreenCanvas.enabled = true;
        HideLevelScreen();
    }

    public void HideLevelScreen() {
        _levelScreenCanvasGroup.DOFade(0, 1.5f)
            .SetDelay(0.8f);
    }
}
