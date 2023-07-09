using Godot;

public partial class Usable : Node2D{
    bool intractable = true;
    public void Use(){
        if(intractable) _Use();
    }
    protected virtual void _Use(){}
}