using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{
    [SerializeField] Material[] playerMaterials;

    public void SetMaterialsColor(Color color) {
        for (int i = 0; i < playerMaterials.Length; i++)
        {
            playerMaterials[i].color = color;
        }
    }
}