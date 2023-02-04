using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackItem : InteractableItem
{
    public override void OnApproach()
    {
        base.OnApproach();
        print("Flashback");
    }
}
