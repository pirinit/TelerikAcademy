public class PernikPopulation
{
    public static void Main()
    {
    }

    public Human CreateHuman(int id)
    {
        Human human = new Human();
        human.Age = id;
        if (id % 2 == 0)
        {
            human.Name = "Батката";
            human.Gender = Gender.UltraGuy;
        }
        else
        {
            human.Name = "Мацето";
            human.Gender = Gender.CoolChick;
        }

        return human;
    }
}