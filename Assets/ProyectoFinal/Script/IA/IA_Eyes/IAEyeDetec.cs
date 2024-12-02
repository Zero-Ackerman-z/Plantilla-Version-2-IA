using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeDetec :  IAEyeBase
{
    public DataView DetecDataView = new DataView();

    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    public override void UpdateScan()
    {
        base.UpdateScan();
        if (ViewAllie != null)
            DetecDataView.IsInSight(ViewAllie.AimOffset);
        else
        {
            DetecDataView.Sight = false;
        }

    }
}
