using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{


    public Texture2D robot;
    public ColorToPrefab[] colorMappings;

    // Use this for initialization
    void Start()
    {

        GenerateRobot();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void GenerateRobot()
    {
        for (int x = 0; x < robot.width; x++)
        {
            for (int y = 0; y < robot.height; y++)
            {
                GenerateTile(x, y);

            }
        }

    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = robot.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            //é transparente
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }



    }

}
