﻿namespace Lib;

public class FileContent : Content
{
    public FileContent(int size, string name)
    {
        Size = size;;
        Name = name;
    }

    public string Name { get; }

    public int Size { get; }
}