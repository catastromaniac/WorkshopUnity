using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour{
    /*
    MonoBehavior - Ele tem ação no jogo e acesso a recursos;
    : Significa Herança;
    Awake() é a primeira função rodada ao carregar, seguida da OnEnable();
    OnEnable() é chamada quando um item fica ativo na cena;
    OnDisable() é chamada quando um item se torna inativo na cena;
    */

    [Header("Layers")]
    public LayerMask groundLayer;

    private NavMeshAgent nav;

    private void Start(){
    //Fazer instâncias, ligar referências, tudo que acontece após a base ter carregado e o objeto estar ativo.

        nav = GetComponent<NavMeshAgent>();
        //GetComponent<Nome>() pega um componente do objeto do qual o script faz parte.
    }

    private void Update(){
        //Chamada a cada frame.
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Checar onde o mouse está;
        Debug.DrawRay(ray.origin, ray.direction*150, Color.red);

        RaycastHit hit; //Para armazenar quando o ray bater em algo;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer)){

            if (hit.collider.CompareTag("Ground")){

                nav.SetDestination(hit.point);

            }
        }
    }
}
