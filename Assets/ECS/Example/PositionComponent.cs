public class PositionComponent : Component
{
    public float x;
    public float y;
    
    public PositionComponent()
    {
        x = 0;
        y = 0;
    }
    
    public PositionComponent(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}