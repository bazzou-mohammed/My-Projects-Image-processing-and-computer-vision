using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer rend;

    private GameObject turret;
    private Color startColor;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown(){
        if(turret != null)
        {
            Debug.Log("Impossible de construire ici, il y a deja une tourelle.");
            return;
        }

     GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
     turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter(){
        rend.material.color = hoverColor;

    }
     private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
