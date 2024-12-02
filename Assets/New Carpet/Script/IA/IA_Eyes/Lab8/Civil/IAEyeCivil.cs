using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeCivil : IAEyeBase
{
    private void Start()
    {
        LoadComponent();
    }
    private void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    public override void UpdateScan()
    {
        if (Framerate > arrayRate[index])
        {

            index++;
            index = index % arrayRate.Length;
            Scan();
            Framerate = 0;
        }

        Framerate += Time.deltaTime;

        if (ViewEnemy != null && ((ViewEnemy.IsDead) || (!ViewEnemy.IsCantView)))
        {
            ViewEnemy = null;
        }
        if (ViewAllie != null && ((ViewAllie.IsDead) || (!ViewAllie.IsCantView)))
        {
            ViewAllie = null;
        }

        if (ViewItems != null && ((ViewItems.IsDead) || (!ViewItems.IsCantView)))
        {
            ViewItems = null;
        }

    }
    private void OnValidate()
    {
        mainDataView.CreateMesh();
        RadioActionDataView.CreateMesh();
    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        RadioActionDataView.OnDrawGizmos();
    }
}
