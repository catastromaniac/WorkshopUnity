using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStatusManager : MonoBehaviour, iDamageable
{

   public Status status;
    public event Action OnTakeDamage;
    public void Start(){
        status.Init();
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.T)){
            TakeDamage(Random.Range(1,50));
        }
    }
   public void  TakeDamage(int amount){
    Debug.Log("Tomando" + amount + "de dano!");
    status.Health-=amount;
    OnTakeDamage?.Invoke();
    if(status.Health<=0){
        Die();
    }
   }
    private void Die(){
        Destroy(this.gameObject);
    }
   }

