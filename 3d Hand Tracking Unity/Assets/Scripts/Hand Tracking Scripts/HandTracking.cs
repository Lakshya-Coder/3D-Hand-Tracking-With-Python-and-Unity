using UnityEngine;

public class HandTracking : MonoBehaviour
{
    private UDPReceive udpReceive;
    [SerializeField] private GameObject[] handPoints;
    private GameObject handPoint;

    private void Start()
    {
        udpReceive = GetComponent<UDPReceive>();
        handPoint = handPoints[0].transform.parent.gameObject;
    }

    private void Update()
    {
        string data = udpReceive.data;

        if (string.IsNullOrEmpty(data))
            handPoint.SetActive(false);
        else
        {
            handPoint.SetActive(true);
            
            // data = data.Remove(0, 1);
            // data = data.Remove(data.Length - 1, 1);
            
            // string[] points = data.Split(',');
            
            string[] points = convertStringIntoList(data);

            for (int i = 0; i < handPoints.Length; i++)
            {
                float x = 10 - float.Parse(points[i * 3]) / 100f;
                float y = float.Parse(points[i * 3 + 1]) / 100f;
                float z = float.Parse(points[i * 3 + 2]) / 100f;

                Vector3 position = new Vector3(x, y, z);

                handPoints[i].transform.position = position;
            }
        }
    }

    private string[] convertStringIntoList(string data)
    {
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        
        return data.Split(',');
    }
}