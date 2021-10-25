using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChocolateController : MonoBehaviour {

    private const string PLAYER_TAG = "Player";

    private void Awake() {
        EventObserver.RespawnPlayerEvent += ActivateChocolate;
    }

    private void OnDestroy() {
        EventObserver.RespawnPlayerEvent -= ActivateChocolate;
    }

    private void Start() {
        DOTween.Init();

        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG)) {
            EventObserver.GetChocolateEvent();
            gameObject.SetActive(false);
        }
    }

    private void ActivateChocolate() {
        gameObject.SetActive(true);
    }

    private void Move() {
        transform.DOMoveY(transform.position.y + 0.5f, 3f).SetLoops(-1, LoopType.Yoyo);
    }
}
