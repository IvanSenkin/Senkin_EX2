using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightSettings : MonoBehaviour
{
    [SerializeField] private Color _colorSky;
    [SerializeField] private Color _colorEquator;
    [SerializeField] private Color _colorGround;
    [SerializeField] private Color _colorLight;

    private Light _light;
    private void Awake()
    {
        _light = GetComponent<Light>();
        ChangeAmbientColor();
    }
    private void ChangeAmbientColor()
    {
        RenderSettings.ambientSkyColor = _colorSky;
        RenderSettings.ambientEquatorColor = _colorEquator;
        RenderSettings.ambientGroundColor = _colorGround;

        _light.color = _colorLight;
    }
}
