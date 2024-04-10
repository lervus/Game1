namespace libs;

public class Pawn : GameObject
{

    public Pawn() : base()
    {
        this.Type = GameObjectType.Pawn;
        this.CharRepresentation = '♙';
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
