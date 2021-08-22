using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class TestProcSettings : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _PostProcessVolume;

    private ColorGrading _colorGrading;
    

    private void Start()
    {
        settingsColorgrending();
        _PostProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 2, _colorGrading);
    }

    private void settingsColorgrending()
    {
        _colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        _colorGrading.enabled.Override(true);
        _colorGrading.temperature.Override(1);
    }

    private void Update()
    {       
        _colorGrading.temperature.value = 10 * Mathf.Sin(Time.realtimeSinceStartup);
    }
    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(_PostProcessVolume, true, true);
    }
}
