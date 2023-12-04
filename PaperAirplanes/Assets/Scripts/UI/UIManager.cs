using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour, IDisposable {
    [SerializeField] private RectTransform _dialogsParent;

    private UICompanentsFactory _companentsFactory;
    private DialogFactory _dialogFactory;
    private DialogSwitcher _dialogSwitcher;
    private DialogMediator _dialogMediator;

    private Dictionary<DialogTypes, Dialog> _dialogsDictionary;
    private List<Dialog> _dialogs;

    public void Init(UICompanentsFactory companentsFactory, DialogFactory dialogFactory) {
        _companentsFactory = companentsFactory;
        _dialogFactory = dialogFactory;
        _dialogFactory.Init(_dialogsParent);
        
        CreateDialogs();

        _dialogSwitcher = new DialogSwitcher(this);
        _dialogMediator = new DialogMediator(this, _dialogSwitcher);

        _dialogSwitcher.ShowDialog(DialogTypes.Desktop);
    }

    public Dialog GetDialogByType(DialogTypes type) {
        if (_dialogsDictionary.Keys.Count == 0)
            throw new ArgumentNullException("DialogsDictionary is empty");

        return _dialogsDictionary[type];
    }

    public List<Dialog> GetDialogList() {
        return _dialogsDictionary.Values.ToList();
    }

    private void CreateDialogs() {
        _dialogsDictionary = new Dictionary<DialogTypes, Dialog> {
                { DialogTypes.Desktop, _dialogFactory.GetDialog<DesktopDialog>()},
                { DialogTypes.Planes, _dialogFactory.GetDialog<PlanesListDialog>()},
                { DialogTypes.Assembly, _dialogFactory.GetDialog<AssemblyDialog>()},
                { DialogTypes.About, _dialogFactory.GetDialog<AboutDialog>()}
            };

        foreach (var iDialog in _dialogsDictionary.Values) {
            iDialog.Init();
            iDialog.Show(false);
        }
    }

    public void Dispose() {
        
    }
}
