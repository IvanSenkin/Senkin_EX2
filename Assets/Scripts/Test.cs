using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] public Image _hpBar;
    public float _fill;
    public Color myColor;
   // [SerializeField] public Texture2D icon;
   
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
    void OnGUI()
    {
        myColor = RGBSlider(new Rect(10, 10, 100, 20), myColor); 
       //GUI.Box(new Rect(Screen.width -120 , 10, 90, 20), icon);
        
    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");
        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "rgb.a");

        return rgb;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f, sliderMaxValue);
        return sliderValue;
    }
}