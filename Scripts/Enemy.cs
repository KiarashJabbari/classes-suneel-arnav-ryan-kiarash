using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int _walkspeed;
    protected string _enemyType;
    protected bool isFreezable;
    protected bool isDead;
    public Enemy(string type)
    {
        this._enemyType = type;
    }
    public virtual void Die()
    {
        this.isDead = true;
        Destroy(gameObject);
    }

    
}
public class Moose : Enemy
{
    public Moose() : base("Moose")
    {
        _walkspeed = 10;
        isFreezable = false;
        
    }
}
public class Phooter : Enemy
{
    public Phooter() : base("Phooter")
    {
        _walkspeed = 5;
        isFreezable = true;
    }
}
public class Chaser : Enemy
{
    public Chaser() : base("Chaser")
    {
        _walkspeed = 15;
        isFreezable = true;
    }
}
public class Juggernaut : Enemy
{
    public Juggernaut() : base("Juggernaut")
    {
        _walkspeed = 5;
        isFreezable = false;
    }
}