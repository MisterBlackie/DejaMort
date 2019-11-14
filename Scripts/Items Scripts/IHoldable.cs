using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoldable {
    Vector3 HandPosition { get; }
    Vector3 ObjectRotation { get; }
}
