using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChocolateController : MonoBehaviour {

    private const string PLAYER_TAG = "Player";

    private void Start() {
        DOTween.Init();

        move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG))
            EventObserver.GetChocolateAction();
            gameObject.SetActive(false);
    }

    private void move() {
        transform.DOMoveY(transform.position.y + 0.5f, 3f).SetLoops(-1, LoopType.Yoyo);
    }
}
