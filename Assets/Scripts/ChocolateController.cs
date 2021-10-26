using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChocolateController : MonoBehaviour {

    #region Private properties

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _chocolateAudioClip;

    private const string PLAYER_TAG = "Player";

    #endregion

    #region Main methods

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
            PlayChocolateSound();
            EventObserver.GetChocolateEvent();
            _spriteRenderer.enabled = false;
            _boxCollider2D.enabled = false;
        }
    }

    #endregion

    #region Private methods

    private void ActivateChocolate() {
        _spriteRenderer.enabled = true;
        _boxCollider2D.enabled = true;
    }

    private void Move() {
        transform.DOMoveY(transform.position.y + 0.5f, 3f).SetLoops(-1, LoopType.Yoyo);
    }

    private void PlayChocolateSound() {
        _audioSource.Stop();
        _audioSource.clip = _chocolateAudioClip;
        _audioSource.Play();
    }

    #endregion
}
