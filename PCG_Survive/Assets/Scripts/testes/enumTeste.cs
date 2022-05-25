using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumTeste : MonoBehaviour
{
    /*
    employer = 0, 1, 2, 3
    myType = 0, 1, 2, 3
    */
    public enum Role{
        manager,
        vice,
        president,
        intern,
    }

    public Role myTypes;
    public Role  employer;
    public void Insert(){

    }
    public void Create(){
        if(employer == myTypes)
            print("existe " + employer + " == " + myTypes);
        else
            print(employer + " != " + myTypes);
    }
}
