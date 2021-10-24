using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuScreenController : MonoBehaviour {

    [SerializeField] RectTransform _title;
    [SerializeField] GameObject _pressEnter;

    private const string SCENE_NAME = "Level0";
    
    private void Start() {
        DOTween.Init();

        ShowTitle();
        ShowPressEnter();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            LoadScene();
        }
    }

    private void ShowTitle() {
        _title.DOAnchorPos(new Vector2(0,0), 2.5f)
                .SetEase(Ease.OutBounce);
    }

    private void ShowPressEnter() {
        _pressEnter.transform.DOScale(1, 1.2f)
                //.SetEase(Ease.OutBack)
                .SetDelay(2.5f);
    }

    private void LoadScene() {
        SceneManager.LoadScene(SCENE_NAME);
    }
}
