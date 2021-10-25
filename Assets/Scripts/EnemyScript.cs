using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private float _speedOfMovement;
    [SerializeField] private Transform _footGroundCheckTransform;
    [SerializeField] private Transform _frontGroundCheckTransform;
    [SerializeField] private LayerMask _groundLayer;

    private bool _mustPatrol = true;
    private bool _mustTurn = false;
    private bool _frontIsGround = false;

    private void Update() {
        if(_mustPatrol) {
            Patrol();
        }
    }

    private void FixedUpdate() {
        if(_mustPatrol) {
            CheckFrontEnemy();
            _mustTurn = !Physics2D.OverlapCircle(_footGroundCheckTransform.position, 0.1f, _groundLayer);
        }
    }

    private void CheckFrontEnemy() {
        _frontIsGround = Physics2D.BoxCast(_frontGroundCheckTransform.position, new Vector2(0.2f , 0.5f), 0f, Vector2.right, 0f, _groundLayer);
    }

    private void Patrol() {
        if(_mustTurn || _frontIsGround)
            Flip();

        _rigidbody2D.velocity = new Vector2(_speedOfMovement * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
    }

    private void Flip() {
        _mustPatrol = false;
        _frontIsGround = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        _speedOfMovement *= -1;
        _mustPatrol = true;
    }
}
