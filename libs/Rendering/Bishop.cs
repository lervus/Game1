namespace libs;

public class Bishop : GameObject
{

    public Bishop() : base()
    {
        this.Type = GameObjectType.Bishop;
        this.CharRepresentation = '♗';
        this.Color = ConsoleColor.DarkGreen;
    }

    public override void Move(int dx, int dy)
    {
        _prevPosX = _posX;
        _prevPosY = _posY;
        _posX += dx;
        _posY += dy;
    }
}
