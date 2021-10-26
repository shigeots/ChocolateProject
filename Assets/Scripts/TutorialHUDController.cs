using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialHUDController : MonoBehaviour {

    #region Private properties

    [SerializeField] GameObject _tutorialPanel;

    #endregion

    #region Internal methods

    internal void ShowTutorialPanel() {
        _tutorialPanel.transform.DOScale(1f, 0.8f)
                .SetEase(Ease.OutBack);
    }

    internal void HideTutorialPanel() {
        _tutorialPanel.transform.DOScale(0f, 0.5f);
    }

    #endregion
}
