using UnityEngine;
[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    [SerializeField] private bool _isActive;

    [SerializeField] private Transform _lookObject;
    [SerializeField] private Transform _pointHandObject;
    [SerializeField] private float _valueWeight;
    private Animator _animator;

    private void Awake()
    {
        _animator.GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_animator)
        {
            if (_isActive)
            {
                if (_lookObject != null)
                {
                    _animator.SetLookAtWeight(1);
                    _animator.SetLookAtPosition(_lookObject.position);
                }

                if (_pointHandObject != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _valueWeight);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _valueWeight);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _pointHandObject.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _pointHandObject.rotation);
                }
            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetLookAtWeight(0);
            }
        }    
    }
}
