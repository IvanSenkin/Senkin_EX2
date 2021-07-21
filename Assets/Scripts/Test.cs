using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] public Image _hpBar;
    public float _fill;   
    private void Start()
    {
        _fill = 1f;
    }
    private void Awake()
    {
        PlayerMove.changeHP += UpdateHP;
    }
    private void UpdateHP(int hp)
    {
        _hpBar.fillAmount = hp * 0.01f; ;
    }  
}