using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku.Models.Impl
{
    public class WinCharacterUnit : MonoBehaviour
    {
        [SerializeField] private Animator unitAnimator;
        [SerializeField] private float jumpForceMagnitude;

        private Rigidbody _rb;
        private bool _isGrounded;

        void Start()
        {
            _isGrounded = true;
            _rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (_isGrounded == true)
            {
                _rb.AddForce(transform.up * jumpForceMagnitude);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground") 
            {
                _isGrounded = true;
                _rb.velocity = new Vector3(0, 0, 0);
                this.enabled = false;
            }
        }
    }
}