using System;
using System.Collections.Generic;
using System.Linq;

public abstract class FileSystemComponent
{
    protected string name;

    public FileSystemComponent(string name)
    {
        this.name = name;
    }

    public abstract void Display(int indent = 0);
    public abstract long GetSize();
}

public class File : FileSystemComponent
{
    private long size;

    public File(string name, long size) : base(name)
    {
        this.size = size;
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}- File: {name} ({size} KB)");
    }

    public override long GetSize()
    {
        return size;
    }
}

public class Directory : FileSystemComponent
{
    private List<FileSystemComponent> components = new List<FileSystemComponent>();

    public Directory(string name) : base(name) { }

    public void Add(FileSystemComponent component)
    {
        if (components.Contains(component))
        {
            Console.WriteLine($"component '{component}' already exists in '{name}'");
            return;
        }
        components.Add(component);
    }

    public void Remove(FileSystemComponent component)
    {
        if (!components.Contains(component))
        {
            Console.WriteLine($"component '{component}' not found in '{name}'");
            return;
        }
        components.Remove(component);
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ Directory: {name}");
        foreach (var component in components)
        {
            component.Display(indent + 2);
        }
    }

    public override long GetSize()
    {
        return components.Sum(c => c.GetSize());
    }
}

class Program
{
    static void Main(string[] args)
    {
        var file1 = new File("report.docx", 120);
        var file2 = new File("photo.png", 350);
        var file3 = new File("music.mp3", 5000);
        var file4 = new File("notes.txt", 15);

        var docs = new Directory("Documents");
        var media = new Directory("Media");
        var root = new Directory("Root");

        docs.Add(file1);
        docs.Add(file4);

        media.Add(file2);
        media.Add(file3);

        root.Add(docs);
        root.Add(media);

        root.Display();

        Console.WriteLine($"\nTotal size: {root.GetSize()} KB");
    }
}

