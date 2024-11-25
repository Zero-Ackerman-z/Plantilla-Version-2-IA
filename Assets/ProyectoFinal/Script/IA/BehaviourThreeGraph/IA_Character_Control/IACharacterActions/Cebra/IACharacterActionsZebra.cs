using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZebra : IACharacterActions
{
    public LayerMask maskItem;

    private void Awake()
    {
        this.LoadComponent();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
    }
}

