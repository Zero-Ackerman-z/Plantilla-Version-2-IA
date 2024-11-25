using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeElephantAttack : IAEyeAttack
{
    private void Start()
    {
        LoadComponent();
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    private void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    public override void UpdateScan()
    {
        base.UpdateScan();
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    private void OnValidate()
    {
        mainDataView.CreateMesh();
        AttackDataView.CreateMesh();
    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        AttackDataView.OnDrawGizmos();
    }
}