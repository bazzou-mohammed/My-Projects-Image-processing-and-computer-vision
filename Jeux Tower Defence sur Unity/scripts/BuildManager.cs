using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton

     public static BuildManager instance;
  

     private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a deja un BuildManager dans la scene !");
            return;
        }
        instance = this;
    }
    #endregion
    
    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
