using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblyStagesPanel : UIPanel {
    public event Action AssemblyCompleted;

    [SerializeField] private RectTransform _assemblyStageViewParent;
    [SerializeField] private Button _toStartButton;
    [SerializeField] private ScrollRect _scrollRect;

    private List<AssemblyStageView> _stageViewList = new List<AssemblyStageView>();
    private ModelConfig _modelConfig;
    private UICompanentsFactory _companentsFactory;

    private int _remainsToComplete;

    public void Init(ModelConfig modelConfig, UICompanentsFactory companentsFactory) {
        if (_modelConfig == modelConfig) 
            return;

        _modelConfig = modelConfig;
        _companentsFactory = companentsFactory;
        _remainsToComplete = _modelConfig.Schema.Count;

        AddListeners();
        UpdateContent();
    }

    public override void AddListeners() {
        base.AddListeners();
        _toStartButton.onClick.AddListener(ToStartButtonClick);
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        foreach (var iStage in _stageViewList) {
            iStage.StageCompleted -= OnStageCompleted;
        }

        _toStartButton.onClick.RemoveListener(ToStartButtonClick);
    }

    public override void UpdateContent() {
        base.UpdateContent();
        
        if (_stageViewList.Count > 0)
            ClearStageViewList();

        CreateModelSelectorViewList();
        ToStartButtonClick();
    }

    private void CreateModelSelectorViewList() {
        for (int i = 1; i < _modelConfig.Schema.Count; i++) {
            Sprite iSprite = _modelConfig.Schema[i];
            AssemblyStageViewConfig newConfig = new AssemblyStageViewConfig(i, iSprite);
            AssemblyStageView newView = _companentsFactory.Get<AssemblyStageView>(newConfig, _assemblyStageViewParent);

            newView.Init(newConfig);
            newView.StageCompleted += OnStageCompleted;

            _stageViewList.Add(newView);
        }
    }

    private void OnStageCompleted(AssemblyStageViewConfig stageConfig) {
        _remainsToComplete -= 1;

        if (_remainsToComplete == 0)
            AssemblyCompleted?.Invoke();
    }

    private void ToStartButtonClick() {
        _scrollRect.verticalNormalizedPosition = 1;
    }

    private void ClearStageViewList() {
        foreach (var iView in _stageViewList) {
            Destroy(iView.gameObject);
        }

        _stageViewList.Clear();
    }

}
