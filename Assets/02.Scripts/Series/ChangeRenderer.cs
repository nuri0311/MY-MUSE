using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeRenderer : MonoBehaviour
{
    [SerializeField] public Material SphereMaterial0;
    [SerializeField] public Material SphereMaterial1;
    [SerializeField] public Material SphereMaterial2;
    public bool isActive = false;


    float timer;
    int waitingTime;    
    MeshRenderer meshRenderer;
    Material oriMaterial;

	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        // Get the current material applied on the GameObject
        oriMaterial = meshRenderer.materials[1];
        Debug.Log("Applied Material: " + oriMaterial.name);

        timer = 0.0f;
        waitingTime = 1;
	}

    void Update(){
        timer += Time.deltaTime;
   
        if(timer > waitingTime) {
            changePaintings(meshRenderer, SphereMaterial1);
        }

        if(timer > waitingTime * 2){
            changePaintings(meshRenderer, SphereMaterial2);
        }

        if(timer > waitingTime * 3){
            changePaintings(meshRenderer, oriMaterial);
            //timer = 0.0f;
        }
    }

    public void showSeries(){
        timer += Time.deltaTime;
   
        if(timer > waitingTime) {
            changePaintings(meshRenderer, SphereMaterial1);
        }

        if(timer > waitingTime * 2){
            changePaintings(meshRenderer, SphereMaterial2);
        }

        if(timer > waitingTime * 3){
            changePaintings(meshRenderer, oriMaterial);
            //timer = 0.0f;
        }
    }


    void changePaintings(MeshRenderer meshRenderer, Material SphereMaterial){
        Material[] material = meshRenderer.materials;
        Material original = material[1]; //temp
        material[1] = SphereMaterial;
        meshRenderer.materials = material;
        Debug.Log("Original Material: " + original.name + "to New Material: " + material[1].name);
    }
}
