using UnityEngine;

public class PingPongRotationZAxis : MonoBehaviour
{
    [SerializeField][Range(0.5f, 1f)] private float rotationSpeed;
    [SerializeField][Range(0, 360)] private int maxAngleInDegrees;
    [SerializeField][Range(0, 360)] private int minAngleInDegrees;
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        float time = Mathf.PingPong(Time.time * rotationSpeed, 1);
        var minVector = new Vector3(0, 0, minAngleInDegrees);
        var maxVector = new Vector3(0, 0, maxAngleInDegrees);
        transform.eulerAngles = Vector3.Lerp(minVector, maxVector, time);
    }
    private void OnValidate()
    {
        if (maxAngleInDegrees < minAngleInDegrees) minAngleInDegrees = maxAngleInDegrees;
    }
}
