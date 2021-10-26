using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour {

    #region Private properties

    [SerializeField] private Canvas _canvas = null;
    [SerializeField] private RawImage _scrollableImage = null;
    [SerializeField] private float _scrollSpeed = 0.1f;
    
    private Rect _rect;

    #endregion

    #region Main methods

    private void Start() {
        _rect = _scrollableImage.uvRect;
    }

    private void Update() {
        if(_canvas.enabled == true) {
            ScrollRawImage();
        }
    }

    #endregion

    #region Private methods

    private void ScrollRawImage() {
        _rect.y += _scrollSpeed * Time.deltaTime;
        _scrollableImage.uvRect = _rect;
    }

    #endregion

}
