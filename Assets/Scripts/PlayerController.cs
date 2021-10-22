using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Private properties

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speedOfMovement = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask _groundLayer;

    private int _remainingJumps = 2;
    private const int _maximumNumberOfJumps = 2;
    private bool _lookRight = true;
    private bool _jump = false;

    #endregion

    #region Main methods

    private void Start() {
        Initialize();
    }

    private void Update() {
        Move();

        if(CheckGround()) {
            _remainingJumps = _maximumNumberOfJumps;
        }

        if(Input.GetKeyDown(KeyCode.Space) && _remainingJumps > 0) {
            _jump = true;
        }
    }

    private void FixedUpdate() {
        Jump();
    }

    #endregion

    #region Private methods

    private void Initialize() {
        _remainingJumps = _maximumNumberOfJumps;
    }

    private bool CheckGround() {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.up * -1, 0.1f, _groundLayer);
        return raycastHit2D.collider != null;
    }

    private void Move() {
        float inputMovement = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(inputMovement * _speedOfMovement, _rigidbody2D.velocity.y);

        Flip(inputMovement);
    }

    private void Flip(float inputMovement) {
        if((_lookRight && inputMovement < 0) || (!_lookRight && inputMovement > 0)) {
            _lookRight = !_lookRight;

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Jump() {
        if(_jump && _remainingJumps > 0) {
            _jump = false;
            _remainingJumps--;
            
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    #endregion
}
