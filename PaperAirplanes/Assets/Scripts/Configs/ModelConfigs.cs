using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModelConfigs", menuName = "Config/ModelConfigs")]
public class ModelConfigs : ScriptableObject {
    [field: SerializeField] public List<ModelConfig> Configs { get; private set; }
}
