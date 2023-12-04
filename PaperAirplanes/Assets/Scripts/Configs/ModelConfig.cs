using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class ModelConfig  {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Index { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public List<Sprite> Schema { get; private set; }
}
