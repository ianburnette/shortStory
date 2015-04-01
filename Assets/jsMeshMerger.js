
@script RequireComponent(MeshFilter)
@script RequireComponent(MeshRenderer)
 
function Start () {
    for (var child in transform)
        child.position += transform.position;
    transform.position = Vector3.zero;
    transform.rotation = Quaternion.identity;
   
    var meshFilters = GetComponentsInChildren(MeshFilter);
    var combine : CombineInstance[] = new CombineInstance[meshFilters.Length-1];
    var index = 0;
    for (var i = 0; i < meshFilters.Length; i++)
    {
        if (meshFilters[i].sharedMesh == null) continue;
        combine[index].mesh = meshFilters[i].sharedMesh;
        combine[index++].transform = meshFilters[i].transform.localToWorldMatrix;
        meshFilters[i].GetComponent.<Renderer>().enabled = false;
    }
    GetComponent(MeshFilter).mesh = new Mesh();
    GetComponent(MeshFilter).mesh.CombineMeshes (combine, true);
    GetComponent.<Renderer>().material = meshFilters[1].GetComponent.<Renderer>().sharedMaterial;
}