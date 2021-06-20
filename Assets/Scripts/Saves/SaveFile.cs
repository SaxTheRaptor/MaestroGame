using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveFile
{
    public string id { get; set; }

    public SaveFile(string init_id)
    {
        id = init_id;
    }
}
