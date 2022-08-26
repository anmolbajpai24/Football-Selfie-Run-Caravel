// using System;
// using Baracuda.Monitoring;
using DG.Tweening;

using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        // [SerializeField] private PlayerParticleEffects _playerParticleEffects;
        // [SerializeField] private PlayerGotSpeedBoost playerGotSpeedBoost;
        // [SerializeField] private PlayerCombo playerCombo;
        public CharacterController controller;
        [SerializeField] float moveSpeed = 5f;

        [FormerlySerializedAs("moveSpeedBuff")]  [SerializeField]
        float moveSpeedBuffCombo = 0f;

         [SerializeField] float moveSpeedBuffPadle = 0f;
        [SerializeField] float moveSpeedIncrementOnSpeedBoost = 3f;
        [SerializeField] float speedBoostLastingTime = 2f;
        [SerializeField] private bool alwaysRun;
        //private PlayerAnimationController _playerAnimationController;

        //private void OnEnable() => this.RegisterMonitor();

        //private void OnDisable() => this.UnregisterMonitor();

        public void IncrementMoveSpeedBuff() => moveSpeedBuffCombo += 0.5f;

        public void ResetMoveSpeedBuffCombo() => moveSpeedBuffCombo = 0;
        public void ResetMoveSpeedBuffPadel() => moveSpeedBuffPadle = 0;

        public void MoveSpeedBuffOnPedel() => moveSpeedBuffPadle -= 3;

        public void MoveSpeedBuffAfterPedel() => moveSpeedBuffPadle = 0;

        public void DoSetMoveSpeedBuffer(int value) => moveSpeedBuffCombo = value / 2f;

        void DecrementMoveSpeedBuffer() => moveSpeedBuffCombo -= 0.5f;

        //private void Awake() => _playerAnimationController = GetComponent<PlayerAnimationController>();

        public void OnSpeedBoostTrigger()
        {
            moveSpeed += moveSpeedIncrementOnSpeedBoost;
            Invoke(nameof(SpeedBoostEndes), speedBoostLastingTime);
        }

        void SpeedBoostEndes() => moveSpeed -= moveSpeedIncrementOnSpeedBoost;


        private Vector3 _moveDirection;
        private Vector3 _previewsMoveDirection;
        private Vector2 _moveInput;

        public void SetInputVector(Vector2 input) => _moveInput = input;

        private void Start()
        {
            if (alwaysRun)
            {
               // _playerAnimationController.DoSetAnimationState(AllPlayerAnimationState.RunAnimationState);
            }
            else
            {
               // _playerAnimationController.DoSetAnimationState(AllPlayerAnimationState.IdleAnimationState);
            }
        }

        private void Update() => HandleMovement();

        private float targetTargetAngle = 0;
        private void HandleRotation(Vector3 lookAt)
        {
            float targetAngle = Mathf.Atan2(lookAt.x, lookAt.z) * Mathf.Rad2Deg;
            if (lookAt != Vector3.zero) targetTargetAngle = Mathf.MoveTowardsAngle(targetTargetAngle, targetAngle, 0.5f);
            Debug.Log(targetAngle);
            Debug.Log(targetTargetAngle);
            transform.DORotate(new Vector3(0, targetTargetAngle, 0), 0.5f);
        }

        private void HandleMovement()
        {
            //if (LevelManager.instance.DoGetCurrentLevelState() != AllLevelStates.GamePlay) return;

            if (_moveInput == Vector2.zero)
            {
                if (alwaysRun == false)
                {
                    //_playerParticleEffects.DoSetPlayerParticleState(AllPlayerParticleStates.NotRunning);
                    //AudioManager.instance.FootStepStartAndStope(false);
                    //_playerAnimationController.DoSetAnimationState(AllPlayerAnimationState.IdleAnimationState);
                    return;
                }


                //AudioManager.instance.FootStepStartAndStope(true);
                //_playerAnimationController.DoSetAnimationState(AllPlayerAnimationState.RunAnimationState);
                Vector3 transformForward = transform.forward;
                _moveDirection = transformForward;
                _moveDirection *= moveSpeed;
                _moveDirection += transformForward;
            }
            else
            {
                //_playerParticleEffects.DoSetPlayerParticleState(AllPlayerParticleStates.Running);
                //AudioManager.instance.FootStepStartAndStope(true);
                //if ((playerCombo.DoGetCurrentComboValue() == 5) || (playerGotSpeedBoost.IsOnSpeedBoost))
                //{
                //    _playerAnimationController.DoSetAnimationState(AllPlayerAnimationState.FastRunAnimationState);
                //}
                //else
                
                //_playerAnimationController.DoSetAnimationState(AllPlayerAnimationState.RunAnimationState);

                _moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
                _moveDirection = _moveDirection.normalized;
                _moveDirection = new Vector2(_moveDirection.x*0.001f, _moveDirection.y*0.001f);
                //_moveDirection *= (moveSpeed + moveSpeedBuffCombo + moveSpeedBuffPadle);
                _moveDirection += transform.forward;

                HandleRotation(new Vector3(_moveInput.x*0.001f, 0, _moveInput.y*0.001f));
            }

            controller.SimpleMove(_moveDirection);
        }
    }
}

public enum AllPlayerState
{
}