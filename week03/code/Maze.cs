using System;


public class Maze
{
    private readonly Dictionary<(int x, int y), bool[]> map;
    private int x;
    private int y;

    // Directions: [left, right, up, down]
    private const int LEFT = 0;
    private const int RIGHT = 1;
    private const int UP = 2;
    private const int DOWN = 3;

    public Maze(Dictionary<(int, int), bool[]> map)
    {
        this.map = map;
        this.x = 1;
        this.y = 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={x}, y={y})";
    }

    public void MoveLeft()
    {
        if (map[(x, y)][LEFT] && map.ContainsKey((x - 1, y)))
        {
            x--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        if (map[(x, y)][RIGHT] && map.ContainsKey((x + 1, y)))
        {
            x++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        if (map[(x, y)][UP] && map.ContainsKey((x, y - 1)))
        {
            y--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        if (map[(x, y)][DOWN] && map.ContainsKey((x, y + 1)))
        {
            y++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }
}
