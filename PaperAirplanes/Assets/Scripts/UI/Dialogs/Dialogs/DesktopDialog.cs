using System;

public class DesktopDialog : Dialog {
    public event Action PlanesDialogShowed;
    public event Action AboutDialogShowed;
    public event Action Quited;

    private MenuCategoryPanel _category;

    public override void Init() {
        base.Init();
    }

    public override void InitializationPanels() {
        _category = GetPanelByType<MenuCategoryPanel>();
        _category.Init();
    }

    public override void AddListeners() {
        base.AddListeners();

        _category.PlanesListDialogSelected += OnPlanesListDialogSelected;
        _category.AboutDialogSelected += OnAboutDialogSelected;
        _category.QuitButtonSelected += OnQuitButtonSelected;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _category.PlanesListDialogSelected -= OnPlanesListDialogSelected;
        _category.AboutDialogSelected -= OnAboutDialogSelected;
        _category.QuitButtonSelected -= OnQuitButtonSelected;
    }


    private void OnPlanesListDialogSelected() => PlanesDialogShowed?.Invoke();

    private void OnAboutDialogSelected() => AboutDialogShowed?.Invoke();

    private void OnQuitButtonSelected() => Quited?.Invoke();
}
