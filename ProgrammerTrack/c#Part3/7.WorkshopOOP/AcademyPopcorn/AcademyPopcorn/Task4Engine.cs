namespace AcademyPopcorn
{
    // 4. Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now.
    class Task4Engine : Engine
    {
        public Task4Engine(IRenderer renderer, IUserInterface userInterface, int sleepTimeInMiliseconds = 100)
            : base(renderer,userInterface, sleepTimeInMiliseconds)
        {
        }

        private void ShootPlayerRacket()
        {
        }
    }
}
