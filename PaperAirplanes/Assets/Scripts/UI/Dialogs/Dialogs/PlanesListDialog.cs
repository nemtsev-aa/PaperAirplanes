using System;
using UnityEngine;
using UnityEngine.UI;

public class PlanesListDialog : Dialog {
    public event Action<ModelConfig> ModelConfigSelected;

    [SerializeField] private UICompanentsFactory _companentsFactory;
    [SerializeField] private ModelConfigs _modelConfigs;
    [SerializeField] private Button _selectionButton;

    private ModelListPanel _modelListPanel;
    private ModelConfig _config;

    public override void Init() {
        base.Init();

        _config = _modelConfigs.Configs[0];
    }

    public override void InitializationPanels() {
        _modelListPanel = GetPanelByType<ModelListPanel>();
        _modelListPanel.Init(_modelConfigs, _companentsFactory);
        _modelListPanel.Show(true);
    }

    public override void AddListeners() {
        base.AddListeners();

        _modelListPanel.ModelConfigSelected += OnSelectedPolyhedraChanged;
        _selectionButton.onClick.AddListener(SelectionButtonClick);
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _modelListPanel.ModelConfigSelected -= OnSelectedPolyhedraChanged;
        _selectionButton.onClick.RemoveListener(SelectionButtonClick);
    }

    private void OnSelectedPolyhedraChanged(ModelConfig config) => _config = config;

    private void SelectionButtonClick() => ModelConfigSelected?.Invoke(_config);

}
