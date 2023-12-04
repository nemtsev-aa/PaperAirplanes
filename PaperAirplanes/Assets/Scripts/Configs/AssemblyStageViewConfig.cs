using UnityEngine;

public class AssemblyStageViewConfig : UICompanentConfig {
    public AssemblyStageViewConfig(int stageIndex, Sprite icon) {
        StageIndex = stageIndex;
        Icon = icon;
    }

    public int StageIndex { get; private set; }
    public Sprite Icon { get; private set; }

    public override void OnValidate() { }
}
