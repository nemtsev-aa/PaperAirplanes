using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelListPanel : UIPanel {
    public event Action<ModelConfig> ModelConfigSelected;

    [SerializeField] private RectTransform _modelSelectorViewParent;
    [SerializeField] private ToggleGroup _modelSelectorViewGroup;
    
    private List<ModelSelectorView> _modelViewList = new List<ModelSelectorView>();
    private ModelConfigs _modelConfigs;
    private UICompanentsFactory _companentsFactory;

    public void Init(ModelConfigs modelConfigs, UICompanentsFactory companentsFactory) {
        _modelConfigs = modelConfigs;
        _companentsFactory = companentsFactory;

        AddListeners();
        UpdateContent();
    }

    public override void AddListeners() {
        base.AddListeners();
        
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

    }

    public override void UpdateContent() {
        base.UpdateContent();
        if (_modelViewList.Count == 0)
            CreateModelSelectorViewList();

        _modelViewList[0].Toggle.isOn = true;
    }

    private void CreateModelSelectorViewList() {
        foreach (var iConfig in _modelConfigs.Configs) {
            ModelViewConfig newConfig = new ModelViewConfig(iConfig);
            ModelSelectorView newView = _companentsFactory.Get<ModelSelectorView>(newConfig, _modelSelectorViewParent);

            newView.Toggle.group = _modelSelectorViewGroup;
            newView.Init(newConfig);
            newView.SelectedModelSelectorViewChanged += OnModelSelectorViewChanged;
            
            _modelViewList.Add(newView);
        }
    }

    private void OnModelSelectorViewChanged(ModelConfig config) => ModelConfigSelected?.Invoke(config);

}
