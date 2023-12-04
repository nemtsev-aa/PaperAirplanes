using UnityEngine;

public class ModelSelectorConfig : UICompanentConfig {
    public ModelSelectorConfig(int index, Sprite icon) {
        Index = index;
        Icon = icon;
    }

    public int Index { get; private set; }
    public Sprite Icon { get; private set; }

    public override void OnValidate() { }
}
