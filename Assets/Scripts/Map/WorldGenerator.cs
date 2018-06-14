using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

    public GameObject groundTile;
    public int width = 50;
    public int height = 50;
    public int tileSize = 2;
    public float colourDensity = 10f;
    public int riverStart = 65;
    public int riverEnd = 75;

	// Use this for initialization
	void Awake () {
		
        for(int i = 0; i < width * tileSize; i+=tileSize)
        {

            if(i > riverStart && i < riverEnd)
            {
                continue;
            }

            for(int j = 0; j < height * tileSize; j+=tileSize)
            {
                GameObject tile = Instantiate(groundTile, transform);
                tile.transform.position = new Vector3(i, 2f, j);

                Material mat = new Material(Shader.Find("Standard"));

                mat.color = new Color(0.05f, Mathf.PerlinNoise(((float)i * colourDensity) / width, ((float)j * colourDensity) / height) *0.25f + 0.75f, 0.25f);

                tile.GetComponent<MeshRenderer>().material = mat;
            }
        }
	}

}
