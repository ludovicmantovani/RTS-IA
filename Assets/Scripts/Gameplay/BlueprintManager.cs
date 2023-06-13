using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Material mat_invalid;
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private int defoggerRadius = 1000;
    [SerializeField] private List<BuildingDatas> datas = new List<BuildingDatas>();

    private int _layerMaskTerrain = 1 << 7;
    private GameObject _blueprintGO;
    private BlueprintController _blueprint;
    private Material _currentMat;
    private FogOfWar _fog;
    private int dataIndex;
    #endregion

    #region Built in Methods
    void Start()
    {
        _fog = FogOfWar.instance;
    }

    void Update()
    {
        if(_blueprintGO){     
            SetMaterial();
            CursorControls();
        }
    }
    #endregion

    #region Custom Methods
    public void FindBuilding(string name){
        for(int i = 0; i < datas.Count; i++){
            if(datas[i].Name == name){
                dataIndex = i;
                InstantiateBlueprint(datas[i].Prefab);
            }
        }
    }

    void InstantiateBlueprint(GameObject building){
        _blueprintGO = Instantiate(building , Vector3.zero, Quaternion.identity);
        _blueprint = _blueprintGO.GetComponent<BlueprintController>();
        _currentMat = _blueprintGO.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial;
    }
    
    void CursorControls(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 150, _layerMaskTerrain)){
            _blueprintGO.transform.position = hit.point;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0){
            _blueprintGO.transform.Rotate(Vector3.up * rotationSpeed, Space.Self);
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            _blueprintGO.transform.Rotate(-Vector3.up * rotationSpeed, Space.Self);
        }

        if(Input.GetMouseButton(0)){
            if(_blueprint.CheckValidPlacement()){
                PlaceBuilding();
            }
        }
    }

    void SetMaterial(){
        if(_blueprint.CheckValidPlacement()){
            Renderer[] childRenderers = _blueprintGO.transform.GetChild(0).GetComponentsInChildren<Renderer>();
            for(int i = 0; i < childRenderers.Length; i++){
                childRenderers[i].sharedMaterial = _currentMat;
            }
        }else{
            Renderer[] childRenderers = _blueprintGO.transform.GetChild(0).GetComponentsInChildren<Renderer>();
            for(int i = 0; i < childRenderers.Length; i++){
                childRenderers[i].sharedMaterial = mat_invalid;
            }
        }
    }

    void PlaceBuilding(){
        _fog.UnhideUnit(_blueprintGO.transform, defoggerRadius);
        _blueprintGO.GetComponent<Building>().Datas = datas[dataIndex];
        _blueprintGO.GetComponent<Building>().enabled = true;
        _blueprintGO = null;
        Destroy(_blueprint);
    }
    #endregion
}