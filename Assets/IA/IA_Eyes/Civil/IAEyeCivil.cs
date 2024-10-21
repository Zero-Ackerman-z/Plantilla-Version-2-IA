using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeCivil : IAEyeBase
{
    public Health ViewItem;
    private void Start()
    {
        LoadComponent();
    }

    public void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    public override void Scan()
    {
        if (health.HurtingMe != null) return;
        ViewAllie = null;
        ViewEnemy = null;
        ViewItem = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, mainDataView.Distance, mainDataView.Scanlayers);
        CountEnemyView = 0;
        count = colliders.Length;


        float min_dist = float.MaxValue;
        float min_distItem = float.MaxValue;
        for (int i = 0; i < count; i++)
        {

            GameObject obj = colliders[i].gameObject;

            if (this.IsNotIsThis(this.gameObject, obj))
            {

                Health Scanhealth = obj.GetComponent<Health>();
                if (Scanhealth != null &&
                    obj.activeSelf &&
                    !Scanhealth.IsDead &&
                    Scanhealth.IsCantView &&
                    mainDataView.IsInSight(Scanhealth.AimOffset))
                {
                    if (Scanhealth is HealthItem)
                    {

                        float dist = (transform.position - Scanhealth.transform.position).magnitude;
                        if (min_distItem > dist)
                        {
                            ViewItem = Scanhealth;
                            min_dist = dist;

                        }
                    }
                    else
                        ExtractViewEnemyViewAllie(ref min_dist, Scanhealth);
                }

            }



        }

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

        if (ViewItem != null && ((ViewItems.IsDead) || (!ViewItems.IsCantView)))
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
