using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class AssemblyStageView : UICompanent {
    public event Action<AssemblyStageViewConfig> StageCompleted;

    [SerializeField] private TextMeshProUGUI _stageLabel;
    [SerializeField] private Image _icon;
    [SerializeField] private Toggle _toggle;

    private AssemblyStageViewConfig _viewConfig;
    public Toggle Toggle => _toggle;

    public void Init(AssemblyStageViewConfig viewConfig) {
        _viewConfig = viewConfig;

        UpdateCompanents();
        AddListeners();
    }

    private void UpdateCompanents() {
        name = $"{_viewConfig.StageIndex}";
        _stageLabel.text = $"Этап {_viewConfig.StageIndex}";
        _icon.sprite = _viewConfig.Icon;
        _toggle.isOn = false;
    }

    private void AddListeners() {
        _toggle.onValueChanged.AddListener(ToggleClick);
    }

    private void RemoveListeners() {
        _toggle.onValueChanged.RemoveListener(ToggleClick);
    }

    private void ToggleClick(bool value) {
        if (value == true)
            StageCompleted?.Invoke(_viewConfig);
    }

    public override void Dispose() {
        base.Dispose();
        RemoveListeners();
    }
}
