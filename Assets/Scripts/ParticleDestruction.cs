using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestruction : Interactable
{
    GameObject ParticleSystemPrefab;
    ParticleSystem ParticleSystem;
    MeshRenderer ObjectMeshRenderer;
    ParticleSystemRenderer ParticleSystemRenderer;
    MeshFilter ObjectMeshFilter;


    private void Awake()
    {
        ParticleSystemPrefab = (GameObject)Resources.Load("Prefabs/Particle System");
    }

    private void Start()
    {
        ParticleSystemPrefab = Instantiate(ParticleSystemPrefab, transform.position, Quaternion.Euler(-90f,0,0));

        ParticleSystem = ParticleSystemPrefab.GetComponent<ParticleSystem>();
        ParticleSystemRenderer = ParticleSystemPrefab.GetComponent<ParticleSystemRenderer>();
        ObjectMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        ObjectMeshFilter = gameObject.GetComponent<MeshFilter>();

        ParticleSystem.startColor = ObjectMeshRenderer.material.color;
        ParticleSystemRenderer.mesh = ObjectMeshFilter.mesh;
        ParticleSystemRenderer.material = ObjectMeshRenderer.material;
    }

    override public void Interaction()
    {
        ParticleSystem.Play();
        Destroy(gameObject);
        
    }


    
}
