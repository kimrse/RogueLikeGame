namespace RogueLikeGame.GameCore.Base
{
    public class GameLoop
    {
        private readonly Action<double> updateGameLoop;
        private readonly int targetFps;
        private readonly TimeSpan frameTime;
        private bool running;
        private DateTime lastFrameTime;

        public GameLoop(Action<double> updateGameLoop, int targetFps)
        {
            this.updateGameLoop = updateGameLoop;
            this.targetFps = targetFps;
            frameTime = TimeSpan.FromSeconds(1.0 / targetFps);
        }

        public void Start()
        {
            running = true;
            lastFrameTime = DateTime.Now;
            Run();
        }

        public void Stop()
        {
            running = false;
        }

        private void Run()
        {
            while (running)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan elapsedTime = currentTime - lastFrameTime;

                int remainingMilliseconds = (int) (frameTime.TotalMilliseconds - elapsedTime.TotalMilliseconds);

                if (remainingMilliseconds > 0)
                {
                    Thread.Sleep(remainingMilliseconds);
                }

                lastFrameTime = currentTime;
                double deltaTime = elapsedTime.TotalSeconds / frameTime.TotalSeconds;
                updateGameLoop(deltaTime);
            }
        }
    }
}
