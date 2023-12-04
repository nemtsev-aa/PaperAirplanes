using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuCategoryPanel : UIPanel {
    public event Action PlanesListDialogSelected;
    public event Action AboutDialogSelected;
    public event Action QuitButtonSelected;

    [SerializeField] private Button _planesListButton;
    [SerializeField] private Button _aboutButton;
    [SerializeField] private Button _quitButton;

    public void Init() {
        AddListeners();
    }

    public override void AddListeners() {
        base.AddListeners();

        _planesListButton.onClick.AddListener(PlanesListButtonClick);
        _aboutButton.onClick.AddListener(AboutButtonClick);
        _quitButton.onClick.AddListener(QuitButtonClick);
    }

    public override void RemoveListeners() {
        _planesListButton.onClick.RemoveListener(PlanesListButtonClick);
        _aboutButton.onClick.RemoveListener(AboutButtonClick);
        _quitButton.onClick.RemoveListener(QuitButtonClick);
    }

    public override void Show(bool value) {
        base.Show(value);

    }

    private void PlanesListButtonClick() => PlanesListDialogSelected?.Invoke();

    private void AboutButtonClick() => AboutDialogSelected?.Invoke();

    private void QuitButtonClick() => QuitButtonSelected?.Invoke();

}
