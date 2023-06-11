using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    [SerializeField] private float marge = 0.1f;

    private BuildingDatas _datas;
    private int _nbCollision = 0;
    private BoxCollider _collider;
    private int _layerMaskTerrain = 1 << 7;
    private float _previousDistance = 0;

    void OnEnable(){
        _collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckValidPlacement();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Building")){
            _nbCollision++;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Building")){
            _nbCollision--;
        }
    }

    public bool CheckValidPlacement(){
        if(_nbCollision > 0)
        {
            return false;
        }else{
            Vector3 position = transform.position;
            Vector3 center = _collider.center;
            Vector3 size = _collider.size / 2;

            float pointY = center.y - size.y;

            Vector3[] corners = new Vector3[]{
                new Vector3(center.x - size.x, pointY, center.z - size.z),
                new Vector3(center.x - size.x, pointY, center.z + size.z),
                new Vector3(center.x + size.x, pointY, center.z - size.z),
                new Vector3(center.x + size.x, pointY, center.z + size.z)
            };

            foreach(Vector3 corner in corners){
                if(Physics.Raycast(position + corner, -Vector3.up, out RaycastHit hit, 5, _layerMaskTerrain)){
                    if(_previousDistance != 0){
                        if(_previousDistance > hit.distance + marge || _previousDistance < hit.distance - marge){
                            return false;
                        }
                    }
                    _previousDistance = hit.distance;
                }
            }

            return true;
        }
    }
}