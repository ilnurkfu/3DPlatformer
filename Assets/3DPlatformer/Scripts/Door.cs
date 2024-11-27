using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;

    [SerializeField] private Color requiredColor;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        mesh.material.color = requiredColor;
    }
    
    public void ColorCheck(Color targerColor)
    {
        Debug.Log("Target color:= " + targerColor);
        if(requiredColor == targerColor)
        {
            gameObject.SetActive(false);
        }
    }
}
