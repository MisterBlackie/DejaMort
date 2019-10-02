﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IItem {
    
    string itemName { get; }
    
    string description { get; }
    
    Sprite displayImage { get; }

    void Use();
}
