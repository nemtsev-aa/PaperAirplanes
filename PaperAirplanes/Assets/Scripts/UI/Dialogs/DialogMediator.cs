using UnityEngine;
using System;

public class DialogMediator : IDisposable {
    private UIManager _uIManager;

    public DialogMediator(UIManager uIManager, DialogSwitcher dialogSwitcher) {
        _uIManager = uIManager;
        _dialogSwitcher = dialogSwitcher;

        GetDialogs();
        AddListeners();
    }

    private DesktopDialog _desktopDialog;
    private PlanesListDialog _planesListDialog;
    private AssemblyDialog _assemblyDialog;
    private AboutDialog _aboutDialog;

    private DialogSwitcher _dialogSwitcher;

    private void GetDialogs() {
        _desktopDialog = _uIManager.GetDialogByType(DialogTypes.Desktop).GetComponent<DesktopDialog>();
        _planesListDialog = _uIManager.GetDialogByType(DialogTypes.Planes).GetComponent<PlanesListDialog>();
        _assemblyDialog = _uIManager.GetDialogByType(DialogTypes.Assembly).GetComponent<AssemblyDialog>();
        _aboutDialog = _uIManager.GetDialogByType(DialogTypes.About).GetComponent<AboutDialog>();
    }

    private void AddListeners() {
        SubscribeToDesktopDialogActions();
        SubscribeToPlanesListDialogActions();
        SubscribeToAssemblyDialogActions();
        SubscribeToAboutDialogActions();
    }

    private void RemoveListeners() {
        UnsubscribeToDesktopDialogActions();
        UnsubscribeToPlanesListDialogActions();
        UnsubscribeToAssemblyDialogActions();
        UnsubscribeToAboutDialogActions();
    }

    #region DesktopDialogActions
    private void SubscribeToDesktopDialogActions() {
        _desktopDialog.PlanesDialogShowed += OnPlanesDialogShowed;
        _desktopDialog.AboutDialogShowed += OnAboutDialogShowed;
        _desktopDialog.Quited += OnQuited;
        _desktopDialog.BackClicked += OnQuited;
    }

    private void UnsubscribeToDesktopDialogActions() {
        _desktopDialog.PlanesDialogShowed -= OnPlanesDialogShowed;
        _desktopDialog.AboutDialogShowed -= OnAboutDialogShowed;
        _desktopDialog.Quited -= OnQuited;
        _desktopDialog.BackClicked -= OnQuited;
    }

    private void OnPlanesDialogShowed() => _dialogSwitcher.ShowDialog(DialogTypes.Planes);

    private void OnAboutDialogShowed() => _dialogSwitcher.ShowDialog(DialogTypes.About);

    private void OnQuited() => Application.Quit();

    #endregion

    #region PlanesListDialogActions

    private void SubscribeToPlanesListDialogActions() {
        _planesListDialog.ModelConfigSelected += OnModelConfigSelected;
        _planesListDialog.BackClicked += OnPlanesListDialogBackClicked;
    }

    private void UnsubscribeToPlanesListDialogActions() {
        _planesListDialog.ModelConfigSelected -= OnModelConfigSelected;
        _planesListDialog.BackClicked -= OnPlanesListDialogBackClicked;
    }

    private void OnModelConfigSelected(ModelConfig config) {
        _assemblyDialog.SetModelConfig(config);
        _dialogSwitcher.ShowDialog(DialogTypes.Assembly);
    }

    private void OnPlanesListDialogBackClicked() => _dialogSwitcher.ShowDialog(DialogTypes.Desktop);
    #endregion

    #region AssemblyDialogActions
    private void SubscribeToAssemblyDialogActions() {
        _assemblyDialog.BackClicked += OnAssemblyDialogBackClicked;
        _assemblyDialog.AssemblyCompleted += OnAssemblyCompleted;
    }

    private void UnsubscribeToAssemblyDialogActions() {
        _assemblyDialog.BackClicked -= OnAssemblyDialogBackClicked;
        _assemblyDialog.AssemblyCompleted -= OnAssemblyCompleted;
    }

    private void OnAssemblyDialogBackClicked() => _dialogSwitcher.ShowDialog(DialogTypes.Planes);

    private void OnAssemblyCompleted() { }

    #endregion

    #region AboutDialogActions
    private void SubscribeToAboutDialogActions() {
        _aboutDialog.BackClicked += OnPlanesListDialogBackClicked;
    }

    private void UnsubscribeToAboutDialogActions() {
        _aboutDialog.BackClicked -= OnPlanesListDialogBackClicked;
    }

    #endregion

    public void Dispose() {
        RemoveListeners();
    }
}