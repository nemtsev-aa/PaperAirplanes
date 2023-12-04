using System;
using UnityEngine;

public class AssemblyDialog : Dialog {
    public event Action AssemblyCompleted;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    private ModelConfig _modelConfig;
    private AssemblyStagesPanel _assemblyPanel;

    public void SetModelConfig(ModelConfig modelConfig) {
        _modelConfig = modelConfig;

        _assemblyPanel = GetPanelByType<AssemblyStagesPanel>();
        _assemblyPanel.Init(_modelConfig, _companentsFactory);
        _assemblyPanel.AssemblyCompleted += OnAssemblyCompleted;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();
        _assemblyPanel.AssemblyCompleted -= OnAssemblyCompleted;
    }

    private void OnAssemblyCompleted() => AssemblyCompleted?.Invoke();
}
