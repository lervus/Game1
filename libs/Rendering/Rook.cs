namespace libs;

public class Rook : GameObject
{

    public Rook() : base()
    {
        this.Type = GameObjectType.Rook;
        this.CharRepresentation = '♖';
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

