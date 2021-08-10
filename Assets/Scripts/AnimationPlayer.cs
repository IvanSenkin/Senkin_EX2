using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private string _blendAnimation;
    Rigidbody MyRG;
    private Animator _animator;
    private int _blendAnimationHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _blendAnimationHash = Animator.StringToHash(_blendAnimation);
        MyRG = GetComponent<Rigidbody>();
    }
}
