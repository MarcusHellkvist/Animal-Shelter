// See https://aka.ms/new-console-template for more information

Animal dog = new Dog("Dog-1", 1);
Animal dog2 = new Dog("Dog-2", 2);

Shelter shelter = new Shelter();

shelter.AddAnimal(dog);
shelter.AddAnimal(dog2);

shelter.DeleteAnimal("Dog-1");
shelter.DeleteAnimal(2);

shelter.AddAnimal(dog);
shelter.AddAnimal(dog2);

shelter.UpdateAnimal(dog, "New name");

Console.WriteLine(shelter.GetAnimal(1).GetName());

var myShelter = shelter.GetAnimals();
foreach (Animal animal in myShelter)
{
    animal.PerformSound();
}


public class Shelter 
{
    public List<Animal> Animals = new();

    public void AddAnimal(Animal animal) 
    {
        Animals.Add(animal);
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return Animals;
    }

    public Animal GetAnimal(int id) 
    {
        return Animals.FirstOrDefault(a => a.Id == id); // Null check!
    }

    public void UpdateAnimal(Animal animal, string name)
    {
        animal.UpdateName(name);
    }

    public void DeleteAnimal(int id) 
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id); // Null check!
        Animals.Remove(animal);

    }

    public void DeleteAnimal(string name)
    {
        var animal = Animals.FirstOrDefault(a => a.Name == name); // Null check!
        Animals.Remove(animal);
    }

}

public interface ISoundBehavior 
{
    void MakeSound();
}

public class Bark : ISoundBehavior
{
    public void MakeSound()
    {
        Console.WriteLine("Voff!");
    }
}

public abstract class Animal
{

    public string Name { get; set; }
    public int Id { get; set; }

    public ISoundBehavior soundBehavior;

    public Animal(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public void UpdateName(string name) 
    {
        this.Name = name;
    }

    public string GetName()
    {
        return this.Name;
    }

    public void PerformSound()
    {
        soundBehavior.MakeSound();
    }
}

public class Dog : Animal
{
    public Dog(string name, int id) : base(name, id)
    {
        soundBehavior = new Bark();
    }
}