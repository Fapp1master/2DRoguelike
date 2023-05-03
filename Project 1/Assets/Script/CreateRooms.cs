using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;
public  class CreateRooms:MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        { 
        minimum= min;
        maximum= max;
        }
    }

        public int colums = 16;
        public int rows = 16;

        public Count ObstacleCount = new Count (4,7);
        public Count EnemyCount = new Count(4, 7);

        public Transform Floorparent;
        public Transform Boardparent;
        public Transform ObstacleParent;
        public Transform EnemyParent;

        public GameObject[] FloorObject;
        public GameObject[] BoardObject;
        public GameObject[] EnemyObject;
        public GameObject[] ObstacleObject;

        private int RandomObject;
        private GameObject choseSprite;
        private GameObject Child;
        
   
        private List<Vector3> ObjectPosition = new List<Vector3>();
        private void CreateFloor()
        {
            for (float x = 1; x < colums ; x++)
            {
                for (int y = 1; y < rows ; y++)
                {
                choseSprite = FloorObject[Random.Range(0,FloorObject.Length )];
                Child = Instantiate(choseSprite, new Vector3(x,y,0f),Quaternion.identity);
                Child.transform.SetParent(Floorparent,true);
                ObjectPosition.Add(new Vector3(x,y,0f));
                }
            }
        }

        private Vector3 RandomPosition()
        {
            int randomIndex = Random.Range(0,ObjectPosition.Count);
            Vector3  randomPosition = ObjectPosition[randomIndex];
            return randomPosition;
        }

        public void CreateBoard()
        {
            for (int x = 0; x < colums +1; x++)
            {
                for (int y = 0; y < rows +1; y++)
                {
                    choseSprite = BoardObject[Random.Range(0, BoardObject.Length)];
                    if (x==0 ||x==colums||y==0||y==rows)
                    {
                        Child = Instantiate(choseSprite, new Vector3(x, y,0f), Quaternion.identity);
                    Child.transform.SetParent(Boardparent);
                    }

                }
            }
        }
        
        public void LayoutObjectAtRandom(GameObject[] titleArray, int min,int max,Transform parent)
        {
        int objectCount =   Random.Range(min,max+1);

            for (int i = 0; i < objectCount; i++)
            {
                Vector3 randomPosition = RandomPosition();
                GameObject titleChoice = titleArray[Random.Range(0, titleArray.Length)];
                Child = Instantiate(titleChoice, randomPosition, Quaternion.identity);
                Child.transform.SetParent(parent);

            }
        }
        public void SetupScene(int level)
        {
        CreateFloor();
        CreateBoard();
        LayoutObjectAtRandom(ObstacleObject,ObstacleCount.minimum,ObstacleCount.maximum,ObstacleParent);
        int EnemyCount = (int)Mathf.Log(level, 2f);
        
   
        }

}
