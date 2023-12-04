using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private ModelConfigs _modelConfigs;

    [SerializeField] private DialogFactory _dialogFactory;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    private void Start() {
        _uIManager.Init(_companentsFactory, _dialogFactory);
        
    }
}
