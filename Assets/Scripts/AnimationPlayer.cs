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

    private void Start()
    {
       // _animator.SetFloat(_blendAnimationHash, 0.7f);
    }
    void Moving()
    {
        if (MyRG.velocity.magnitude > 0)
            _animator.SetFloat(_blendAnimationHash, MyRG.velocity.magnitude);
    }

}
