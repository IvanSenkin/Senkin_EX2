using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class TestSettingsCamera : MonoBehaviour
{
    [SerializeField] private Button _firstSettingsButton;
    [SerializeField] private Button _secondSettingsButton;
    [SerializeField] private PostProcessProfile _firstPostProcessProfile;
    [SerializeField] private PostProcessProfile _secondPostProcessProfile;
    [SerializeField] private PostProcessVolume _PostProcessVolume;

    private void Start()
    {
        _firstSettingsButton.onClick.AddListener(() => ChangeSettings(true));
        _secondSettingsButton.onClick.AddListener(() => ChangeSettings(false));
    }
    private void OnDestroy()
    {
        _firstSettingsButton.onClick.RemoveAllListeners();
        _secondSettingsButton.onClick.RemoveAllListeners();
    }
    private void ChangeSettings(bool isfirstPostProcess)
    {
        _PostProcessVolume.profile = isfirstPostProcess ? _firstPostProcessProfile : _secondPostProcessProfile;
    }
}
