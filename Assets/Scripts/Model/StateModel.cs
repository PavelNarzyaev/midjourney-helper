using System;
using System.Collections.Generic;

[Serializable]
public class StateModel
{
    public List<ImageModel> imagesList = new();
    public string text = "";
    public string parameters = "--v 5 --iw 0.8 --s 500 --uplight --c 0";
}
