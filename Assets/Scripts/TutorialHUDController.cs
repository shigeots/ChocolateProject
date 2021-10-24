using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialHUDController : MonoBehaviour {

    [SerializeField] GameObject _tutorialPanel;

    public void ShowTutorialPanel() {
        _tutorialPanel.transform.DOScale(1f, 0.8f)
                .SetEase(Ease.OutBack);
    }

    [ContextMenu("asdf")]
    public void HideTutorialPanel() {
        _tutorialPanel.transform.DOScale(0f, 0.5f);
        //_tutorialPanel.SetActive(false);
    }
}
