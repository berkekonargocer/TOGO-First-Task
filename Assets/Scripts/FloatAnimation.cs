using UnityEngine;

public class FloatAnimation : MonoBehaviour
{

    [SerializeField] float amplitude = 1.0f;

    [SerializeField] float animationSpeed = 2.0f;
    [SerializeField] float offset = 0.25f;

    private void Update() {
        float x = transform.position.x;
        float y = Mathf.Sin(Time.time * animationSpeed) * amplitude + offset;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}