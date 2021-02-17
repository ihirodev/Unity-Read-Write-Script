using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class UnityReadWrite
{

    private string[] loadArray; //variable to store the data read from the file. You can make a method that returns this variable with the data if needed.

    public static void Save(string[] array) //static method so that you're able to make reference to the method on any Script making saving easier :)
    {
        string dir = Path.Combine(Application.persistentDataPath, "data");//The file will be store in a directory called data that below will create if it doesn't exist
        string txtName = "test.text"; //The name of our text file
        string path = Path.Combine(dir, txtName); //Combine both the directory and text file name to create the full path.

        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path)); //Create the directory if it doesn't exists.
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                foreach (string line in array) //Iterate throught each element of the array and write it to the text file
                {
                    writer.Write(line);
                    writer.Write("\n"); //Add line to write the following line in a new line.
                    Debug.Log(line); //For testing purposes and to ensure it is working :)
                }
                writer.Close(); //Always remember to close the file after writing.
            }
        }
        catch (Exception e){
            Debug.LogWarning("Error: " + e.Message);
        }
    }

    private void Load()
    {
        //Same variables to get our file path as with the Save method
        string dir = Path.Combine(Application.persistentDataPath, "data");
        string txtName = "test.text"; 
        string path = Path.Combine(dir, txtName);

        if (!Directory.Exists(Path.GetDirectoryName(path))) //Validate that the directory exists
        {
            Debug.Log("Directory Not Found!"); 
        }
        if (!File.Exists(path)) // Also validate that the file exist
        {
            Debug.Log("File Not Found!");
        }
        try
        { 
            loadArray = File.ReadAllLines(path); //This will retrieve all the elements of the text file. 
                                                //Remember that we saved by adding lines after each item? This will ensure to load it exactly as we saved it.
                                                //You could also use StreamReader to read the text file but that didn't work as expected for me.

            for(int i = 0; i<loadArray.Length; i++) //This for loop is for testing purposes. Just to ensure we retrieve the data correctly
            {
                Debug.Log(loadArray[i]);
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("Error: " + e.Message);
        }
    }
}
