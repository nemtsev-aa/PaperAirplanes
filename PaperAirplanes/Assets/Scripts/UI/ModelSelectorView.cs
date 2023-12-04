using System;
using UnityEngine;
using UnityEngine.UI;

public class ModelSelectorView : UICompanent {
    public event Action<ModelConfig> SelectedModelSelectorViewChanged;

    [SerializeField] private Image _icon;
    [SerializeField] private Toggle _toggle;

    private ModelViewConfig _viewConfig;
    public Toggle Toggle => _toggle;

    public void Init(ModelViewConfig viewConfig) {
        _viewConfig = viewConfig;

        UpdateCompanents();
        AddListeners();
    }

    private void UpdateCompanents() {
        name = $"{_viewConfig.Index}";
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
            SelectedModelSelectorViewChanged?.Invoke(_viewConfig.Config);
    }

    public override void Dispose() {
        base.Dispose();
        RemoveListeners();
    }
}