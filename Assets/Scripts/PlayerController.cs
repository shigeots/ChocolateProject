using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Private properties

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpAudioClip;
    [SerializeField] private AudioClip _dashAudioClip;
    [SerializeField] private float _speedOfMovement = 5f;
    [SerializeField] private float _jumpForce = 4f;
    [SerializeField] private float _doubleJumpForce = 3f;
    [SerializeField] private float _dashDistance = 5f;
    [SerializeField] private LayerMask _groundLayer;


    private float _playerGravity;

    private float _xAxis;
    private bool _lookRight = true;
    private bool _jump = false;
    private bool _doubleJump = false;
    private bool _dash = false;
    private bool _isGrounded = false;
    private bool _isJumping = false;
    private bool _isDoubleJumping = false;
    private bool _toRemoveChocolate = true;
    private string _currentAnimationState;
    private int _amountOfChocolate = 0;
    private Vector2 _respawnPoint;

    private const string PLAYER_IDLE_ANIMATION = "PlayerIdle";
    private const string PLAYER_WALK_ANIMATION = "PlayerWalk";
    private const string PLAYER_JUMP_ANIMATION = "PlayerJump";
    private const string PLAYER_DOUBLE_JUMP_ANIMATION = "PlayerDoubleJump";
    private const string PLAYER_DASH_ANIMATION = "PlayerDash";
    private const string DEAD_ZONE_TAG = "DeadZone";

    #endregion

    #region Main methods

    private void Start() {
        Initialize();

        EventObserver.GetChocolateEvent += AddChocolate;
    }

    private void OnDestroy() {
        EventObserver.GetChocolateEvent -= AddChocolate;
    }

    private void Update() {

        _xAxis = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && _isJumping && !_isDoubleJumping) {
            _isDoubleJumping = true;
            _doubleJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded) {
            _isJumping = true;
            _jump = true;
        }

        if(Input.GetKeyDown(KeyCode.J) && _amountOfChocolate > 0) {
            _dash = true;
            RemoveChocolate();
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            Respawn();
        }

    }

    private void FixedUpdate() {
        CheckGround();
        Move();
        Dash();
        DoubleJump();
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(DEAD_ZONE_TAG)) {
            Respawn();
        }
    }

    #endregion

    #region Private methods

    private void Initialize() {
        _playerGravity = _rigidbody2D.gravityScale;
        _respawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    private void CheckGround() {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.up * -1, 0.1f, _groundLayer);

        if(raycastHit2D.collider != null) {
            _isGrounded = true;
            _isJumping = false;
            _isDoubleJumping = false;
        } else {
            _isGrounded = false;
            _isJumping = true;
        }

        if(!_dash && _isGrounded && _xAxis == 0) {
            ChangeAnimationState(PLAYER_IDLE_ANIMATION);
        }

        if(!_dash && _isGrounded && _xAxis != 0)
            ChangeAnimationState(PLAYER_WALK_ANIMATION);

        //return raycastHit2D.collider != null;
    }

    private void Move() {

        if(!_dash && _xAxis != 0) {

            _rigidbody2D.velocity = new Vector2(_xAxis * _speedOfMovement, _rigidbody2D.velocity.y);

            Flip(_xAxis);
            
        }
        if(!_dash && _xAxis == 0) {

            _rigidbody2D.velocity = new Vector2(0f, _rigidbody2D.velocity.y);            
        }

    }

    private void Flip(float inputMovement) {
        if((_lookRight && inputMovement < 0) || (!_lookRight && inputMovement > 0)) {
            _lookRight = !_lookRight;

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Jump() {
        if(_jump) {
            
            _jump = false;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            PlayJumpSound();
            ChangeAnimationState(PLAYER_JUMP_ANIMATION);
        }
    }

    private void DoubleJump() {
        if(_doubleJump && _isJumping) {
            
            _doubleJump = false;
            _isDoubleJumping = true;

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
            _rigidbody2D.AddForce(Vector2.up * _doubleJumpForce, ForceMode2D.Impulse);

            PlayJumpSound();
            ChangeAnimationState(PLAYER_DOUBLE_JUMP_ANIMATION);
        }
    }

    private void AddChocolate() {
        _amountOfChocolate++;
        EventObserver.UpdateDashTextEvent(_amountOfChocolate);
    }

    private void RemoveChocolate() {
        if(_amountOfChocolate > 0 && _toRemoveChocolate) {
            _toRemoveChocolate = false;
            _amountOfChocolate--;
            PlayDashSound();
            EventObserver.UpdateDashTextEvent(_amountOfChocolate);
        }
    }

    private void Dash() {
        if(_dash) {
            StartCoroutine(DashCoroutine());
        }
    }

    private void ChangeAnimationState(string newAnimationState) {
        if(_currentAnimationState == newAnimationState)
            return;

        _animator.Play(newAnimationState);

        _currentAnimationState = newAnimationState;
    }

    private void Respawn() {
        transform.position = new Vector2(_respawnPoint.x, _respawnPoint.y);
        _amountOfChocolate = 0;
        _rigidbody2D.velocity = new Vector2(0f, 0f);
        EventObserver.UpdateDashTextEvent(_amountOfChocolate);
        EventObserver.RespawnPlayerEvent();
    }

    private void PlayJumpSound() {
        _audioSource.Stop();
        _audioSource.clip = _jumpAudioClip;
        _audioSource.Play();
    }

    private void PlayDashSound() {
        _audioSource.Stop();
        _audioSource.clip = _dashAudioClip;
        _audioSource.Play();
    }

    #endregion

    #region IEnumerator

    private IEnumerator DashCoroutine() {

        float direction = 0f;

        if(_lookRight)
            direction = 1f;
        if(!_lookRight)
            direction = -1f;

        _rigidbody2D.velocity = new Vector2(0f, 0f);
        _rigidbody2D.AddForce(new Vector2(_dashDistance * direction, 0f), ForceMode2D.Impulse);
        _rigidbody2D.gravityScale = 0;
        ChangeAnimationState(PLAYER_DASH_ANIMATION);
        
        yield return new WaitForSeconds(0.2f);
        _dash = false;
        _toRemoveChocolate = true;
        _rigidbody2D.gravityScale = _playerGravity;
    }
    
    #endregion
}
