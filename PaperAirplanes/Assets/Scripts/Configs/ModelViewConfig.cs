using UnityEngine;
using System;

[Serializable]
public class ModelViewConfig : UICompanentConfig {
    public ModelViewConfig(ModelConfig config) {
        Index = config.Index;
        Icon = config.Icon;
        Config = config;
    }

    public int Index { get; private set; }
    public Sprite Icon { get; private set; }
    public ModelConfig Config { get; private set; }
    
    public override void OnValidate() { }
}
