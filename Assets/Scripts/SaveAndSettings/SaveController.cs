using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
        Debug.Log("file exist : " + File.Exists(Application.persistentDataPath + "/picker3D.save"));
        if(!File.Exists(Application.persistentDataPath + "/picker3D.save"))
        {
            SaveGame(0);
        }
       
    }

    Save SaveObjectsInGame(int _score)
    {
        Save save = new Save();
        //save.currentlevel = _levelindex; that creat bug when level restar need to refactor
        save.score = _score;
        return save;
    }

    public void SaveGame(int _score)
    {
        Save save = SaveObjectsInGame(_score);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/picker3D.save");
        bf.Serialize(fs, save);
        Debug.Log("Level is saved");
    }

    public Save LoadGameSave()
    {
        if (File.Exists(Application.persistentDataPath + "/Picker3D.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.OpenRead(Application.persistentDataPath + "/Picker3D.save");
            Save save = (Save)bf.Deserialize(fs);
            fs.Close();
            return save;
           
        }
        else 
        {
            return null;
        }
    }
    private void OnDestroy()
    {
        //destroy save file to when restart game other wise when retry to level that cause skore bug that can avoid with good save management system
        //but I dont have time to implamnet :(
        Debug.Log("file exist : " + File.Exists(Application.persistentDataPath + "/picker3D.save"));
        if(File.Exists(Application.persistentDataPath + "/picker3D.save"))
        {
            File.Delete(Application.persistentDataPath + "/Picker3D.save");
        }
    }
}
