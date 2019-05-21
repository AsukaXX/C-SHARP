using System;
using System.Collections.Generic;
using System.Text;

public class Vectors:List<Vector>{
    public Vectors(){}
    public Vectors(IEnumerable<Vector> initalItems){
        foreach(Vector vector in initalItems){
            Add(vector);
        }
    }
    public string Sum(){
        StringBuilder sb =new StringBuilder();
        Vector currenPoint = new Vector(0.0, 0.0);
        sb.Append("origin");
        foreach(Vector vector in this){
            sb.AppendFormat($" + {vector}");
            currenPoint += vector;
        }
        sb.AppendFormat($" = {currenPoint}");
        return sb.ToString();
    }
}