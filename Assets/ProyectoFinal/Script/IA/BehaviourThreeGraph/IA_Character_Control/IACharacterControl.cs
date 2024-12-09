using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IACharacterControl : MonoBehaviour
{
    public NavMeshAgent agent { get; set; }
    public Health health { get; set; }
    public IAEyeBase AIEye { get; set; }
    public IAEyeCivil IAEyeCivil { get; set; }
    public IAEyeZebra IAEyeZebra { get; set; }
    public IAEyeElephantAttack IAEyeElephantAttack { get; set; }
    public IAEyeLiontAttack IAEyeLionAttack { get; set; }


    public virtual void LoadComponent()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        AIEye = GetComponent<IAEyeBase>();

    }
}
