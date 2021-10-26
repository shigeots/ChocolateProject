using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuScreenController : MonoBehaviour {

    #region Private properties

    [SerializeField] RectTransform _title;
    [SerializeField] GameObject _pressEnter;
    [SerializeField] Canvas _mainMenuScreenCanvas;

    private const string SCENE_NAME = "Level0";

    #endregion

    #region Main methods
    
    private void Start() {
        DOTween.Init();

        _mainMenuScreenCanvas.enabled = true;

        ShowTitle();
        ShowPressEnter();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            LoadScene();
        }
    }

    #endregion

    #region Private methods

    private void ShowTitle() {
        _title.DOAnchorPos(new Vector2(0,0), 2.5f)
                .SetEase(Ease.OutBounce);
    }

    private void ShowPressEnter() {
        _pressEnter.transform.DOScale(1, 1.2f)
                .SetDelay(2.5f);
    }

    private void LoadScene() {
        SceneManager.LoadScene(SCENE_NAME);
    }

    #endregion
}
